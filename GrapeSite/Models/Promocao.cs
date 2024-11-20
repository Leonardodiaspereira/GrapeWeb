using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GrapeSite.Models
{
    [Table("promocoes")]  // tabela do banco
    public class Promocao
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo E-mail deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O campo E-mail deve conter um endereço de e-mail válido.")]
        public string Email { get; set; }

        [Column("data_inscricao")]
        public DateTime DataInscricao { get; set; }
    }
}
