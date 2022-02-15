using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasaDoCodigo.Domain.Entities
{
    [Table("Livros")]
    public class Livro : BaseEntity
    {
        public Livro(string titulo, string resumo, decimal preco, int nrPaginas, string isbn)
        {
            Titulo = titulo;
            Resumo = resumo;
            Preco = preco;
            NrPaginas = nrPaginas;
            ISBN = isbn;
        }

        public Livro()
        {
        }
        public string Titulo { get; set; }
        public string Resumo { get; set; }
        public string Sumario { get; set; }
        public decimal Preco { get; set; }
        public int NrPaginas { get; set; }
        public string ISBN { get; set; }
        public DateTime? DataPublicacao { get; set; }

        public Guid CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public Guid AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
