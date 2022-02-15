using System;

namespace CasaDoCodigo.DTO.Cliente
{
    public class ClienteResDTO
    {
        public ClienteResDTO(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}