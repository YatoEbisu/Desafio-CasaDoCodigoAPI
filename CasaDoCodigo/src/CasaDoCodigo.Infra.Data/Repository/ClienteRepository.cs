using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Infra.Data.Context;

namespace CasaDoCodigo.Infra.Data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationContext context) : base(context)
        {
        }
    }
}