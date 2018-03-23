
namespace Model
{
   public abstract class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int qtdMovimento { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }
        public Peca( Tabuleiro tabuleiro, Cor cor)
        {
            this.posicao = null;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            qtdMovimento = 0;
        }
        public void incrementarMovimento()
        {
            qtdMovimento++;
        }
        public void decrementarMovimento()
        {
            qtdMovimento--;
        }
        protected virtual bool podeMover(Posicao posicao)
        {
            var peca = tabuleiro.peca(posicao);
            return peca == null || peca.cor != cor;
        }
        public abstract bool[,] movimentosPossiveis();
        public bool existeMovimentosPossiveis() {
            bool[,] mat = movimentosPossiveis();
            for (int i = 0; i < tabuleiro.linhas; i++)
            {
                for (int j = 0; j < tabuleiro.colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool movimentoPossivel(Posicao posicao)
        {
            return movimentosPossiveis()[posicao.linha, posicao.coluna];
        }


       
    }
}
