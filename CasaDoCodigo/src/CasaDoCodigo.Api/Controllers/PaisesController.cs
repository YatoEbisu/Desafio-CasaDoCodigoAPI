using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CasaDoCodigo.Controllers;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.DTO.Pais;
using CasaDoCodigo.Service.Notifications;

namespace CasaDoCodigo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : BaseController
    {
        private readonly IPaisService _paisService;

        public PaisesController(IPaisService paisService,INotifier notifier) : base(notifier)
        {
            _paisService = paisService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] PaisDTO pais)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponseCreated(ModelState);

                _paisService.Insert(new Pais(pais.Nome));

                return CustomResponseCreated(nameof(Create), pais);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
