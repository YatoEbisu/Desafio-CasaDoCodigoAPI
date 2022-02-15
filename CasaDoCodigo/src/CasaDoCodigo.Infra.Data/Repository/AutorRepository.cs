using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Infra.Data.Context;

namespace CasaDoCodigo.Infra.Data.Repository 
{
    public class AutorRepository : BaseRepository<Autor>, IAutorRepository
    {
        public AutorRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
