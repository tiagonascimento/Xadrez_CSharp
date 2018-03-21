using System;
using Model;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var tab = new Tabuleiro(8, 8);
            tab.colocarPeca(new Torre(tab, Cor.branco), new Posicao(0, 0));
            Tela.imprimirTabuleiro(tab);
            Console.ReadLine();
        }
    }
}
