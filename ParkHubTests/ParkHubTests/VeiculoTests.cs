using ParkHub.Models;

namespace ParkHubTests
{
    public class VeiculoTests
    {
        private readonly Veiculo _veiculoTeste;
        public VeiculoTests()
        {
            _veiculoTeste = new Veiculo("","","");
        }

        [Fact]
        public void DeveVerificarPlacaVeiculoERetornarSucesso()
        {
            _veiculoTeste.Placa = "MKD-2231";

            Assert.True(_veiculoTeste.Placa == "MKD-2231");
        }
        [Fact]
        public void DeveVerificartPlacaVeiculoERetornarFalha()
        {
            _veiculoTeste.Placa = "MKD-s3457";

            Assert.False(_veiculoTeste.Placa == "MKD-s3457");
        }
    }
}
