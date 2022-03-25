using BatalhaNaval.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval.Core.Entities
{
    public class Tabuleiro
    {
        public Tabuleiro(List<Navio> navios, int numeroJogador)
        {
            Area = new Navio[10, 10];
            NumeroJogador = numeroJogador;
            HistoricoTirosSofridos = new List<HistoricoMovimento>();
            Navios = navios;
        }

        private Navio[,] Area { get; set; }
        private List<Navio> Navios { get; set; }
        private List<HistoricoMovimento> HistoricoTirosSofridos { get; set; }

        public int NumeroJogador { get; private set; }

        public void PosicionarNavios()
        {
            foreach (var navio in Navios)
            {
                PosicionarNavio(navio);
            }
        }

        public bool SofrerTiro(int linha, int coluna)
        {
            Console.Write($"[ATAQUE AO JOGADOR Nº {NumeroJogador}]: ");

            if (PosicaoAtingida(linha, coluna))
            {
                Console.WriteLine("Essa posição já foi atingida!");
                return false;
            }

            var navio = Area[linha, coluna];

            if (navio == null)
                Console.WriteLine("Oops! Você atirou na água :(");
            else
                navio.Atingir();

            HistoricoTirosSofridos.Add(new HistoricoMovimento(linha, coluna, navio));
            return true;
        }

        public bool VerificarDerrota()
        {
            return Navios.All(n => n.Afundado);
        }

        public void MostrarHistoricoTirosSofridos()
        {
            foreach (var movimento in HistoricoTirosSofridos)
                Console.WriteLine(movimento.ToString());
        }

        public void MostrarSituacaoTabuleiroPecasInseridas()
        {
            Console.WriteLine("    0   1   2   3   4   5   6   7   8   9  ");
            var formatter = "| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} |";

            for (var linha = 0; linha < Area.GetLength(0); linha++)
            {
                var args = Enumerable.Range(0, Area.GetLength(1))
                    .Select(coluna => Area[linha, coluna])
                    .Select(navio => navio?.Sigla.ToString() ?? " ")
                    .ToArray();

                Console.WriteLine($"{linha} {string.Format(formatter, args)}");
            }
        }

        public void MostrarSituacaoTabuleiroPosicoesAtingidas()
        {
            Console.WriteLine("    0   1   2   3   4   5   6   7   8   9  ");
            var formatter = "| {0} | {1} | {2} | {3} | {4} | {5} | {6} | {7} | {8} | {9} |";

            for (var linha = 0; linha < Area.GetLength(0); linha++)
            {
                var args = Enumerable.Range(0, Area.GetLength(1))
                    .Select(coluna => PosicaoAtingida(linha, coluna)
                        ? Area[linha, coluna]?.Sigla.ToString() ?? "."
                        : " ")
                    .ToArray();

                Console.WriteLine($"{linha} {string.Format(formatter, args)}");
            }
        }

        private bool PosicaoAtingida(int linha, int coluna)
        {
            return HistoricoTirosSofridos.Any(h => h.Comparar(linha, coluna));
        }

        private void PosicionarNavio(Navio navio)
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine($"VEZ DO JOGADOR Nº {NumeroJogador}");
                Console.WriteLine();
                Console.WriteLine($"Navio: {navio.Nome}");
                Console.WriteLine($"Tamanho: {navio.TotalComprimento}");
                MostrarSituacaoTabuleiroPecasInseridas();

                var (linhaInicio, colunaInicio) = ConsoleExtensions.LerLinhaColuna("Linha/coluna iniciais:");
                var (linhaFim, colunaFim) = ConsoleExtensions.LerLinhaColuna("Linha/coluna finais:");
                Console.Clear();

                (linhaInicio, linhaFim) = linhaInicio > linhaFim ? (linhaFim, linhaInicio) : (linhaInicio, linhaFim);
                (colunaInicio, colunaFim) = colunaInicio > colunaFim ? (colunaFim, colunaInicio) : (colunaInicio, colunaFim);

                if (linhaInicio != linhaFim && colunaInicio != colunaFim)
                {
                    Console.WriteLine("O navio não pode estar na diagonal!");
                    continue;
                }

                if (linhaInicio == linhaFim && colunaInicio == colunaFim)
                {
                    Console.WriteLine("As posições de início/fim não podem ser iguais!");
                    continue;
                }

                if (linhaInicio >= Area.GetLength(0) || linhaFim >= Area.GetLength(0)
                    || linhaInicio < 0 || linhaFim < 0
                    || colunaInicio >= Area.GetLength(1) || colunaFim >= Area.GetLength(1)
                    || colunaInicio < 0 || colunaFim < 0)
                {
                    Console.WriteLine("As posições não podem ultrapassar o tamanho do tabuleiro!");
                    continue;
                }

                if (colunaInicio != colunaFim && (colunaFim - colunaInicio + 1) != navio.TotalComprimento
                    || linhaInicio != linhaFim && (linhaFim - linhaInicio + 1) != navio.TotalComprimento)
                {
                    Console.WriteLine("O navio não cabe nas posições escolhidas!");
                    continue;
                }

                var posicoes = new List<(int linha, int coluna)>();

                for (var linha = linhaInicio; linha <= linhaFim; linha++)
                    for (var coluna = colunaInicio; coluna <= colunaFim; coluna++)
                        posicoes.Add((linha, coluna));

                if (posicoes.Any(p => Area[p.linha, p.coluna] != null))
                {
                    Console.WriteLine("O navio não pode se cruzar com outro!");
                    continue;
                }

                foreach (var posicao in posicoes)
                    Area[posicao.linha, posicao.coluna] = navio;

                return;
            }
        }
    }
}
