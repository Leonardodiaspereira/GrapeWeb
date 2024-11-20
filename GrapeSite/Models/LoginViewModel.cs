using System.ComponentModel.DataAnnotations;

namespace GrapeSite.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O campo E-mail deve conter um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "O campo Senha deve ter no mínimo 8 caracteres.")]
        public string Senha { get; set; }
    }
}
