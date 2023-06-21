using ApiTarefas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Data
{
    public class ApiTarefasContext : DbContext
    {
        public ApiTarefasContext(DbContextOptions<ApiTarefasContext> options)
            : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            base.OnModelCreating(modelBuilder);
        }
    }
}
