using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Controllers;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.DTO.Estado;
using CasaDoCodigo.DTO.Pais;
using CasaDoCodigo.Service.Notifications;

namespace CasaDoCodigo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : BaseController
    {
        private readonly IEstadoService _estadoService;

        public EstadosController(IEstadoService estadoService, INotifier notifier) : base(notifier)
        {
            _estadoService = estadoService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] EstadoDTO estado)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponseCreated(ModelState);

                _estadoService.Insert(new Estado(estado.Nome, estado.PaisId.Value));

                return CustomResponseCreated(nameof(Create), estado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
