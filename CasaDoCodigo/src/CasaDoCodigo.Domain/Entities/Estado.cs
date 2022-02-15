using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Domain.Entities
{
    [Table("Estados")]
    public class Estado : BaseEntity
    {
        public Estado(string nome, Guid paisId)
        {
            Nome = nome;
            PaisId = paisId;
        }
        public string Nome { get; set; }
        public Guid PaisId { get; set; }
    }
}