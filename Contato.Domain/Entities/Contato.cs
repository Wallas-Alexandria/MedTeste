using MedTeste.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedTeste.Domain.Entities
{
    public class Contato : Entity
    {
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public Sexo Sexo { get; set; }
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
        public bool Ativo { get; set; } = true;

    }
}
