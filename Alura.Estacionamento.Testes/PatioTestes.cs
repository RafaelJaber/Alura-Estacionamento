using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Alura.Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact(DisplayName = "Teste Patio - Faturamento (Automóvel)")]
        public void ValidaFaturamentoAutomovel()
        {
            // Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = "Rafael Jáber";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ASD-9999";
            
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Fact(DisplayName = "Teste Patio - Faturamento (Motocicleta)")]
        public void ValidaFaturamentoMotocicleta()
        {
            // Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = "Rafael Jáber";
            veiculo.Tipo = TipoVeiculo.Motocicleta;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Biz";
            veiculo.Placa = "ASD-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(1, faturamento);
        }

        [Theory(DisplayName = "Teste Patio - Faturamento (Automóvel) - Multiplos")]
        [InlineData("Rafael", "ASD-1498", "Preto", "M3")]
        [InlineData("Lívia", "ASD-1499", "Azul", "Audi A8")]
        [InlineData("Juliana", "ASD-1490", "Prata", "Corolla")]
        public void ValidaFaturamentoComVariosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            // Act
            double faturamento = estacionamento.TotalFaturado();

            // Assert
            Assert.Equal(2, faturamento);
        }

        [Theory(DisplayName = "Teste Patio - Localizar por Placa")]
        [InlineData("Rafael", "ASD-1498", "Preto", "M3")]
        [InlineData("Lívia", "ASD-1499", "Azul", "Audi A8")]
        [InlineData("Juliana", "ASD-1490", "Prata", "Corolla")]
        public void LocalizaVeiculoNoPatio(string proprietario, string placa, string cor, string modelo)
        {
            // Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = proprietario;
            veiculo.Placa = placa;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            // Act
            Veiculo consultado = estacionamento.PesquisaVeiculo(veiculo.IdTicket);

            // Assert
            Assert.Equal(veiculo.IdTicket, consultado.IdTicket);
        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            // Arrange
            Patio estacionamento = new Patio();
            Veiculo veiculo = new Veiculo();
            veiculo.Proprietario = "Rafael Jáber";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Azul";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ASD-9999";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            Veiculo veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Rafael Jáber";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Preto"; // Alterado
            veiculoAlterado.Modelo = "Fusca";
            veiculoAlterado.Placa = "ASD-9999";

            // Act
            Veiculo alterado = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            // Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);
        }
    }
}
