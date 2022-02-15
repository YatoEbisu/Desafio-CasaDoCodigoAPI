using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.DTO;

namespace CasaDoCodigo.Api.DTO
{
    public class LivroDetailDTO
    {
        public string Titulo { get; set; }

        public string Resumo { get; set; }

        public string Sumario { get; set; }

        public decimal Preco { get; set; }


        public int NrPaginas { get; set; }

        public string ISBN { get; set; }

        public DateTime? DataPublicacao { get; set; }

        public CategoriaDTO Categoria { get; set; }

        public AutorDTO Autor { get; set; }
    }
}
