using System;
using Model;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var tab = new Tabuleiro(8, 8);
                tab.colocarPeca(new Torre(tab, Cor.branco), new Posicao(0, 0));
                tab.colocarPeca(new Rei(tab, Cor.branco), new Posicao(0, 50));
                Tela.imprimirTabuleiro(tab);
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
         
        }
    }
}
