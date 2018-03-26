using Model;
using System.Collections.Generic;
using Util;
using Xadrez_Console.Util;
using System.Linq;

namespace Domain
{
    public class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        public int _turno { get; private set; }
        public Cor _jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> pecasCapturadas;
        public bool xeque { get; private set; }
        public Peca vulnevaralEnPassant { get; private set; }
        public PartidaDeXadrez()
        {
            vulnevaralEnPassant = null;
            pecas = new HashSet<Peca>();
            pecasCapturadas = new HashSet<Peca>();
            tabuleiro = new Tabuleiro(8, 8);
            _turno = 1;
            _jogadorAtual = Cor.branco;
            terminada = false;
            colocarPeca();
        }
        public Peca ExecultaMovimento(Posicao origem, Posicao destino)
        {
            var peca = tabuleiro.retirarPeca(origem);
            peca.incrementarMovimento();
            var pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
            if (pecaCapturada != null)
                pecasCapturadas.Add(pecaCapturada);

            // jogada especial roque pequeno
            if (peca is Rei && destino.coluna == origem.coluna + 2)
            {
                var origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                var destinoTorra = new Posicao(origem.linha, origem.coluna + 1);
                var torre = tabuleiro.retirarPeca(origemTorre);
                torre.incrementarMovimento();
                tabuleiro.colocarPeca(torre, destinoTorra);

            }
            // jogada especial roque grande
            if (peca is Rei && destino.coluna == origem.coluna - 2)
            {
                var origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                var destinoTorra = new Posicao(origem.linha, origem.coluna - 1);
                var torre = tabuleiro.retirarPeca(origemTorre);
                torre.incrementarMovimento();
                tabuleiro.colocarPeca(torre, destinoTorra);

            }
            // jogada especial En passant
            if(peca is Peao)
            {
                if(origem.coluna!=destino.coluna && pecaCapturada==null)
                {
                    Posicao posicaoPeao;
                    if(peca.cor == Cor.branco)                    
                        posicaoPeao = new Posicao(destino.linha + 1, destino.coluna);
                    else
                        posicaoPeao = new Posicao(destino.linha - 1, destino.coluna);

                    pecaCapturada = tabuleiro.retirarPeca(posicaoPeao);
                    pecasCapturadas.Add(pecaCapturada);


                }
            }

            return pecaCapturada;
        }
        public void realizaJogada(Posicao origem, Posicao destino)
        {
            var p = tabuleiro.peca(origem);
            var pecaCapturada = ExecultaMovimento(origem, destino);

            //TODO jogada especial promocao
            if (p is Peao)
            {
                if ((p.cor == Cor.branco && destino.linha == 0) || (p.cor == Cor.preto && destino.linha == 7))
                {
                    p = tabuleiro.retirarPeca(destino);
                    pecas.Remove(p);

                    Peca rainha = new Rainha(tabuleiro, p.cor);
                    tabuleiro.colocarPeca(rainha, destino);
                    pecas.Add(rainha);

                }
            }

            if (estaEmXeque(_jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new ExceptionUtil("Você não pode se colocar em xeque!");
            }
           

            if (estaEmXeque(adversaria(_jogadorAtual)))
                xeque = true;
            else
                xeque = false;

            if (testeXequeMate(adversaria(_jogadorAtual)))
                terminada = true;
            else
            {
                _turno++;
                mudarJogaodr();
            }
        

            //TODO jogada especial En Passant
            if (p is Peao && (destino.linha == origem.linha - 2 || destino.linha == origem.linha + 2))
                vulnevaralEnPassant = p;
            else
                vulnevaralEnPassant = null;

        }
        public void validarPosicaoOrigem(Posicao pos)
        {
            if (tabuleiro.peca(pos) == null)
                throw new ExceptionUtil("não Existe peça de origem escollhida");
            if (_jogadorAtual != tabuleiro.peca(pos).cor)
                throw new ExceptionUtil(" a peça escolhida não e sua");
            if (!tabuleiro.peca(pos).existeMovimentosPossiveis())
                throw new ExceptionUtil(" não a movimentos disponiveis para a peça escolhida");

        }
        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tabuleiro.peca(origem).movimentoPossivel(destino))
                throw new ExceptionUtil("Posicao de destino inválida");

        }
        private void mudarJogaodr()
        {
            if (_jogadorAtual == Cor.preto)
                _jogadorAtual = Cor.branco;
            else
                _jogadorAtual = Cor.preto;
        }
        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tabuleiro.colocarPeca(peca, new ConverterPosicao(coluna, linha).toPosicao());
            pecas.Add(peca);

        }
        public HashSet<Peca> listPecasJogo(Cor cor)
        {
            var p = pecas.Where(x => x.cor == cor);
            var p2 = new HashSet<Peca>(p);
            p2.ExceptWith(listPecasCapturadas(cor));
            return p2;
        }
        public HashSet<Peca> listPecasCapturadas(Cor cor)
        {
            var t = pecasCapturadas.Where(x => x.cor == cor);
            return new HashSet<Peca>(t);
            //return (HashSet<Peca>) t;
        }
        private void colocarPeca()
        {

            colocarNovaPeca('a', 2, new Peao(tabuleiro, Cor.branco, this));
            colocarNovaPeca('b', 2, new Peao(tabuleiro, Cor.branco, this));
            colocarNovaPeca('c', 2, new Peao(tabuleiro, Cor.branco, this));
            colocarNovaPeca('d', 2, new Peao(tabuleiro, Cor.branco, this));
            colocarNovaPeca('e', 2, new Peao(tabuleiro, Cor.branco, this));
            colocarNovaPeca('f', 2, new Peao(tabuleiro, Cor.branco, this));
            colocarNovaPeca('g', 2, new Peao(tabuleiro, Cor.branco, this));
            colocarNovaPeca('h', 2, new Peao(tabuleiro, Cor.branco, this));

            colocarNovaPeca('a', 1, new Torre(tabuleiro, Cor.branco));
            colocarNovaPeca('b', 1, new Cavalo(tabuleiro, Cor.branco));
            colocarNovaPeca('c', 1, new Bispo(tabuleiro, Cor.branco));
            colocarNovaPeca('d', 1, new Rainha(tabuleiro, Cor.branco));
            colocarNovaPeca('e', 1, new Rei(tabuleiro, Cor.branco, this));
            colocarNovaPeca('f', 1, new Bispo(tabuleiro, Cor.branco));
            colocarNovaPeca('g', 1, new Cavalo(tabuleiro, Cor.branco));
            colocarNovaPeca('h', 1, new Torre(tabuleiro, Cor.branco));


            colocarNovaPeca('a', 7, new Peao(tabuleiro, Cor.preto, this));
            colocarNovaPeca('b', 7, new Peao(tabuleiro, Cor.preto, this));
            colocarNovaPeca('c', 7, new Peao(tabuleiro, Cor.preto, this));
            colocarNovaPeca('d', 7, new Peao(tabuleiro, Cor.preto, this));
            colocarNovaPeca('e', 7, new Peao(tabuleiro, Cor.preto, this));
            colocarNovaPeca('f', 7, new Peao(tabuleiro, Cor.preto, this));
            colocarNovaPeca('g', 7, new Peao(tabuleiro, Cor.preto, this));
            colocarNovaPeca('h', 7, new Peao(tabuleiro, Cor.preto, this));

            colocarNovaPeca('a', 8, new Torre(tabuleiro, Cor.preto));
            colocarNovaPeca('b', 8, new Cavalo(tabuleiro, Cor.preto));
            colocarNovaPeca('c', 8, new Bispo(tabuleiro, Cor.preto));
            colocarNovaPeca('d', 8, new Rainha(tabuleiro, Cor.preto));
            colocarNovaPeca('e', 8, new Rei(tabuleiro, Cor.preto, this));
            colocarNovaPeca('f', 8, new Bispo(tabuleiro, Cor.preto));
            colocarNovaPeca('g', 8, new Cavalo(tabuleiro, Cor.preto));
            colocarNovaPeca('h', 8, new Torre(tabuleiro, Cor.preto));

        }
        private Cor adversaria(Cor cor)
        {
            if (cor == Cor.branco)
                return Cor.preto;
            else
                return Cor.branco;
        }
        private Peca retonaRei(Cor cor)
        {
            return listPecasJogo(cor).Where(x => x is Rei).FirstOrDefault();
        }
        public bool estaEmXeque(Cor cor)
        {
            var rei = retonaRei(cor);
            foreach (var i in listPecasJogo(adversaria(cor)))
            {
                var matriz = i.movimentosPossiveis();
                if (matriz[rei.posicao.linha, rei.posicao.coluna])
                    return true;

            }
            return false;
        }
        public bool testeXequeMate(Cor cor)
        {
            if (!estaEmXeque(cor))
                return false;
            foreach (var p in listPecasJogo(cor))
            {
                var matriz = p.movimentosPossiveis();
                for (int i = 0; i < tabuleiro.linhas; i++)
                {
                    for (int j = 0; j < tabuleiro.colunas; j++)
                    {
                        if (matriz[i, j])
                        {
                            var origem = p.posicao;
                            var destino = new Posicao(i, j);
                            var movpeca = ExecultaMovimento(origem, destino);
                            bool testeXeque = estaEmXeque(cor);
                            desfazMovimento(origem, destino, movpeca);
                            if (!testeXeque)
                                return false;
                        }
                    }
                }
            }
            return true;
        }
        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            var pe = tabuleiro.retirarPeca(destino);
            pe.decrementarMovimento();
            if (pecaCapturada != null)
            {
                tabuleiro.colocarPeca(pecaCapturada, destino);
                pecasCapturadas.Remove(pecaCapturada);
            }
            tabuleiro.colocarPeca(pe, origem);


            // jogada especial roque pequeno
            if (pe is Rei && destino.coluna == origem.coluna + 2)
            {
                var origemTorre = new Posicao(origem.linha, origem.coluna + 3);
                var destinoTorra = new Posicao(origem.linha, origem.coluna + 1);
                var torre = tabuleiro.retirarPeca(destinoTorra);
                torre.decrementarMovimento();
                tabuleiro.colocarPeca(torre, origemTorre);

            }
            // jogada especial roque grande
            if (pe is Rei && destino.coluna == origem.coluna - 2)
            {
                var origemTorre = new Posicao(origem.linha, origem.coluna - 4);
                var destinoTorra = new Posicao(origem.linha, origem.coluna - 1);
                var torre = tabuleiro.retirarPeca(destinoTorra);
                torre.decrementarMovimento();
                tabuleiro.colocarPeca(torre, origemTorre);

            }
            // jogada especial en passant
            if (pe is Peao)
            {
                if(origem.coluna != destino.coluna && pecaCapturada == vulnevaralEnPassant)
                {
                    var peao = tabuleiro.retirarPeca(destino);
                    Posicao posicaoPeao;
                    if(pe.cor == Cor.branco)                    
                        posicaoPeao = new Posicao(3, destino.coluna);                    
                    else
                        posicaoPeao = new Posicao(4, destino.coluna);
                    tabuleiro.colocarPeca(pe, posicaoPeao);
                }
                
            }
        }
    }
}
