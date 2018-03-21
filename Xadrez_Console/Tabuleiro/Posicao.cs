
namespace Tabuleiro
{
    public class Posicao
    {
        public Posicao(int linha, int coluna)
        {
            this.linha = linha;
            this.coluna = coluna;

        }
        public int linha { get; private set; }
        public int coluna { get; private set; }
        public override string ToString()
        {
            return string.Format("Posição: {0}, {1}", linha, coluna);
        }
    }
}
