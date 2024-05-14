using ParkHub.Models;


namespace ParkHubTests
{
    public class EstacionamentoTestes
    {
        private readonly Estacionamento _estacionamento;
        private readonly Veiculo _veiculoTeste;
        public EstacionamentoTestes()
        {
            _estacionamento = new();
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
            Assert.Throws<ArgumentNullException>(_estacionamento.ListarVeiculos);
        }
    }
}
