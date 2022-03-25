using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatalhaNaval.Core.Entities
{
    public class HistoricoMovimento
    {
        public int Linha { get; private set; }
        public int Coluna { get; private set; }

        public string Nome { get; private set; }
        public bool Sucedido { get; private set; }
        public bool Afundado { get; private set; }

        public HistoricoMovimento(int linha, int coluna, Navio navio = null)
        {
            Linha = linha;
            Coluna = coluna;

            Nome = navio?.Nome;
            Afundado = navio?.Afundado ?? false;
            Sucedido = navio != null;
        }

        public bool Comparar(int linha, int coluna)
        {
            return Linha == linha && Coluna == coluna;
        }

        public override string ToString()
        {
            if (!Sucedido)
                return $"Não sucedido ({Linha},{Coluna})";

            if (Afundado)
                return $"Sucedido ({Linha},{Coluna}) - Afundou {Nome}";

            return $"Sucedido ({Linha},{Coluna}) - Atingiu {Nome}";
        }
    }
}
