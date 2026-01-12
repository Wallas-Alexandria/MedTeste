using MedTeste.Business.DTO;
using MedTeste.Domain.Enum;

namespace MedTeste.Business.Validacao
{
    public class ValidacaoContato
    {
        public static Resultado ValidarContato(CriarContatoDTO contato)
        {
            var resultado = new Resultado();

            var hoje = DateTime.Today;
            var idade = hoje.Year - contato.DtNascimento.Year;

            if (string.IsNullOrWhiteSpace(contato.Nome))
            {
                resultado.AdicionarErro("Nome é obrigatório.");
            }

            if (contato.DtNascimento == DateTime.MinValue)
            {
                resultado.AdicionarErro("Data de nascimento é obrigatória.");
            }

            if (idade < 18)
            {
                resultado.AdicionarErro("Somente maior de idade!");
            }
            if (idade > 110)
            {
                resultado.AdicionarErro("Idade não pode ser maior que 110 anos.");
            }

            if (contato.Sexo != Sexo.Masculino && contato.Sexo != Sexo.Feminino && contato.Sexo != Sexo.Outro)
            {
                resultado.AdicionarErro("Sexo é inválido. Use 1 para Masculino, 2 para Feminino ou 3 para Outro.");
            }

            return resultado;
        }

        public static Resultado ValidarContatoEditado(EditarContatoDTO contato)
        {
            var resultado = new Resultado();

            var hoje = DateTime.Today;
            var idade = hoje.Year - contato.DtNascimento.Year;

            if (string.IsNullOrWhiteSpace(contato.Nome))
            {
                resultado.AdicionarErro("Nome é obrigatório.");
            }

            if (contato.DtNascimento == DateTime.MinValue)
            {
                resultado.AdicionarErro("Data de nascimento é obrigatória.");
            }

            if (idade < 18)
            {
                resultado.AdicionarErro("Somente maior de idade!");
            }
            if (idade > 110)
            {
                resultado.AdicionarErro("Idade não pode ser maior que 110 anos.");
            }

            if (contato.Sexo != Sexo.Masculino && contato.Sexo != Sexo.Feminino && contato.Sexo != Sexo.Outro)
            {
                resultado.AdicionarErro("Sexo é inválido. Use 1 para Masculino, 2 para Feminino ou 3 para Outro.");
            }

            return resultado;
        }

        public class Resultado
        {
            public List<string> Erros { get; set; } = new List<string>();
            public bool IsValid => !Erros.Any();

            public void AdicionarErro(string mensagem)
            {
                Erros.Add(mensagem);
            }
        }

    }
}