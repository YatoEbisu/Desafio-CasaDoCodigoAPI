using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CasaDoCodigo.Domain.Entities;

namespace CasaDoCodigo.Domain.Interfaces
{
    public interface ILivroRepository : IBaseRepository<Livro>
    {
        Task<List<Livro>> FindAll();
        Task<Livro> FindOne(Guid id);
    }
}