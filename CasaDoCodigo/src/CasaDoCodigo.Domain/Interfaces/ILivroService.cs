using System;
using System.Collections.Generic;
using CasaDoCodigo.Domain.Entities;

namespace CasaDoCodigo.Domain.Interfaces
{
    public interface ILivroService
    {
        void Insert(Livro obj);
        List<Livro> FindAll();
        Livro FindOne(Guid id);
    }
}