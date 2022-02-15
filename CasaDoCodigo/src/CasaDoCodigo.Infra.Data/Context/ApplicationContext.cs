using CasaDoCodigo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Infra.Data.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> context) : base(context)
        {
        }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}