using eCommerce.API.Repositories;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuariosController(IUsuarioRepository repository) 
        {
            _usuarioRepository = repository;
        }

        //{host}/api/usuarios
        [HttpGet]
        public IActionResult Get() 
        {
            var usuarios = _usuarioRepository.GetAll();

            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _usuarioRepository.Get(id);
            if(usuario == null)
                return NotFound("Não encontrado.");

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Add([FromBody]Usuario usuario)
        {
            _usuarioRepository.Add(usuario);
            
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]Usuario usuario)
        {
            _usuarioRepository.Update(usuario);

            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usuarioRepository.Delete(id);

            return Ok();
        }
    }
}
