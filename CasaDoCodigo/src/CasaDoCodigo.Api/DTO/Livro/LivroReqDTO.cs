using System;
using System.ComponentModel.DataAnnotations;
using CasaDoCodigo.Api.Extensions;
using CasaDoCodigo.Domain.Entities;

namespace CasaDoCodigo.Api.DTO
{
    public class LivroReqDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(500, ErrorMessage = "O campo {0} não pode ultrapassar {1} caracteres.")]
        public string Resumo { get; set; }

        public string Sumario { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public decimal Preco { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public int NrPaginas { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string ISBN { get; set; }

        public DateTime? DataPublicacao { get; set; }
      
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid? CategoriaId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid? AutorId { get; set; }
    }
}
