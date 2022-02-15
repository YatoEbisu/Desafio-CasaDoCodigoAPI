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
    public class CategoriasController : BaseController
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriasController(ICategoriaService categoriaService, INotifier notifier) : base(notifier)
        {
            _categoriaService = categoriaService;
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] CategoriaDTO categoria)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponseCreated(ModelState);

                _categoriaService.Insert(new Categoria(categoria.Nome));
                return CustomResponseCreated(nameof(Create), categoria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
