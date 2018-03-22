using System;
using Model;
using Util;

namespace Xadrez_Console
{
    public class Tela
    {
        public static void imprimirTabuleiro(Tabuleiro tab)
        {
            for (int i = 0; i < tab.linhas; i++){
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++){
                    ImprimiPeca(tab.peca(i,j));
                }            
                  Console.WriteLine();
            }
         
            Console.WriteLine("  A B C D E F G H");
        }
        public static void imprimirTabuleiro(Tabuleiro tab, bool [,] matrizPossivel)
        {
            ConsoleColor bgOriginal = Console.BackgroundColor;
            ConsoleColor bgNovo = ConsoleColor.Green;

            for (int i = 0; i < tab.linhas; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.colunas; j++)
                {
                    if (matrizPossivel[i, j])
                    {
                        Console.BackgroundColor = bgNovo;
                    }
                    else {
                        Console.BackgroundColor = bgOriginal;
                    }
                    ImprimiPeca(tab.peca(i, j));
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = bgOriginal;
        
            Console.WriteLine("  A B C D E F G H");
          
        }
        public  static void ImprimiPeca(Peca peca)
        {
            if (peca == null)
                Console.Write("- ");
            else
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
                Console.Write(" ");
            }
        }

        public static ConverterPosicao lerPosicaoXadez()
        {
            var str = Console.ReadLine();
            char coluna = str[0];
            int linha = Convert.ToInt32(str[1]+"");
            return new ConverterPosicao(coluna, linha);
        }
    }
}
