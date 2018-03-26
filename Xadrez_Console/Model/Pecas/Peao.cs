
using Domain;
using System;

namespace Model
{
    public class Peao : Peca
    {
        private PartidaDeXadrez partida;
        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
        {
            this.partida = partida;
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

            //TODO Jogada especial En passant 
            if(posicao.linha == 3)
                {
                    var posicaoEsquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if(tabuleiro.posicaoValida(p)&& existeInimigo(posicaoEsquerda) && tabuleiro.peca(posicaoEsquerda) ==partida.vulnevaralEnPassant)
                    {
                        matriz[posicaoEsquerda.linha-1, posicaoEsquerda.coluna] = true;
                    }

                    var posicaoDireita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabuleiro.posicaoValida(p) && existeInimigo(posicaoDireita) && tabuleiro.peca(posicaoDireita) == partida.vulnevaralEnPassant)
                    {
                        matriz[posicaoDireita.linha-1, posicaoDireita.coluna] = true;
                    }
                }
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


                //TODO Jogada especial En passant 
                if (posicao.linha == 4)
                {
                    var posicaoEsquerda = new Posicao(posicao.linha, posicao.coluna - 1);
                    if (tabuleiro.posicaoValida(p) && existeInimigo(posicaoEsquerda) && tabuleiro.peca(posicaoEsquerda) == partida.vulnevaralEnPassant)
                    {
                        matriz[posicaoEsquerda.linha+1, posicaoEsquerda.coluna] = true;
                    }

                    var posicaoDireita = new Posicao(posicao.linha, posicao.coluna + 1);
                    if (tabuleiro.posicaoValida(p) && existeInimigo(posicaoDireita) && tabuleiro.peca(posicaoDireita) == partida.vulnevaralEnPassant)
                    {
                        matriz[posicaoDireita.linha+1, posicaoDireita.coluna] = true;
                    }
                }            
            }

            return matriz;
        }

        public override string ToString()
        {
            return "P";
        }
    }

}
