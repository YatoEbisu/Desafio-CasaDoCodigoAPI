using System;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.DTO.Cliente
{
    public class ClienteReqDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public Guid? PaisId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        public string CEP { get; set; }
    }
}