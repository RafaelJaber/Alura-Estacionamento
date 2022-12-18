using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void TestaVeiculoAcelerar()
        {
            // Arrange - Prepara��o do ambiente para os testes 
            Veiculo veiculo = new Veiculo();
            // Act - M�todo que ser� testado
            veiculo.Acelerar(10);
            // Assert - Resultados obtidos com os esperados
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaVeiculoFrear()
        {
            // Arrange - Prepara��o do ambiente para os testes 
            Veiculo veiculo = new Veiculo();
            // Act - M�todo que ser� testado
            veiculo.Frear(10);
            // Assert - Resultados obtidos com os esperados
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void TestaTipoVeiculo()
        {
            // Arrange
            Veiculo veiculo = new Veiculo();
            // Act
            // Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Teste ainda n�o implementado - ignorar")]
        public void TestaTipoVeiculoMotocicleta()
        {
            // Arrange
            Veiculo veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Motocicleta;
            // Act
            // Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }
    }
}
