
namespace ParkHub.Models
{
    public class Estacionamento
    {
        public decimal ValorHora { get; set; }
        public List<Veiculo> VeiculosEstacionados { get; set; }
        public Veiculo NovoVeiculo { get; set; }
        public Vagas[] Vagas { get; set; }

        public Estacionamento(int quantidadeVagas)
        {
            VeiculosEstacionados = new List<Veiculo>();
            Vagas = new Vagas[quantidadeVagas];
            NovoVeiculo = new("", "", "");
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            VeiculosEstacionados.Add(veiculo);
        }
        public void RemoverVeiculo(Veiculo veiculo)
        {
            VeiculosEstacionados.Remove(veiculo);
        }
        public void ListarVeiculos(int quantidadeVagas, Vagas[] vagas)
        {
            if (VeiculosEstacionados.Count > 0)
            {
                for (int i = 0; i < quantidadeVagas; i++)
                {
                    if (vagas[i] != null)
                    {
                        foreach (var veiculin in VeiculosEstacionados)
                        {

                            if (veiculin.Placa != "" && veiculin.Placa != null && veiculin.Placa == vagas[i].VeiculoEstacionado.Placa)
                            {
                                Console.WriteLine($"{Vagas[i]}");
                                Console.WriteLine($"Local estacionado: {i}\n");
                            }

                        }
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Não há nenhum veiculo estacionado.");
            }
        }
    }
}
