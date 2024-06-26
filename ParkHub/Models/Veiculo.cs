﻿using System.Numerics;

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
                        if (value.Length == 8 && value.Contains("-"))
                        {
                            _placa = value;
                        }
                        else if (value.Length == 7 && !value.Contains("-"))
                        {
                            _placa = value;
                        }
                        else
                        {
                            throw new ArgumentException("\nVerifique a ortografia da placa.");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("\nPlaca está incorreta.");
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
