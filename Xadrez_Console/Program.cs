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
                    Console.WriteLine("Origem");
                    var origem = Tela.lerPosicaoXadez().toPosicao();
                    Console.WriteLine("destino");
                    var destino = Tela.lerPosicaoXadez().toPosicao();
                    p.ExecultaMovimento(origem, destino);                    
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
