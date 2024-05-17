using ParkHub.Models;


namespace ParkHubTests
{
    public class EstacionamentoTests
    {
        private readonly Estacionamento _estacionamento;
        private readonly Veiculo _veiculoTeste;
        public EstacionamentoTests()
        {
            _estacionamento = new(2);
            _veiculoTeste = new Veiculo("Minha", "Sonhada", "Vaga");
            
        }

        [Fact]
        public void DeveAdicionarVeiculoNaListaERetornarSucesso()
        {
            bool resultadoEsperado = true;
            bool resultado = false;

            _estacionamento.AdicionarVeiculo(_veiculoTeste);

            if (_estacionamento.VeiculosEstacionados.Contains(_veiculoTeste))
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }

            Assert.Equal(resultadoEsperado, resultado);
        }

        [Fact]
        public void DeveRemoverVeiculoNaListaERetornarSucesso()
        {
            bool resultadoEsperado = true;
            bool resultado = false;

            _estacionamento.RemoverVeiculo(_veiculoTeste);

            if (!_estacionamento.VeiculosEstacionados.Contains(_veiculoTeste))
            {
                resultado = true;
            }
            else
            {
                resultado = false;
            }
            Assert.Equal(resultadoEsperado, resultado);
        }
        [Fact]
        public void NaoDeveListarVeiculosERetornarExcecao()
        {
            int quantidadeVagas = 5;
            _estacionamento.VeiculosEstacionados.Clear();

            Assert.Throws<ArgumentNullException>(() => _estacionamento.ListarVeiculos(quantidadeVagas, _estacionamento.Vagas));
        }

    }
}
