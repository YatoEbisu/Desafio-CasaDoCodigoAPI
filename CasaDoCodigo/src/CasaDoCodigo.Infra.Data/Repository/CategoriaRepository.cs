using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Infra.Data.Context;

namespace CasaDoCodigo.Infra.Data.Repository
{
    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
