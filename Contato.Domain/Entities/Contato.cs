using MedTeste.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedTeste.Domain.Entities
{
    public class Contato : Entity
    {
        public string Nome { get; private set; } = string.Empty;
        public DateTime DtNascimento { get; private set; }
        public char? Sexo { get; private set; }
        [NotMapped]
        public int Idade => CalcularIdade(DtNascimento);
        public bool Ativo { get; private set; } = true;

        protected Contato() { }
        public Contato(string nome, DateTime dtNascimento, char? sexo)
        {
            Nome = nome;
            DtNascimento = dtNascimento;
            Sexo = sexo;
        }

        public static Result<Contato> CriarContato(string nome, DateTime dtNascimento, char? sexo)
        {
            var validar = ValidarContato(nome, dtNascimento, sexo);
            if (!validar.IsSuccess)
            {
                return Result<Contato>.Failure(validar.Error);
            }
                return Result<Contato>.Success(new Contato(nome, dtNascimento, sexo));
        }

        public Result<bool> AtualizarContato(string nome, DateTime dtNascimento, char? sexo)
        {
            var validar = ValidarContato(nome, dtNascimento, sexo);
            if (!validar.IsSuccess)
            {
                return Result<bool>.Failure(validar.Error);
            }

            Nome = nome;
            DtNascimento = dtNascimento;
            Sexo = sexo;

            return Result<bool>.Success(true);
        }

        private static Result<bool> ValidarContato(string nome, DateTime dtNascimento, char? sexo)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                return Result<bool>.Failure("O nome é obrigatório.");
            }

            if (dtNascimento == DateTime.MinValue)
            {
                return Result<bool>.Failure("A data de nascimento é obrigatória.");
            }

            if (!sexo.HasValue)
            {
                return Result<bool>.Failure("O Sexo é obrigatório.");
            }

            if (sexo != 'M' && sexo != 'F')
            {
                return Result<bool>.Failure("Sexo inválido. Digite 'M' ou 'F'.");
            }

            if (dtNascimento > DateTime.Today)
            {
                return Result<bool>.Failure("A data de nascimento não pode ser futura.");
            }
                
            var idade = CalcularIdade(dtNascimento);
            if (idade < 18)
            {
                return Result<bool>.Failure("O contato deve ser maior de idade.");
            }

            return Result<bool>.Success(true);
        }

        private static int CalcularIdade(DateTime data)
        {
            var hoje = DateTime.Today;
            var idade = hoje.Year - data.Year;
            if (data.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }

        public void DesativarContato()
        {
            if (!Ativo)
                return;

            Ativo = false;
        }

    }
}
