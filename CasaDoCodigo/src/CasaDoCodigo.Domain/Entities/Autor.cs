using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Domain.Entities
{
    [Table("Autores")]
    public class Autor: BaseEntity
    {
        public Autor(string email, string nome, string descricao)
        {
            Email = email;
            Nome = nome;
            Descricao = descricao;
            DataCriacao = DateTime.Now;
        }
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}