using MedTeste.Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace MedTeste.Business.DTO
{
    public class CriarContatoDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido.")]
        public DateTime DtNascimento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EnumDataType(typeof(Sexo), ErrorMessage = "Sexo inválido. Use 1 para Masculino, 2 para Feminino ou 3 para Outro.")]
        public Sexo Sexo { get; set; }
    }
}
