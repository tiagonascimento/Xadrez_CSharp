
namespace Model
{
    public class Piao : Peca
    {
        public Piao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }
        public override string ToString()
        {
            return "P";
        }
    }

}
