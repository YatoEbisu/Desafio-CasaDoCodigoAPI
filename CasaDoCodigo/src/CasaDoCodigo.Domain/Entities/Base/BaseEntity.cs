using System;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Domain.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
    }
}