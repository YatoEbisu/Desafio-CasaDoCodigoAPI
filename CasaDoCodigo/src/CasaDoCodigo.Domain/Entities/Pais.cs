using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Domain.Entities
{
    [Table("Paises")]
    public class Pais : BaseEntity
    {
        public Pais(string nome)
        {
            Nome = nome;
        }
        public string Nome { get; set; }
    }
}