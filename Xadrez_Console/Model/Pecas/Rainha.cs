﻿

using System;

namespace Model
{
    public class Rainha : Peca
    {
        public Rainha(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        public override bool[,] movimentosPossiveis()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "R";
        }
    }
}