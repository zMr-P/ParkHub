using ParkHub.Models;
using System;

namespace ParkHub
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Veiculo vei = new("MKD-149", "First", "Job");
            Estacionamento estacionamento = new();

            estacionamento.AdicionarVeiculo(vei);
            estacionamento.ListarVeiculos();
        }
    }
}