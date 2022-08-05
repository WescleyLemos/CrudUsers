using Microsoft.AspNetCore.Mvc;
using ProjetoConfitec.Models;
using ProjetoConfitec.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjetoConfitec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private UsuariosRepository _usuarioRepository;

        public UsuariosController([FromServices] UsuariosRepository usuariosRepository)
        {
            _usuarioRepository = usuariosRepository;
        }

        // GET: api/<UsuariosController>
        [HttpGet]
        public async Task<IEnumerable<Usuarios>> Get() => await _usuarioRepository.ObterTodos();

        // GET api/<UsuariosController>/5
        [HttpGet("{id}")]
        public async Task<Usuarios> Get(Guid id) => await _usuarioRepository.ObterPorId(id);


        // POST api/<UsuariosController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Usuarios usuario)
        {
            var sucess = await _usuarioRepository.Adicionar(usuario);
            if (sucess) return Ok();
            return BadRequest();
        }

        // PUT api/<UsuariosController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Usuarios usuario)
        {
            var sucess = await _usuarioRepository.Atualizar(usuario);
            if (sucess) return Ok();
            return BadRequest();
        }

        // DELETE api/<UsuariosController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var sucess = await _usuarioRepository.Remover(id);
            if (sucess) return Ok();
            return BadRequest();
        }
    }
}
