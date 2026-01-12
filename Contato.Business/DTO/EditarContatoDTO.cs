using MedTeste.Domain.Enum;
using System.Text.Json.Serialization;

namespace MedTeste.Business.DTO
{
    public class EditarContatoDTO
    {
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DtNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public bool Ativo { get; set; }
    }
}
