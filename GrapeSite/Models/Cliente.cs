using System;
using System.ComponentModel.DataAnnotations;

namespace GrapeSite.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ\s]+$", ErrorMessage = "O campo Nome deve conter apenas letras.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo E-mail deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O campo E-mail deve conter um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "O campo Telefone deve conter apenas números e ter entre 10 e 15 dígitos.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O campo CPF deve conter 11 dígitos.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "O campo Senha deve ter no mínimo 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[\W_]).+$", ErrorMessage = "A senha deve conter pelo menos uma letra, um número e um caractere especial.")]
        public string Senha { get; set; }
    }
}
