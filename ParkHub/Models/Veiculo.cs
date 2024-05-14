using System.Numerics;

namespace ParkHub.Models
{
    public class Veiculo
    {
        private string _placa;
        public string Modelo { get; set; }
        public string Cor { get; set; }
        public string Placa
        {
            get { return _placa; }
            set
            {
                try
                {
                    if (value.Length >= 7 && value.Length <= 8)
                    {
                        if (value.Length == 8 && value.Contains("-") || value.Length == 7)
                        {
                            _placa = value;
                        }
                        else
                        {
                            throw new ArgumentException("Verifique a ortografia da placa.");
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException("Placa está incorreta.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public Veiculo(string placa, string modelo, string cor)
        {
            Placa = placa;
            Modelo = modelo;
            Cor = cor;
        }
    }
}
