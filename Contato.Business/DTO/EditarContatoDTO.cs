using MedTeste.Domain.Enum;

namespace MedTeste.Business.DTO
{
    public class EditarContatoDTO
    {
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public char? Sexo { get; set; }
    }
}
