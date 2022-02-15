using System;
using System.Linq;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Service.Notifications;
using CasaDoCodigo.Service.Validations;

namespace CasaDoCodigo.Service.Services
{
    public class AutorService : BaseService<Autor>, IAutorService
    {
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository, INotifier notifier) : base(notifier)
        {
            _autorRepository = autorRepository;
        }

        public void Insert(Autor obj)
        {
            Validate(obj, Activator.CreateInstance<AutorValidation>());

            if (_autorRepository.ExistsInDatabaseAsync(y => y.Email == obj.Email).Result)
                Notify("Email ja cadastrado!");

            if (_notifier.HaveNotification())
                return;

            _autorRepository.Insert(obj);
        }
    }
}