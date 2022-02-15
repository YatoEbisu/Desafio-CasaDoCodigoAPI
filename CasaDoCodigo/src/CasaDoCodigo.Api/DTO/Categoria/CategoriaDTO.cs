using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace CasaDoCodigo.DTO
{
    public class CategoriaDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }
    }
}
