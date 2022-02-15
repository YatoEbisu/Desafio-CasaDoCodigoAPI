using System;
using CasaDoCodigo.Controllers;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.DTO;
using CasaDoCodigo.Service.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : BaseController
    {
        private readonly IAutorService _autorService;
        
        public AutoresController(IAutorService autorService, INotifier _notifier) : base(_notifier)
        {
            _autorService = autorService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] AutorDTO autor)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponseCreated(ModelState);

                _autorService.Insert(new Autor(autor.Email, autor.Nome, autor.Descricao));
                return CustomResponseCreated(nameof(Create), autor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
