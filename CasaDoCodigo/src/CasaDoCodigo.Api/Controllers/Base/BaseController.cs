using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using CasaDoCodigo.Service.Notifications;

namespace CasaDoCodigo.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly INotifier _notifier;
        public BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }


        protected bool ValidOperation()
        {
            return !_notifier.HaveNotification();
        }
        protected ActionResult CustomResponseCreated(string uri = null, object result = null)
        {
            if (ValidOperation())
            {
                return Created(uri,new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });

        }

        protected ActionResult CustomResponse(object result = null)
        {
            if (ValidOperation())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notifier.GetNotifications().Select(n => n.Message)
            });

        }
        protected ActionResult CustomResponseCreated(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotifyInvalidModelError(modelState);
            return CustomResponseCreated();
        }

        protected void NotifyInvalidModelError(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);

            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotifyError(errorMsg);
            }
        }

        protected void NotifyError(string msg)
        {
            _notifier.Handle(new Notification(msg));
        }
    }
}
