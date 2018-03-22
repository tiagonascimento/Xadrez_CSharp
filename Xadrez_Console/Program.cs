using System;
using Model;
using Domain;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {               
                var p = new PartidaDeXadrez();
                while (!p.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(p.tabuleiro);
                    Console.WriteLine("Trurno: " + p._turno);
                    Console.WriteLine("Aguardando jogada: " + p._jogadorAtual);




                    Console.WriteLine("Origem");
                    var origem = Tela.lerPosicaoXadez().toPosicao();
                    var pe = p.tabuleiro.peca(origem);              
                    var mov = pe.movimentosPossiveis();
   

                    Console.Clear();
                   Tela.imprimirTabuleiro(p.tabuleiro, mov);
                    Console.WriteLine("destino");
                    var destino = Tela.lerPosicaoXadez().toPosicao();
                    p.realizaJogada(origem, destino);                    
                }

                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            Console.ReadLine();
        }
    }
}
