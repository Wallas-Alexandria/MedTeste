using MedTeste.Domain.Enum;

namespace MedTeste.Business.DTO
{
    public class CriarContatoDTO
    {
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public Sexo Sexo { get; set; }
    }
}
