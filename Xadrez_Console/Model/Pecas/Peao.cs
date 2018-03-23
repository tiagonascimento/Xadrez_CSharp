
using System;

namespace Model
{
    public class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }
        private bool existeInimigo(Posicao pos)
        {
            var p = tabuleiro.peca(pos);
            return p != null && p.cor != cor;
        }

        private bool livre(Posicao pos)
        {
            return tabuleiro.peca(pos) == null;
        }
        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            var p = new Posicao(0, 0);
            if(cor == Cor.branco)
            {
                //acima
                p.definirValores(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.posicaoValida(p) && livre(p))
                    matriz[p.linha, p.coluna] = true;

                p.definirValores(posicao.linha - 2, posicao.coluna);
                var p2 = new Posicao(posicao.linha - 1, posicao.coluna);
                if (tabuleiro.posicaoValida(p2) && livre(p2) && tabuleiro.posicaoValida(p) && livre(p) && qtdMovimento == 0)
                    matriz[p.linha, p.coluna] = true;

                p.definirValores(posicao.linha - 1, posicao.coluna - 1);
                if (tabuleiro.posicaoValida(p) && existeInimigo(p))               
                    matriz[p.linha, p.coluna] = true;
                
                p.definirValores(posicao.linha - 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(p) && existeInimigo(p))                
                    matriz[p.linha, p.coluna] = true;
            }
            else
            {
                //acima
                p.definirValores(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.posicaoValida(p) && livre(p))
                    matriz[p.linha, p.coluna] = true;

                p.definirValores(posicao.linha + 2, posicao.coluna);
                var p2 = new Posicao(posicao.linha + 1, posicao.coluna);
                if (tabuleiro.posicaoValida(p2) && livre(p2) && tabuleiro.posicaoValida(p) && livre(p) && qtdMovimento == 0)
                    matriz[p.linha, p.coluna] = true;

                p.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(p) && existeInimigo(p))
                    matriz[p.linha, p.coluna] = true;

                p.definirValores(posicao.linha + 1, posicao.coluna + 1);
                if (tabuleiro.posicaoValida(p) && existeInimigo(p))
                    matriz[p.linha, p.coluna] = true;
            }
            return matriz;
        }

        public override string ToString()
        {
            return "P";
        }
    }

}
