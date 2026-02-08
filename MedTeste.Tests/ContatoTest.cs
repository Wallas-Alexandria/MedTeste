using MedTeste.Domain.Entities;

namespace MedTeste.Tests
{
    public class ContatoTest
    {
        [Fact]
        public void CriarContato_QuandoDadosValido_RetornaContato()
        {
            // Arrange
            var nome = "Marechal Deodoro da Fonseca";
            var dataNascimento = DateTime.Today.AddYears(-30);
            var genero = 'M';

            // Act
            var contato = Contato.CriarContato(nome, dataNascimento, genero);
            var result = contato.Data;

            // Assert
            Assert.True(contato.IsSuccess);
            Assert.NotNull(contato);
            Assert.Equal(nome, result.Nome);
            Assert.Equal(dataNascimento, result.DtNascimento);
            Assert.Equal(genero, result.Sexo);
            Assert.True(result.Ativo);
        }

        [Fact]
        public void CriarContato_QuandoNomeVazio_RetornaErro()
        {
            // Arrange
            var nome = "";
            var dataNascimento = DateTime.Today.AddYears(-30);
            var genero = 'M';

            // Act
            var result = Contato.CriarContato(nome, dataNascimento, genero);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("O nome é obrigatório.", result.Error);
        }

        [Fact]
        public void CriarContato_QuandoDataEstiverFutura_RetornaErro()
        {
            // Arrange
            var nome = "Floriano Peixoto";
            var dataNascimento = DateTime.Today.AddYears(+1);
            var genero = 'M';

            // Act
            var result = Contato.CriarContato(nome, dataNascimento, genero);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("A data de nascimento não pode ser futura.", result.Error);
        }

        [Fact]
        public void CriarContato_QuandoIdadeIgual0_RetornaErro()
        {
            // Arrange
            var nome = "Juscelino Kubitschek";
            var dataNascimento = DateTime.Today;
            var genero = 'M';

            // Act
            var result = Contato.CriarContato(nome, dataNascimento, genero);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Idade não pode ser igual a zero.", result.Error);

        }

        [Fact]
        public void CriarContato_QuandoIdadeMenor18_RetornaErro()
        {
            // Arrange
            var nome = "Tancredo Neves";
            var dataNascimento = DateTime.Today.AddYears(-17);
            var genero = 'M';

            // Act
            var result = Contato.CriarContato(nome, dataNascimento, genero);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("O contato deve ser maior de idade.", result.Error);

        }

        [Fact]
        public void CriarContato_QuandoGeneroInvalido_RetornaErro()
        {
            // Arrange
            var nome = "Fernando Collor";
            var dataNascimento = DateTime.Today.AddYears(-25);
            var genero = 'X';

            // Act
            var result = Contato.CriarContato(nome, dataNascimento, genero);

            // Assert
            Assert.False(result.IsSuccess);
            Assert.Equal("Sexo inválido. Digite 'M' ou 'F'.", result.Error);

        }

        [Fact]
        public void DesativarContato_QuandoContatoAtivo_ContatoFicaInativo()
        {
            // Arrange
            var contato = Contato.CriarContato("Luiz Inácio Lula da Silva", DateTime.Today.AddYears(-28), 'M');
            var result = contato.Data;

            // Act
            result.DesativarContato();

            // Assert
            Assert.False(result.Ativo);

        }

        [Fact]
        public void AtualizarContato_QuandoDadosValidos_ContatoAtualizado()
        {
            // Arrange
            var contato = Contato.CriarContato("Jair Bolsonaro", DateTime.Today.AddYears(-32), 'M');
            var result = contato.Data;

            var novoNome = "Dilma Rousseff";
            var novaDataNascimento = DateTime.Today.AddYears(-33);
            var novoGenero = 'F';

            // Act
            var atualizarResult = result.AtualizarContato(novoNome, novaDataNascimento, novoGenero);

            // Assert
            Assert.True(atualizarResult.IsSuccess);
            Assert.Equal(novoNome, result.Nome);
            Assert.Equal(novaDataNascimento, result.DtNascimento);
            Assert.Equal(novoGenero, result.Sexo);

        }
    }
}