using ParkHub.Models;

namespace ParkHub
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bem vindo ao ParkHub!!!\n");
            Console.WriteLine("Seu sistema de estacionamento completo.");
            Console.ReadKey();

            Console.Clear();
            Console.WriteLine("Quantas vagas tem em seu estacionamento?");
            int totalVagas = int.Parse(Console.ReadLine());

            Estacionamento estacaoDeVeiculos = new(totalVagas);
            for (int i = 0; i < totalVagas; i++)
            {
                estacaoDeVeiculos.Vagas[i] = new();
            }

            Console.Clear();
            Console.WriteLine("Qual o valor da hora estacionada?");
            estacaoDeVeiculos.ValorHora = decimal.Parse(Console.ReadLine());

            do
            {
                Console.Clear();
                Console.WriteLine("O que deseja fazer?\n");
                Console.WriteLine("|Adicionar um veículo            |- 1");
                Console.WriteLine("|Remover um veículo              |- 2");
                Console.WriteLine("|Listar veículos Estacionados    |- 3");
                Console.WriteLine("|Vagas totais disponíveis        |- 4");
                Console.WriteLine("|Encerrar                        |- 5");
                int opcaoSelecionada = int.Parse(Console.ReadLine());
                try
                {
                    if (opcaoSelecionada > 0 && opcaoSelecionada <= 5)
                    {
                        switch (opcaoSelecionada)
                        {
                            case 1:
                                Console.Clear();

                                Console.WriteLine("Informe as informações do veículo a qual deseja adicionar:\n");
                                Console.Write("Placa: ");
                                string placa = Console.ReadLine();

                                Console.Write("Modelo: ");
                                string modelo = Console.ReadLine();

                                Console.Write("Cor: ");
                                string cor = Console.ReadLine();

                                estacaoDeVeiculos.NovoVeiculo = new(placa, modelo, cor);

                                Console.WriteLine("\nQual vaga esse veiculo estacionou?");
                                int localEstacionado = int.Parse(Console.ReadLine());

                                if (estacaoDeVeiculos.Vagas[localEstacionado].Status == StatusVagas.LocalVago)
                                {
                                    if (!estacaoDeVeiculos.VeiculosEstacionados.Any(x => x.Placa == estacaoDeVeiculos.NovoVeiculo.Placa) && estacaoDeVeiculos.NovoVeiculo.Placa != null)
                                    {
                                        estacaoDeVeiculos.Vagas[localEstacionado].Status = StatusVagas.VeiculoEstacionado;
                                        estacaoDeVeiculos.Vagas[localEstacionado].TempoEstacionado.Start();
                                        estacaoDeVeiculos.Vagas[localEstacionado].VeiculoEstacionado = estacaoDeVeiculos.NovoVeiculo;

                                        estacaoDeVeiculos.AdicionarVeiculo(estacaoDeVeiculos.NovoVeiculo);
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nPlaca do veículo invalida ou");
                                        Console.WriteLine("Veiculo já registrado.");
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nLocal já tem um veículo estacionado.");
                                }

                                break;
                            case 2:
                                Console.Clear();
                                Console.WriteLine("Qual a placa do veiculo que deseja remover?");
                                string plca = Console.ReadLine();

                                var veiculin = estacaoDeVeiculos.VeiculosEstacionados.Find(x => x.Placa == plca);

                                if (veiculin != null)
                                {
                                    int vaguinha = 0;
                                    for (int i = 0; i < totalVagas; i++)
                                    {
                                        if (estacaoDeVeiculos.Vagas[i].VeiculoEstacionado == veiculin)
                                        {
                                            vaguinha = i;
                                        }
                                    }

                                    estacaoDeVeiculos.VeiculosEstacionados.Remove(veiculin);

                                    if (!estacaoDeVeiculos.VeiculosEstacionados.Contains(veiculin))
                                    {
                                        Console.WriteLine("Veículo removido com Sucesso");
                                        Console.ReadKey();
                                        Console.Clear();


                                        decimal valorPendente = estacaoDeVeiculos.Vagas[vaguinha].TempoEstacionado.Elapsed.Hours;

                                        valorPendente *= estacaoDeVeiculos.ValorHora;

                                        if (valorPendente < 1)
                                        {
                                            valorPendente = estacaoDeVeiculos.ValorHora;
                                        }
                                        var tempoFormatado = $"{estacaoDeVeiculos.Vagas[vaguinha].TempoEstacionado.Elapsed.Hours:D2}:" +
                                            $"{estacaoDeVeiculos.Vagas[vaguinha].TempoEstacionado.Elapsed.Minutes:D2}:" +
                                            $"{estacaoDeVeiculos.Vagas[vaguinha].TempoEstacionado.Elapsed.Seconds:D2}";

                                        Console.WriteLine($"Tempo estacionado: {tempoFormatado}\n");
                                        Console.WriteLine($"Valor à Pagar: {valorPendente:C}");
                                        estacaoDeVeiculos.Vagas[vaguinha].Status = StatusVagas.LocalVago;
                                        Console.ReadKey();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Verifique a ortografia da placa!");
                                    Console.ReadKey();
                                }
                                break;
                            case 3:
                                Console.Clear();
                                Console.WriteLine("Listagem completa dos veículos:\n");
                                estacaoDeVeiculos.ListarVeiculos(totalVagas, estacaoDeVeiculos.Vagas);
                                Console.ReadKey();
                                break;
                            case 4:
                                Console.Clear();
                                int quantidadeVagas = 0;

                                for (int i = 0; i < totalVagas; i++)
                                {
                                    if (estacaoDeVeiculos.Vagas[i].Status == StatusVagas.LocalVago)
                                    {
                                        quantidadeVagas++;
                                        Console.WriteLine($"Local da vaga disponível: {i}");
                                    }
                                }
                                Console.WriteLine($"\nQuantidade total de vagas disponíveis: {quantidadeVagas}");
                                Console.ReadKey();
                                break;
                            case 5:
                                Console.Clear();
                                Console.WriteLine("Obrigado por usar o ParkHub.");
                                Console.WriteLine("Volte sempre :D");
                                Console.ReadKey();
                                opcaoSelecionada = 0;
                                break;
                        }
                        if (opcaoSelecionada == 0)
                            break;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Informe um número valido!");
                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.ReadKey();
                }
            } while (true);
        }
    }
}





