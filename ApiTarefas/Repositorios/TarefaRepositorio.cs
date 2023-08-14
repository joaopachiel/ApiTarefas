using ApiTarefas.Data;
using ApiTarefas.Models;
using ApiTarefas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Repositorios
{
    public class TarefaRepositorio : ITarefaRepositorio
    {
        private readonly ApiTarefasContext _context;

        public TarefaRepositorio(ApiTarefasContext apiTarefasContext)
        {
            _context = apiTarefasContext;
        }

        public async Task<TarefaModel> BuscarPorId(int id)
        {
            return await _context.Tarefas
                .Include(x => x.Usuario)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _context.Tarefas
                .Include(x => x.Usuario)
                .ToListAsync();
        }

        public async Task<TarefaModel> Adicionar(TarefaModel tarefa)
        {
            await _context.Tarefas.AddAsync(tarefa);
            await _context.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaModel> Atualizar(TarefaModel tarefa, int id)
        {
            var tarefaPorId = await BuscarPorId(id);

            if(tarefaPorId == null)
            {
                throw new Exception($"Tarefa de Id {id} não foi encontrada.");
            }

            tarefaPorId.Nome = tarefa.Nome;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            tarefaPorId.UsuarioId = tarefa.UsuarioId;

            _context.Tarefas.Update(tarefaPorId);
            await _context.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            var tarefaPorId = await BuscarPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa de Id {id} não foi encontrada.");
            }

            _context.Tarefas.Remove(tarefaPorId);
            await _context.SaveChangesAsync();

            return true;
        }

        

        
    }
}
