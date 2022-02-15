using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Infra.Data.Context;

namespace CasaDoCodigo.Infra.Data.Repository
{
    public class PaisRepository : BaseRepository<Pais>, IPaisRepository
    {
        public PaisRepository(ApplicationContext context) : base(context)
        {
        }
    }
}