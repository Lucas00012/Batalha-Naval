using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval.Core.Entities
{
    public class Navio
    {
        public Navio(int totalComprimento, string nome, char sigla)
        {
            TotalComprimento = totalComprimento;
            Nome = nome;
            Sigla = sigla;
        }

        public int TotalComprimento { get; private set; }
        public int TotalAtingido { get; private set; }

        public char Sigla { get; private set; }
        public string Nome { get; private set; }

        public bool Afundado => TotalComprimento == TotalAtingido;

        public void Atingir()
        {
            if (Afundado)
                return;

            TotalAtingido++;

            Console.WriteLine($"Você {(Afundado ? "afundou" : "atingiu")} um {Nome}!");
        }
    }
}
