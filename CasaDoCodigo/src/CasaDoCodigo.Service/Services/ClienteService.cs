using System;
using System.Linq;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Service.Notifications;
using CasaDoCodigo.Service.Validations;

namespace CasaDoCodigo.Service.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IPaisRepository _paisRepository;
        private readonly IEstadoRepository _estadoRepository;
        public ClienteService(IClienteRepository clienteRepository, IPaisRepository paisRepository, IEstadoRepository estadoRepository, INotifier notifier) : base(notifier)
        {
            _clienteRepository = clienteRepository;
            _paisRepository = paisRepository;
            _estadoRepository = estadoRepository;
        }
        public Cliente Insert(Cliente obj)
        {
            Validate(obj, Activator.CreateInstance<ClienteValidation>());

            if (_clienteRepository.ExistsInDatabaseAsync(y => y.Email == obj.Email).Result)
                Notify("E-mail ja cadastrado!");

            if (_clienteRepository.ExistsInDatabaseAsync(y => y.Documento == obj.Documento).Result)
                Notify("Documento ja cadastrado!");

            var estado = _estadoRepository.FindAsync(y => y.PaisId == obj.PaisId).Result.FirstOrDefault();

            if (estado != null)
                obj.EstadoId = estado.Id;

            if (!_paisRepository.ExistsInDatabaseAsync(y => y.Id == obj.PaisId).Result)
                Notify("País inexistente na base de dados!");

            if (_notifier.HaveNotification())
                return null;

            _clienteRepository.Insert(obj);
            return obj;
        }

    }
}