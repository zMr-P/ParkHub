using Newtonsoft.Json;
using System.Diagnostics;

namespace ParkHub.Models
{
    public class Estacionamento
    {
        public decimal ValorHora { get; set; }
        public Stopwatch? TempoDecorrido { get; set; }
        public List<Veiculo> VeiculosEstacionados { get; set; }
        public int Vagas { get; set; }
        public StatusVagas Status { get; set; }

        public Estacionamento()
        {
            VeiculosEstacionados = new List<Veiculo>();
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            VeiculosEstacionados.Add(veiculo);
        }
        public void RemoverVeiculo(Veiculo veiculo)
        {
            VeiculosEstacionados.Remove(veiculo);
        }
        public void ListarVeiculos()
        {
            if (VeiculosEstacionados.Count > 0)
            {
                foreach (var veiculin in VeiculosEstacionados)
                {
                    var veiculo = JsonConvert.SerializeObject(veiculin, Formatting.Indented);
                    Console.WriteLine(veiculo);
                }
            }
            else
            {
                throw new ArgumentNullException("Não há nenhum veiculo estacionado.");
            }
        }
    }
}
public enum StatusVagas : int
{
    LocalVago = 0,
    VeiculoEstacionado = 1
}

