using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CasaDoCodigo.Domain.Entities;
using CasaDoCodigo.Domain.Interfaces;
using CasaDoCodigo.Service.Notifications;
using CasaDoCodigo.Service.Validations;

namespace CasaDoCodigo.Service.Services
{
    public class LivroService : BaseService<Livro>, ILivroService
    {

        private readonly ILivroRepository _livroRepository;
        private readonly IAutorRepository _autorRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        public LivroService(ILivroRepository livroRepository, IAutorRepository autorRepository, ICategoriaRepository categoriaRepository, INotifier notifier) : base(notifier)
        {
            _livroRepository = livroRepository;
            _autorRepository = autorRepository;
            _categoriaRepository = categoriaRepository;
        }

        public List<Livro> FindAll()
        {
            return _livroRepository.FindAll().Result;
        }

        public Livro FindOne(Guid id)
        {
            return _livroRepository.FindOne(id).Result;
        }

        public void Insert(Livro obj)
        {
            Validate(obj, Activator.CreateInstance<LivroValidation>());

            if (_livroRepository.ExistsInDatabaseAsync(p => p.Titulo == obj.Titulo).Result)
                Notify("Titulo ja cadastrado!");

            if (_livroRepository.ExistsInDatabaseAsync(y => y.ISBN == obj.ISBN).Result)
                Notify("ISBN ja cadastrado!");

            if (!_autorRepository.ExistsInDatabaseAsync(y => y.Id == obj.AutorId).Result)
                Notify("Autor inexistente na base de dados!");

            if (!_categoriaRepository.ExistsInDatabaseAsync(y => y.Id == obj.CategoriaId).Result)
                Notify("Categoria inexistente na base de dados!");

            if (obj.Preco < 20)
                Notify("Preço deve ser superior a 20!");

            if (obj.NrPaginas < 100)
                Notify("Número de paginas deve ser superior a 100!");

            if (obj.DataPublicacao != null && obj.DataPublicacao <= DateTime.Now)
                Notify("DataPublicacao deve ser superior a data atual");

            if (_notifier.HaveNotification())
                return;

            _livroRepository.Insert(obj);
        }
    }
}
