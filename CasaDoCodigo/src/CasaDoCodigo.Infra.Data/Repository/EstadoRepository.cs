using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Infra.Data.Context;

namespace CasaDoCodigo.Infra.Data.Repository
{
    public class EstadoRepository : BaseRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(ApplicationContext context) : base(context)
        {
        }
    }
}