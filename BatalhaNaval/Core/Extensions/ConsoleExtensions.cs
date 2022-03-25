using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval.Core.Extensions
{
    public static class ConsoleExtensions
    {
        public static (int linha, int coluna) LerLinhaColuna(string exibicao)
        {
            while (true)
            {
                try
                {
                    Console.WriteLine(exibicao);
                    var split = Console.ReadLine().Split(',');
                    var linha = int.Parse(split[0]);
                    var coluna = int.Parse(split[1]);

                    return (linha, coluna);
                }
                catch (Exception)
                {
                    Console.WriteLine("FORMATO INVÁLIDO!");
                    continue;
                }
            }
        }
    }
}
