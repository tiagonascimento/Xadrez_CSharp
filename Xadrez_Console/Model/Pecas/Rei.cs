
using System;

namespace Model
{
    public class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base( tabuleiro, cor){}

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            var p = new Posicao(0, 0);
            //acima
            p.definirValores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicaoValida(p))            
                matriz[p.linha, p.coluna] = true;
            //ne
            p.definirValores(posicao.linha - 1, posicao.coluna+1);
            if (tabuleiro.posicaoValida(p))
                matriz[p.linha, p.coluna] = true;
            //direita
            p.definirValores(posicao.linha , posicao.coluna+1);
            if (tabuleiro.posicaoValida(p))
                matriz[p.linha, p.coluna] = true;
            //se
            p.definirValores(posicao.linha + 1, posicao.coluna +1);
            if (tabuleiro.posicaoValida(p))
                matriz[p.linha, p.coluna] = true;
            //baixo
            p.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(p))
                matriz[p.linha, p.coluna] = true;
            //so
            p.definirValores(posicao.linha + 1, posicao.coluna-1);
            if (tabuleiro.posicaoValida(p))
                matriz[p.linha, p.coluna] = true;
            //esquerda
            p.definirValores(posicao.linha , posicao.coluna-1);
            if (tabuleiro.posicaoValida(p))
                matriz[p.linha, p.coluna] = true;
            //no
            p.definirValores(posicao.linha - 1, posicao.coluna-1);
            if (tabuleiro.posicaoValida(p))
                matriz[p.linha, p.coluna] = true;
        
            return matriz;
        }
      

        public override string ToString()
        {
            return "W";
        }

    }
}
