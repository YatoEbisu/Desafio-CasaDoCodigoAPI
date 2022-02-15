using CasaDoCodigo.Service.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace CasaDoCodigo.Service.Services
{
    public class BaseService<T>
    {
        protected readonly INotifier _notifier;
        public BaseService(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }
        protected void Notify(string msg)
        {
            _notifier.Handle(new Notification(msg));
        }
        protected bool Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
            {
                Notify("Registros não detectados!");
                return false;
            }

            var result =  validator.Validate(obj);

            if (result.IsValid) return true;
                
            Notify(result);
            return false;
        }
    }
}
