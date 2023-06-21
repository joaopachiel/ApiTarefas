using ApiTarefas.Data;
using ApiTarefas.Models;
using ApiTarefas.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ApiTarefasContext _context;

        public UsuarioRepositorio(ApiTarefasContext apiTarefasContext)
        {
            _context = apiTarefasContext;
        }

        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            var usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId == null)
            {
                throw new Exception($"Usuário de Id {id} não foi encontrado.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _context.Usuarios.Update(usuarioPorId);
            await _context.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            var usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuário de Id {id} não foi encontrado.");
            }

            _context.Usuarios.Remove(usuarioPorId);
            await _context.SaveChangesAsync();

            return true;
        }

        

        
    }
}
