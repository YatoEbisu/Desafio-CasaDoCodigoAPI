using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Domain.Entities
{
    [Table("Clientes")]
    public class Cliente : BaseEntity
    {
        public Cliente(string email, string nome, string sobrenome, string documento, string endereco, string complemento, string cidade, Guid paisId, string telefone, string cep)
        {
            Email = email;
            Nome = nome;
            Sobrenome = sobrenome;
            Documento = documento;
            Endereco = endereco;
            Complemento = complemento;
            Cidade = cidade;
            PaisId = paisId;
            Telefone = telefone;
            CEP = cep;
        }

        public Cliente()
        {
        }

        public string Email { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Documento { get; set; }
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public Guid? PaisId { get; set; }
        public Pais Pais { get; set; }
        public Guid? EstadoId { get; set; }
        public Estado Estado { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
    }
}