using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact(DisplayName = "Teste Ve�culo - Acelerar")]
        [Trait("Funcionalidade", "Acelerar")]
        public void TestaVeiculoAcelerar()
        {
            // Arrange - Prepara��o do ambiente para os testes 
            Veiculo veiculo = new Veiculo();
            // Act - M�todo que ser� testado
            veiculo.Acelerar(10);
            // Assert - Resultados obtidos com os esperados
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste Ve�culo - Frear")]
        [Trait("Funcionalidade", "Frear")]
        public void TestaVeiculoFrear()
        {
            // Arrange - Prepara��o do ambiente para os testes 
            Veiculo veiculo = new Veiculo();
            // Act - M�todo que ser� testado
            veiculo.Frear(10);
            // Assert - Resultados obtidos com os esperados
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact(DisplayName = "Teste Ve�culo - Tipo (Autom�vel)")]
        public void TestaTipoVeiculo()
        {
            // Arrange
            Veiculo veiculo = new Veiculo();
            // Act
            // Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(Skip = "Teste ainda n�o implementado - ignorar", DisplayName = "Teste Ve�culo - Tipo (Motocicleta)")]
        public void TestaTipoVeiculoMotocicleta()
        {
            // Arrange
            Veiculo veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Motocicleta;
            // Act
            // Assert
            Assert.Equal(TipoVeiculo.Automovel, veiculo.Tipo);
        }

        [Fact(DisplayName = "Teste Ve�culo - ToString (Listagem)")]
        public void TesteDadosVeiculo()
        {
            // Arrange
            Veiculo carro = new Veiculo();
            carro.Proprietario = "Livia";
            carro.Tipo = TipoVeiculo.Automovel;
            carro.Placa = "ZAP-7419";
            carro.Cor = "Azul";
            carro.Modelo = "Variante";

            // Act
            string dados = carro.ToString();

            // Assert
            Assert.Contains("Tipo do Ve�culo: Automovel", dados);
        }

        [Fact]
        public void TestaNomeProprietarioVeiculoComMenosDeTresCaracteres()
        {
            // Arrange
            string nomeProprietario = "Ab";

            // Assert
            Assert.Throws<System.FormatException>(
                // Act
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaMensagemDeEecaoDoQuartoCaractereDaPlaca()
        {
            // Arrange
            string placa = "ASDF8888";

            // Act
            FormatException messagem = Assert.Throws<System.FormatException>(
                () => new Veiculo().Placa = placa
            );

            // Assert
            Assert.Equal("O 4� caractere deve ser um h�fen", messagem.Message);
        }
    }
}
