using System;
using Model;

namespace Xadrez_Console
{
    public class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++){
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++){
                    if (tab.peca(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                        ImprimiPeca(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                  Console.WriteLine();
            }
            Console.Write("  A B C D E F G H");
        }
        public  static void ImprimiPeca(Peca peca)
        {
            if (peca.cor == Cor.branco)
                Console.Write(peca);
            else
            {
                var colorConsole = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write(peca);
                Console.ForegroundColor = colorConsole;
            }
        }
    }
}
