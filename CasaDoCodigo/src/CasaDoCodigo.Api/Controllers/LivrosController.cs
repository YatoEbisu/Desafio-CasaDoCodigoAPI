using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CasaDoCodigo.Api.DTO;
using CasaDoCodigo.Controllers;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.DTO;
using CasaDoCodigo.Service.Notifications;

namespace CasaDoCodigo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : BaseController
    {
        private readonly ILivroService _livroService;

        public LivrosController(ILivroService livroService, INotifier notifier) : base(notifier)
        {
            _livroService = livroService;
        }

        [HttpGet]
        public IActionResult FindAll()
        {
            try
            {
                var livros = _livroService.FindAll();
                var livrosRes = new List<LivroResDTO>();

                livros.ForEach(y =>
                    livrosRes.Add(new LivroResDTO(y.Id, y.Titulo))
                );

                return CustomResponse(livrosRes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("Detail/{id:guid}")]
        public IActionResult FindAll([FromRoute] Guid id)
        {
            try
            {
                var livro = _livroService.FindOne(id);

                if (livro == null)
                    return NotFound(new
                    {
                        success = false,
                        errors = new[] { "Livro não encontrado" }
                    });

                return CustomResponse(new LivroDetailDTO
                {
                    Titulo = livro.Titulo,
                    Resumo = livro.Resumo,
                    Sumario = livro.Sumario,
                    Preco = livro.Preco,
                    NrPaginas = livro.NrPaginas,
                    ISBN = livro.ISBN,
                    DataPublicacao = livro.DataPublicacao,
                    Categoria = new CategoriaDTO
                    {
                        Nome = livro.Categoria.Nome,
                    },
                    Autor = new AutorDTO
                    {
                        Nome = livro.Autor.Nome,
                        Descricao = livro.Autor.Descricao,
                        Email = livro.Autor.Email
                    }
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody] LivroReqDTO livro)
        {
            try
            {
                if (!ModelState.IsValid) return CustomResponseCreated(ModelState);

                _livroService.Insert(new Livro(livro.Titulo, livro.Resumo, livro.Preco, livro.NrPaginas, livro.ISBN)
                {
                    Sumario = livro.Sumario,
                    DataPublicacao = livro.DataPublicacao,
                    CategoriaId = livro.CategoriaId.Value,
                    AutorId = livro.AutorId.Value
                });

                return CustomResponseCreated(nameof(Create), livro);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
    }
}
