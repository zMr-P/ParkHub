using Newtonsoft.Json;
using System.Diagnostics;

namespace ParkHub.Models
{
    public class Vagas
    {
        public Veiculo? VeiculoEstacionado { get; set; }
        public Stopwatch? TempoEstacionado { get; set; }
        public StatusVagas Status { get; set; } = StatusVagas.LocalVago;
        public Vagas()
        {
            TempoEstacionado = new Stopwatch();
            VeiculoEstacionado = new("","","");
        }
        public override string ToString()
        {
            var jsonSerializado = JsonConvert.SerializeObject(VeiculoEstacionado, Formatting.Indented);
            var tempoFormatado = $"{TempoEstacionado.Elapsed.Hours:D2}:{TempoEstacionado.Elapsed.Minutes:D2}:{TempoEstacionado.Elapsed.Seconds:D2}";

            return jsonSerializado
                +"\nStatus do veículo: " + Status
                +"\nTempo estacionado: " + tempoFormatado
                +"\n";
        }
    }
    public enum StatusVagas : int
    {
        LocalVago = 0,
        VeiculoEstacionado = 1
    }

}
