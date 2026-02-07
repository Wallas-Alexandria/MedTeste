using MedTeste.Domain.Entities;

namespace MedTeste.Business.DTO
{
    public class ContatoDetalhesDTO
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public int Idade { get; set; }
        public char? Sexo { get; set; }
        public bool Ativo { get; set; }

    public static ContatoDetalhesDTO Map(Contato contato)
        {
            if (contato == null)
            {
                return null;
            }

            return new ContatoDetalhesDTO
            {
                Id = contato.Id,
                Nome = contato.Nome,
                DtNascimento = contato.DtNascimento,
                Idade = contato.Idade,
                Sexo = contato.Sexo,
                Ativo = contato.Ativo
            };
        }

    }
}
