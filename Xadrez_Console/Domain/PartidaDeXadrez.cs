using Model;
using Util;

namespace Domain
{
    public class PartidaDeXadrez
    {
        public  Tabuleiro tabuleiro { get; private set; }
     
        private int _turno;
        private Cor _jogadorAtual;
        public bool terminada { get; private set; }
        public PartidaDeXadrez()
        {
            tabuleiro = new Tabuleiro(8, 8);
            _turno = 1;
            _jogadorAtual = Cor.branco;
            colocarPeca();
            terminada = false;
        }
        public void ExecultaMovimento(Posicao origem, Posicao destino)
        {
            var peca = tabuleiro.retirarPeca(origem);
            peca.incrementarMovimento();
            var pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(peca, destino);
        }
        private void colocarPeca()
        {
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.branco),  new ConverterPosicao('a', 1).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.branco), new ConverterPosicao('b', 1).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.branco),  new ConverterPosicao('c', 1).toPosicao());
            tabuleiro.colocarPeca(new Rainha(tabuleiro, Cor.branco), new ConverterPosicao('d', 1).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.branco),    new ConverterPosicao('e', 1).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.branco),  new ConverterPosicao('f', 1).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.branco), new ConverterPosicao('g', 1).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.branco),  new ConverterPosicao('h', 1).toPosicao());

            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.branco),  new ConverterPosicao('a', 2).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.branco),  new ConverterPosicao('b', 2).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.branco),  new ConverterPosicao('c', 2).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.branco),  new ConverterPosicao('d', 2).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.branco),  new ConverterPosicao('e', 2).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.branco),  new ConverterPosicao('f', 2).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.branco),  new ConverterPosicao('g', 2).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.branco),  new ConverterPosicao('h', 2).toPosicao());



            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto),  new ConverterPosicao('a',8).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.preto), new ConverterPosicao('b',8).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.preto),  new ConverterPosicao('c',8).toPosicao());
            tabuleiro.colocarPeca(new Rainha(tabuleiro, Cor.preto), new ConverterPosicao('d',8).toPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.preto),    new ConverterPosicao('e',8).toPosicao());
            tabuleiro.colocarPeca(new Bispo(tabuleiro, Cor.preto),  new ConverterPosicao('f',8).toPosicao());
            tabuleiro.colocarPeca(new Cavalo(tabuleiro, Cor.preto), new ConverterPosicao('g',8).toPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto),  new ConverterPosicao('h',8).toPosicao());

            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.preto), new ConverterPosicao('a', 7).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.preto), new ConverterPosicao('b', 7).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.preto), new ConverterPosicao('c', 7).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.preto), new ConverterPosicao('d', 7).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.preto), new ConverterPosicao('e', 7).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.preto), new ConverterPosicao('f', 7).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.preto), new ConverterPosicao('g', 7).toPosicao());
            tabuleiro.colocarPeca(new Piao(tabuleiro, Cor.preto), new ConverterPosicao('h', 7).toPosicao());
            //tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto), new Posicao(7, 7));
            //tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto), new Posicao(7, 7));
            //tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.preto), new Posicao(7, 0));
        }
    }
}
