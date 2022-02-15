using System;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Service.Notifications;
using CasaDoCodigo.Service.Validations;

namespace CasaDoCodigo.Service.Services
{
    public class EstadoService : BaseService<Estado>, IEstadoService
    {
        private readonly IEstadoRepository _estadoRepository;
        private readonly IPaisRepository _paisRepository;
        public EstadoService(IEstadoRepository estadoRepository, IPaisRepository paisRepository, INotifier notifier) : base(notifier)
        {
            _estadoRepository = estadoRepository;
            _paisRepository = paisRepository;
        }
        public void Insert(Estado obj)
        {
            Validate(obj, Activator.CreateInstance<EstadoValidation>());

            if (!_paisRepository.ExistsInDatabaseAsync(y => y.Id == obj.PaisId).Result)
                Notify("País inexistente na base de dados!");

            if (_estadoRepository.ExistsInDatabaseAsync(y => y.Nome == obj.Nome && y.PaisId == obj.PaisId).Result)
                Notify("Estado ja cadastrado neste País!");

            if (_notifier.HaveNotification())
                return;

            _estadoRepository.Insert(obj);
        }
    }
}