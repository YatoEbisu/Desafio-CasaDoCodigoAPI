using System;
using System.Linq;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Service.Notifications;
using CasaDoCodigo.Service.Validations;

namespace CasaDoCodigo.Service.Services
{
    public class CategoriaService : BaseService<Categoria>, ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository, INotifier notifier) : base(notifier)
        {
            _categoriaRepository = categoriaRepository;
        }

        public void Insert(Categoria obj)
        {
            Validate(obj, Activator.CreateInstance<CategoriaValidation>());

            if (_categoriaRepository.ExistsInDatabaseAsync(y => y.Nome == obj.Nome).Result)
                Notify("Categoria ja cadastrada!");

            if (_notifier.HaveNotification())
                return;

            _categoriaRepository.Insert(obj);
        }
    }
}
