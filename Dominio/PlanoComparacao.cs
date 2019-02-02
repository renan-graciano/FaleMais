using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PlanoComparacao
    {
        public string Origem { get; set; }
        public string Destino { get; set; }
        public int Tempo { get; set; }
        public string Plano { get; set; }
        public double ComPlano { get; set; }
        public double SemPlano { get; set; }

        private List<PrecoOrigemDestino> precoOrigemDestinos;
        private PrecoOrigemDestino preco;


        public List<PlanoComparacao> GerarListaComparacao(int minutos, Plano plano)
        {
            preco = new PrecoOrigemDestino();
            precoOrigemDestinos = new List<PrecoOrigemDestino>();
            precoOrigemDestinos = preco.GerarListaPrecos();
            
            var retorno = new List<PlanoComparacao>();
            if (plano == Enums.Plano.Todos)
            {
                var valores = Enum.GetValues(typeof(Plano));

                foreach (var itemPlano in valores)
                {
                    if ((Enums.Plano)itemPlano != Enums.Plano.Todos)
                    {
                        foreach (var item in precoOrigemDestinos)
                        {
                            var planoComparacao = new PlanoComparacao();
                            planoComparacao = GerarComparacaoPlano(item, minutos, (Enums.Plano)itemPlano);
                            retorno.Add(planoComparacao);
                        }
                    }
                }
            }
            else
            {
                foreach (var item in precoOrigemDestinos)
                {
                    var planoComparacao = new PlanoComparacao();
                    planoComparacao = GerarComparacaoPlano(item, minutos, plano);
                    retorno.Add(planoComparacao);
                }
            }
            return retorno;


        }

        private PlanoComparacao GerarComparacaoPlano(PrecoOrigemDestino dados, int tempo, Plano planoMinuto)
        {
            var planoComparacao = new PlanoComparacao();


            planoComparacao.Origem = dados.Origem;
            planoComparacao.Destino = dados.Destino;
            planoComparacao.Tempo = tempo;
            planoComparacao.Plano = planoMinuto.ToString();
            if ((tempo - planoMinuto.GetHashCode()) > 0)
                planoComparacao.ComPlano = ((tempo - planoMinuto.GetHashCode()) * dados.Preco) * 1.10;
            else
                planoComparacao.ComPlano = 0;

            planoComparacao.SemPlano = tempo * dados.Preco;

            return planoComparacao;
        }

    }
}
