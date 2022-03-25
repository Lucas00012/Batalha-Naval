using BatalhaNaval.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval.Core.Entities
{
    public class Partida
    {
        public Partida()
        {
            Jogador1 = new Tabuleiro(ObterNavios(), 1);
            Jogador2 = new Tabuleiro(ObterNavios(), 2);
            VezJogador = Jogador1.NumeroJogador;
        }

        public Tabuleiro Jogador1 { get; set; }
        public Tabuleiro Jogador2 { get; set; }
        public int VezJogador { get; set; }

        public Tabuleiro JogadorAtual => VezJogador == Jogador1.NumeroJogador ? Jogador1 : Jogador2;
        public Tabuleiro JogadorInimigo => VezJogador == Jogador1.NumeroJogador ? Jogador2 : Jogador1;

        public void Jogar()
        {
            Jogador1.PosicionarNavios();
            Console.Clear();
            Jogador2.PosicionarNavios();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"VEZ DO JOGADOR Nº {VezJogador}");

                Console.WriteLine("SEU TABULEIRO:");
                JogadorAtual.MostrarSituacaoTabuleiroPosicoesAtingidas();

                Console.WriteLine("TABULEIRO INIMIGO:");
                JogadorInimigo.MostrarSituacaoTabuleiroPosicoesAtingidas();

                var (linha, coluna) = ConsoleExtensions.LerLinhaColuna("Linha/coluna para atacar o inimigo:");
                Console.Clear();
                var tiroValido = JogadorInimigo.SofrerTiro(linha, coluna);

                if (JogadorInimigo.VerificarDerrota())
                {
                    ProcessarFimJogo();
                    return;
                }

                if (tiroValido)
                    MudarVez();
            }
        }

        private void ProcessarFimJogo()
        {
            Console.WriteLine("FIM DE JOGO!");
            Console.WriteLine($"Jogador {VezJogador} VENCEU!");

            Console.WriteLine();
            Console.WriteLine("JOGADOR 1:");
            Jogador1.MostrarSituacaoTabuleiroPecasInseridas();
            Console.WriteLine();
            Console.WriteLine("APÓS ATAQUES:");
            Jogador1.MostrarSituacaoTabuleiroPosicoesAtingidas();
            Console.WriteLine();
            Console.WriteLine("MOVIMENTOS REALIZADOS:");
            Jogador2.MostrarHistoricoTirosSofridos();

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine("JOGADOR 2:");
            Jogador2.MostrarSituacaoTabuleiroPecasInseridas();
            Console.WriteLine();
            Console.WriteLine("APÓS ATAQUES:");
            Jogador2.MostrarSituacaoTabuleiroPosicoesAtingidas();
            Console.WriteLine();
            Console.WriteLine("MOVIMENTOS REALIZADOS:");
            Jogador1.MostrarHistoricoTirosSofridos();

            Console.SetCursorPosition(0, 0);
        }

        private List<Navio> ObterNavios()
        {
            return new List<Navio>()
            {
                new Navio(5, "porta-aviões", 'P'),
                new Navio(4, "encouraçado", 'E'),
                new Navio(3, "submarino", 'S'),
                new Navio(3, "destroyer", 'D'),
                new Navio(2, "barco de patrulha", 'B')
            };
        }

        private void MudarVez()
        {
            VezJogador = VezJogador == Jogador1.NumeroJogador 
                ? Jogador2.NumeroJogador 
                : Jogador1.NumeroJogador;
        }
    }
}
