using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto_Lucas.API.Arquiteture.Services;
using Projeto_Lucas.API.Domain;

namespace Projeto_Lucas.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var usuarios = await _service.ListarTodosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var usuario = await _service.BuscarPorIdAsync(id);
            if (usuario == null)
                return NotFound("Usuário não encontrado.");
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Create(User user)
        {
            var resultado = await _service.CriarAsync(user);
            if (resultado != "Usuário criado com sucesso.")
                return BadRequest(resultado);
            return Ok(resultado);
        }

        [HttpPut]
        public async Task<ActionResult> Update(User user)
        {
            var resultado = await _service.AtualizarAsync(user);
            return Ok(resultado);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var resultado = await _service.DeletarAsync(id);
            return Ok(resultado);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            if (login.Email == "teste@email.com" && login.Senha == "1234")
            {
                return Ok(new { mensagem = "O login deu certo!" });
            }

            return Unauthorized(new { mensagem = "Email ou senha inválidos!" });
        }

    }
}
