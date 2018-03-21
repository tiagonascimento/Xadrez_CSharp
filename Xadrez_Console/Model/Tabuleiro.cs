

using Xadrez_Console.Util;

namespace Model
{
    public class Tabuleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        public Peca[,] pecas { get; private set; }

        public Tabuleiro(int linhas, int colunas) {
            this.linhas = linhas;
            this.colunas = colunas;
            pecas = new Peca[linhas, colunas];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
        public Peca peca(Posicao posicao)
        {
            return pecas[posicao.linha, posicao.coluna];
        }
        public void colocarPeca(Peca peca, Posicao posicao)
        {
            if(existePeca(posicao))
                throw new ExceptionUtil("Ja existe uma Peça nessa posição");
            pecas[posicao.linha, posicao.coluna] = peca;
        }
        public bool posicaoValida(Posicao posicao)
        {
            if (posicao.linha < 0 || posicao.linha >= linhas || posicao.coluna < 0 || posicao.coluna > colunas)
                return false;
            return true;
        }
        public void validaPosicao(Posicao posicao)
        {
            if (!posicaoValida(posicao))
                throw new ExceptionUtil("Posição inválida");
        }
        public bool existePeca(Posicao posicao)
        {
            validaPosicao(posicao);
            return peca(posicao) != null;
        }
    }
}
