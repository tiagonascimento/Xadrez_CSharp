﻿

namespace Model
{
    public class Rainha : Peca
    {
        public Rainha(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }
        public override string ToString()
        {
            return "R";
        }
    }
}
