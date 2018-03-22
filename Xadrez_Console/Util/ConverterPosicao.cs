using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xadrez_Console.Util
{
    public class ConverterPosicao
    {
        public char coluna { get; private set; }
        public int linha { get; private set; }

       public ConverterPosicao(char coluna, int linha)
        {
            this.coluna = coluna;
            this.linha = linha;

        }

        public Posicao toPosicao() {
            return new Posicao(8 - linha, coluna - 'a');
        }
        public override string ToString()
        {
            return "" + coluna + linha;
        }

    }
}
