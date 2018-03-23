using Model;
using System.Collections.Generic;
using Util;
using Xadrez_Console.Util;
using System.Linq;

namespace Domain
{
    public class PartidaDeXadrez
    {
        public  Tabuleiro tabuleiro { get; private set; }

        public int _turno{ get; private set; }
        public Cor _jogadorAtual { get; private set; }
        public bool terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> pecasCapturadas;
        public bool xeque { get; private set; }


        public PartidaDeXadrez()
        {
            pecas = new HashSet<Peca>();
            pecasCapturadas = new HashSet<Peca>();
            tabuleiro = new Tabuleiro(8, 8);
            _turno = 1;
            _jogadorAtual = Cor.branco;
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

            return pecaCapturada;
        }
        public void realizaJogada(Posicao origem,Posicao destino)
        {
           var pecaCapturada =  ExecultaMovimento(origem, destino);
           if(estaEmXeque(_jogadorAtual))
            {
                desfazMovimento(origem, destino, pecaCapturada);
                throw new ExceptionUtil("Você não pode se colocar em xeque!");
            }
            if (estaEmXeque(adversaria(_jogadorAtual)))
                xeque = true;
            else
                xeque = false;

              
            _turno++;
            mudarJogaodr();

        }
        public void validarPosicaoOrigem(Posicao pos)
        {
            if (tabuleiro.peca(pos) == null)
                throw new ExceptionUtil("não Existe peça de origem escollhida");
            if (_jogadorAtual!= tabuleiro.peca(pos).cor)
                throw new ExceptionUtil(" a peça escolhida não e sua");
            if (!tabuleiro.peca(pos).existeMovimentosPossiveis())
                throw new ExceptionUtil(" não a movimentos disponiveis para a peça escolhida");

        }
        public void validarPosicaoDestino(Posicao origem, Posicao destino)
        {
            if (!tabuleiro.peca(origem).podeMoverPara(destino))
                throw new ExceptionUtil("Posicao de destino inválida");
           

        }
        private void mudarJogaodr()
        {
            if(_jogadorAtual == Cor.preto)
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
            var t  = pecasCapturadas.Where(x => x.cor == cor);
            return new HashSet<Peca>(t);
            //return (HashSet<Peca>) t;
        }
        private void colocarPeca()
        {
            colocarNovaPeca('c', 1, new Torre(tabuleiro, Cor.branco));
            colocarNovaPeca('c', 2, new Torre(tabuleiro, Cor.branco));
            colocarNovaPeca('d', 2, new Torre(tabuleiro, Cor.branco));
            colocarNovaPeca('e', 2, new Torre(tabuleiro, Cor.branco));
            colocarNovaPeca('e', 1, new Torre(tabuleiro, Cor.branco));
            colocarNovaPeca('d', 1, new Rei(tabuleiro, Cor.branco));


            colocarNovaPeca('c', 7, new Torre(tabuleiro, Cor.preto));
            colocarNovaPeca('c', 8, new Torre(tabuleiro, Cor.preto));
            colocarNovaPeca('d', 7, new Torre(tabuleiro, Cor.preto));
            colocarNovaPeca('e', 7, new Torre(tabuleiro, Cor.preto));
            colocarNovaPeca('e', 8, new Torre(tabuleiro, Cor.preto));
            colocarNovaPeca('d', 8, new Rei(tabuleiro, Cor.preto));

            //  tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.branco),  new ConverterPosicao('a', 1).toPosicao());    
            //tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.branco), new ConverterPosicao('b', 1).toPosicao());
            //tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.branco),  new ConverterPosicao('c', 1).toPosicao());
            //tabuleiro.colocarPeca(new Rainha(tabuleiro, Cor.branco), new ConverterPosicao('d', 1).toPosicao());
            //tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.branco),    new ConverterPosicao('e', 1).toPosicao());
            //tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.branco),  new ConverterPosicao('f', 1).toPosicao());
            //tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.branco), new ConverterPosicao('g', 1).toPosicao());
            //tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.branco),  new ConverterPosicao('h', 1).toPosicao());

            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.branco),  new ConverterPosicao('a', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.branco),  new ConverterPosicao('b', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.branco),  new ConverterPosicao('c', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.branco),  new ConverterPosicao('d', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.branco),  new ConverterPosicao('e', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.branco),  new ConverterPosicao('f', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.branco),  new ConverterPosicao('g', 2).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.branco),  new ConverterPosicao('h', 2).toPosicao());



            //tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto),  new ConverterPosicao('a',8).toPosicao());
            //tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.preto), new ConverterPosicao('b',8).toPosicao());
            //tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.preto),  new ConverterPosicao('c',8).toPosicao());
            //tabuleiro.colocarPeca(new Rainha(tabuleiro, Cor.preto), new ConverterPosicao('d',8).toPosicao());
            //tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.preto),    new ConverterPosicao('e',8).toPosicao());
            //tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.preto),  new ConverterPosicao('f',8).toPosicao());
            //tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.preto), new ConverterPosicao('g',8).toPosicao());
            //tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto),  new ConverterPosicao('h',8).toPosicao());

            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.preto), new ConverterPosicao('a', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.preto), new ConverterPosicao('b', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.preto), new ConverterPosicao('c', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.preto), new ConverterPosicao('d', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.preto), new ConverterPosicao('e', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.preto), new ConverterPosicao('f', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.preto), new ConverterPosicao('g', 7).toPosicao());
            //tabuleiro.colocarPeca(new Peao(tabuleiro, Cor.preto), new ConverterPosicao('h', 7).toPosicao());
            //tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto), new Posicao(7, 7));
            //tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto), new Posicao(7, 7));
            //tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto), new Posicao(7, 0));
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
        }
    }
}
