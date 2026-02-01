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

        public void AtualizarContato(string nome, DateTime dtNascimento, Sexo sexo, bool ativo)
        {
            Nome = nome;
            DtNascimento = dtNascimento;
            Sexo = sexo;
            Ativo = ativo;
        }

        public static Contato CriarContato(string nome, DateTime dtNascimento, Sexo sexo)
        {
            return new Contato(nome, dtNascimento, sexo);
        }

    }
}
