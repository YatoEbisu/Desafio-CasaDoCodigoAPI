using System;

namespace CasaDoCodigo.Api.DTO
{
    public class LivroResDTO
    {
        public LivroResDTO(Guid id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }
        public Guid Id { get; set; }
        public string Titulo { get; set; }
    }
}