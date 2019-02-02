using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PrecoOrigemDestino
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public double Preco { get; set; }

        public List<PrecoOrigemDestino> GerarListaPrecos()
        {
            List<PrecoOrigemDestino> retorno = new List<PrecoOrigemDestino>();
            retorno.Add(Criar("011", "016", 1.90));
            retorno.Add(Criar("016", "011", 2.90));
            retorno.Add(Criar("011", "017", 1.70));
            retorno.Add(Criar("017", "011", 2.70));
            retorno.Add(Criar("011", "018", 0.90));
            retorno.Add(Criar("018", "011", 1.90));

            return retorno;
        }
        private PrecoOrigemDestino Criar(string origem, string destino, double preco)
        {
            var linha = new PrecoOrigemDestino();
            linha.Origem = origem;
            linha.Destino = destino;
            linha.Preco = Math.Round(preco, 2);

            return linha;
        }
    }
}
