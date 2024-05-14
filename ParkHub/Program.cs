using ParkHub.Models;
using System;

namespace ParkHub
{
    internal class Program
    {
        public static void Main(string[] args)
        {
    
            Estacionamento estacionamento = new();

           
            estacionamento.ListarVeiculos();
        }
    }
}