


using System;

namespace Model
{
    public class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
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
                p.definirValores( p.linha - 1, p.coluna);
            }

            //baixo
            p.definirValores(posicao.linha + 1, posicao.coluna);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(p.linha +1, p.coluna);
            }
            //direita
            p.definirValores(posicao.linha, posicao.coluna + 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(p.linha , p.coluna+1);
            }                               
            //esquerda
            p.definirValores(posicao.linha, posicao.coluna - 1);
            while (tabuleiro.posicaoValida(p) && podeMover(p))
            {
                matriz[p.linha, p.coluna] = true;
                if (tabuleiro.peca(p) != null && tabuleiro.peca(p).cor != cor)
                    break;
                p.definirValores(p.linha, p.coluna - 1);
            }
            return matriz;

        }

        public override string ToString()
        {
            return "T";
        }
    }
}
