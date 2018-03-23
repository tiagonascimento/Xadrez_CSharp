using System;
using Model;
using Util;
using Domain;
using System.Collections.Generic;

namespace Xadrez_Console
{
    public class Tela
    {



        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            Tela.imprimirTabuleiro(partida.tabuleiro);
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Trurno: " + partida._turno);
            if (!partida.terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida._jogadorAtual);
                if (partida.xeque)
                    Console.WriteLine("XEQUE!!!!!!");
            }
            else
            {
                Console.WriteLine("XEQUE MATE FIM do JOGO!!!!!!!");
                Console.WriteLine("Vencedor: " + partida._jogadorAtual);
            }
        }
        public static void imprimirPartida(PartidaDeXadrez partida, bool[,] matrizPossivel)
        {
            Tela.imprimirTabuleiro(partida.tabuleiro,matrizPossivel);
            imprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Trurno: " + partida._turno);
            Console.WriteLine("Aguardando jogada: " + partida._jogadorAtual);

        }


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
        public static void imprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças Capturadas:");
            Console.Write("Brancas: ");
            imprimirConjunto(partida.listPecasCapturadas(Cor.branco));
            Console.WriteLine();
            Console.Write("Pretas: ");
            var colorConsole = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            imprimirConjunto(partida.listPecasCapturadas(Cor.preto));
            Console.ForegroundColor = colorConsole;


        }
        public static void imprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (var i in conjunto)
            {
                Console.Write(i+" ");
            }
            Console.Write("]");
        }
    }
}
