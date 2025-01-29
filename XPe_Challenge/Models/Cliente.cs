using System.ComponentModel.DataAnnotations;

namespace XPe_Challenge.Models
{
    public class Cliente
    {

        protected Cliente() { }

        public Cliente(string nome, string email, string cpf, string telefone, DateTime? dataNascimento = null)
        {
            Nome = nome;
            Email = email;
            CPF = cpf;
            Telefone = telefone;
            DataNascimento = dataNascimento;

            DataCriacao = DateTime.UtcNow;
            Ativo = true;
            Deleted = false;
        }

        [Key]
        public int Id { get; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Nome pode conter no máximo 100 caracteres.")]
        public string Nome { get; private set; }

        [MaxLength(200, ErrorMessage = "O Email pode conter no máximo 200 caracteres.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; private set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "CPF deve conter exatamente 11 dígitos numéricos.")]
        public string CPF { get; private set; }

        [Phone(ErrorMessage = "Telefone em formato inválido.")]
        [MaxLength(15, ErrorMessage = "O Telefone pode conter no máximo 15 caracteres.")]
        public string Telefone { get; private set; }

        [DataType(DataType.Date, ErrorMessage = "Data de Nascimento em formato inválido.")]
        public DateTime? DataNascimento { get; private set; }

        [DataType(DataType.DateTime)]
        public DateTime DataCriacao { get; private set; }

        public bool Ativo { get; private set; }

        public bool Deleted { get; private set; }

        public void AtualizarDados(string nome, string email, string telefone, DateTime? dataNascimento)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            DataNascimento = dataNascimento;
        }

        public void Inativar()
        {
            Ativo = false;
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Excluir()
        {
            Deleted = true;
        }
    }
}
