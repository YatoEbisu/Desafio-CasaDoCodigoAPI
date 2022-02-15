using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.DTO.Pais
{
    public class PaisDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }
    }
}