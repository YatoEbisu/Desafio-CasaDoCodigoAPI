using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Infra.Data.Repository
{
    public class LivroRepository : BaseRepository<Livro>, ILivroRepository
    {
        private readonly ApplicationContext _context;
        public LivroRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Livro>> FindAll()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro> FindOne(Guid id)
        {
            return await _context.Livros.Where(y => y.Id == id).Include(y => y.Autor).Include(y => y.Categoria).FirstOrDefaultAsync();
        }
    }
}
