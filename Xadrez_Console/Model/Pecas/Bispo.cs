


using System;

namespace Model
{
    public class Bispo : Peca
    {
        public Bispo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            var p = new Posicao(0, 0);

            //ne
            p.definirValores(posicao.linha - 1, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(p.linha - 1, p.coluna);
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
            //so
            p.definirValores(posicao.linha + 1, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(posicao.linha + 1, posicao.coluna - 1);
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
            return "B";
        }
    }
}
