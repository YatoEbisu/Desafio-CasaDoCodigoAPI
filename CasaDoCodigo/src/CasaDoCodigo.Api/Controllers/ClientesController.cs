using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Controllers;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.DTO.Cliente;
using CasaDoCodigo.DTO.Pais;
using CasaDoCodigo.Service.Notifications;

namespace CasaDoCodigo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : BaseController
    {
        private readonly IClienteService _clienteService;
        public ClientesController(IClienteService clienteService, INotifier notifier) : base(notifier)
        {
            _clienteService = clienteService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] ClienteReqDTO cliente)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponseCreated(ModelState);

                var result = _clienteService.Insert(new Cliente(
                    cliente.Email,
                    cliente.Nome,
                    cliente.Sobrenome,
                    cliente.Documento,
                    cliente.Endereco,
                    cliente.Complemento,
                    cliente.Cidade,
                    cliente.PaisId.Value,
                    cliente.Telefone,
                    cliente.CEP
                    ));

                return CustomResponseCreated(nameof(Create), result == null ? null :new ClienteResDTO(result.Id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

       
    }
}
