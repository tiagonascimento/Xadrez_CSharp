
using System;

namespace Model
{
    public class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            var p = new Posicao(0, 0);
            //acima
            p.definirValores(posicao.linha - 1, posicao.coluna+2);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;

            p.definirValores(posicao.linha - 1, posicao.coluna - 2);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;

             //direita
            p.definirValores(posicao.linha+2, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;

            p.definirValores(posicao.linha - 2, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
        
            //baixo
            p.definirValores(posicao.linha + 1, posicao.coluna+2);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
            p.definirValores(posicao.linha + 1, posicao.coluna-2);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;
          
            //esquerda
            p.definirValores(posicao.linha+2, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;

            p.definirValores(posicao.linha - 2, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(p) && podeMover(p))
                matriz[p.linha, p.coluna] = true;

            return matriz;
        
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
