using System;
using Model;

namespace Xadrez_Console
{
    public class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++){
                for (int j = 0; j < tab.colunas; j++){
                    if (tab.peca(i, j) == null)                   
                        Console.Write("- ");                   
                    else                   
                        Console.Write(string.Format("{0} ", tab.peca(i, j)));                  
                }
                  Console.WriteLine();
            }

        }
    }
}
