using System;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Service.Notifications;
using CasaDoCodigo.Service.Validations;

namespace CasaDoCodigo.Service.Services
{
    public class PaisService : BaseService<Pais>, IPaisService
    {
        private readonly IPaisRepository _paisRepository;
        public PaisService(IPaisRepository paisRepository, INotifier notifier) : base(notifier)
        {
            _paisRepository = paisRepository;
        }
        public void Insert(Pais obj)
        {
            Validate(obj, Activator.CreateInstance<PaisValidation>());

            if (_paisRepository.ExistsInDatabaseAsync(y => y.Nome == obj.Nome).Result)
                Notify("Pais ja cadastrado!");

            if (_notifier.HaveNotification())
                return;

            _paisRepository.Insert(obj);
        }

        
    }
}