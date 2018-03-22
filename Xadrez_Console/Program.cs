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
                tab.colocarPeca(new Torre(tab, Cor.branco), new Posicao(0, 7));
                tab.colocarPeca(new Torre(tab, Cor.preto), new Posicao(7, 7));
                tab.colocarPeca(new Torre(tab, Cor.preto), new Posicao(7, 0));
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
