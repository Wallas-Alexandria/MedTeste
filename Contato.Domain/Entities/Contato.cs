using MedTeste.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedTeste.Domain.Entities
{
    public class Contato : Entity
    {
        public string Nome { get; private set; } = string.Empty;
        public DateTime DtNascimento { get; private set; }
        public Sexo Sexo { get; private set; }
        [NotMapped]
        public int Idade
        {
            get
            {
                var hoje = DateTime.Today;
                var idade = hoje.Year - DtNascimento.Year;
                if (DtNascimento.Date > hoje.AddYears(-idade))
                {
                    idade--;
                }
                return idade;
            }
        }
        public bool Ativo { get; private set; } = true;

        protected Contato() { }
        public Contato(string nome, DateTime dtNascimento, Sexo sexo)
        {
            Nome = nome;
            DtNascimento = dtNascimento;
            Sexo = sexo;
        }

        public void AtualizarContato(string nome, DateTime dtNascimento, Sexo sexo)
        {
            ValidarContato(nome, dtNascimento, sexo);
            Nome = nome;
            DtNascimento = dtNascimento;
            Sexo = sexo;
            ValidarIdade(this.Idade);
        }

        public static Contato CriarContato(string nome, DateTime dtNascimento, Sexo sexo)
        {
            var contato = new Contato(nome, dtNascimento, sexo);

            ValidarContato(nome, dtNascimento, sexo);
            ValidarIdade(contato.Idade);

            return contato;
        }

        private static void ValidarContato(string nome, DateTime dtNascimento, Sexo sexo)
        {
            if (dtNascimento > DateTime.Today)
            {
                throw new ArgumentException("A data de nascimento não pode ser maior que a data atual.");
            }
        }

        private static void ValidarIdade(int idade)
        {

            if (idade == 0)
                throw new ArgumentException("A idade não pode ser igual a zero.");

            if (idade < 18)
                throw new ArgumentException("O contato deve ser maior de idade.");

        }

        public void DesativarContato()
        {
            if (!Ativo)
                return;

            Ativo = false;
        }

    }
}
