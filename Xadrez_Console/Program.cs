using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var posicao = new Posicao(3, 4);
            Console.WriteLine(posicao);
            Console.ReadLine();
        }
    }
}
