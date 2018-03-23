

using System;

namespace Model
{
    public class Rainha : Peca
    {
        public Rainha(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            var p = new Posicao(0, 0);
            //acima
            p.definirValores(posicao.linha - 1, posicao.coluna);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(posicao.linha - 1, posicao.coluna);
            }           
            //ne
            p.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(posicao.linha - 1, posicao.coluna + 1);
            }
            //direita
            p.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(posicao.linha, posicao.coluna + 1);
            }
            //se
            p.definirValores(posicao.linha + 1, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(posicao.linha + 1, posicao.coluna + 1);
            }         
            //baixo
            p.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(posicao.linha + 1, posicao.coluna);
            }           
            //so
            p.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(posicao.linha + 1, posicao.coluna - 1);
            }          
            //esquerda
            p.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(posicao.linha, posicao.coluna - 1);
            }         
            //no
            p.definirValores(posicao.linha - 1, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(posicao.linha - 1, posicao.coluna - 1);
            }
          
            return matriz;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
