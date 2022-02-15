using System;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.DTO.Estado
{
    public class EstadoDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid? PaisId { get; set; }
    }
}