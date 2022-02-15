using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Domain.Entities
{
    [Table("Categorias")]
    public class Categoria : BaseEntity
    {
        public Categoria(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}
