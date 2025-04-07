using Projeto_Lucas.API.Domain;
using Projeto_Lucas.API.Arquiteture.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projeto_Lucas.API.Arquiteture.Services
{
    public class UsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> ListarTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<User?> BuscarPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<string> CriarAsync(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Nome) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Cpf))
            {
                return "Campos obrigatórios não podem estar vazios.";
            }

            var existe = await _repository.UsuarioExistsAsync(user.Email, user.Cpf);
            if (existe)
            {
                return "Usuário com este e-mail ou CPF já existe.";
            }

            await _repository.AddAsync(user);
            return "Usuário criado com sucesso.";
        }

        public async Task<string> AtualizarAsync(User user)
        {
            await _repository.UpdateAsync(user);
            return "Usuário atualizado com sucesso.";
        }

        public async Task<string> DeletarAsync(int id)
        {
            await _repository.DeleteAsync(id);
            return "Usuário deletado com sucesso.";
        }
    }
}
