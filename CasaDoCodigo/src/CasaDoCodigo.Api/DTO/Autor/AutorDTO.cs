using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.DTO
{
    public class AutorDTO
    {
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(400, ErrorMessage = "O campo {0} não pode ultrapassar {1} caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "O campo {0} não pode ultrapassar {1} caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(400, ErrorMessage = "O campo {0} não pode ultrapassar {1} caracteres.")]
        public string Descricao { get; set; }
    }
}