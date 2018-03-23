
using Domain;
using System;

namespace Model
{
    public class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) {
            this.partida = partida;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            var p = new Posicao(0, 0);
            //acima
            p.definirValores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
            //ne
            p.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
            //direita
            p.definirValores(posicao.linha, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
            //se
            p.definirValores(posicao.linha + 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
            //baixo
            p.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
            //so
            p.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
            //esquerda
            p.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
            //no
            p.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;

            //TODO jogada especial Rei
            // #jogada especial Roque
            if (qtdMovimento == 0 && !partida.xeque)
            {
                var posicaoTorre1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if(testeRoqueTorre(posicaoTorre1))
                {
                    var newPosicaoRei = new Posicao(posicao.linha, posicao.coluna + 1);
                    var newPosicaoTorre = new Posicao(posicao.linha, posicao.coluna + 2);
                    if(tabuleiro.peca(newPosicaoRei) == null && tabuleiro.peca(newPosicaoTorre)==null)
                    {
                        matriz[posicao.linha, posicao.coluna + 2]=true;
                    }
                }
            
                // #jogada especial Roque grande           
                var posicaoTorre2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeRoqueTorre(posicaoTorre2))
                {
                    var p1 = new Posicao(posicao.linha, posicao.coluna -1);
                    var p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    var p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tabuleiro.peca(p2) == null && tabuleiro.peca(p2) == null&& tabuleiro.peca(p3) == null)
                    {
                        matriz[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
            }

            return matriz;
        }

        private bool testeRoqueTorre( Posicao posicao)
        {
            var p = tabuleiro.peca(posicao);
            return p != null && p is Torre && p.cor == cor && p.qtdMovimento == 0;
        }
        public override string ToString()
        {
            return "W";
        }

    }
}
