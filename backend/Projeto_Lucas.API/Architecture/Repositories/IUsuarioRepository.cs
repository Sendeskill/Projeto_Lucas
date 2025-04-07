using System.Collections.Generic;
using System.Threading.Tasks;
using Projeto_Lucas.API.Domain;

namespace Projeto_Lucas.API.Arquiteture.Repositories
{
    public interface IUsuarioRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(int id);
        Task<bool> UsuarioExistsAsync(string email, string cpf);
    }
}
