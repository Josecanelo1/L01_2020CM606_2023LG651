using L01_2020CM606_2023LG651.Models.Tablas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L01_2020CM606_2023LG651.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _contexto;

        public UsuariosController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Endpoint que retorna la lista de usuarios existentes
        /// </summary>
        [HttpGet]
        [Route("GetAllUsuarios")]
        public IActionResult Get()
        {
            var usuarios = (from u in _contexto.Usuarios
                          select u).ToList();
            return Ok(usuarios);
        }

        /// <summary>
        /// Endpoint que retorna un usuario por su id
        /// </summary>
        [HttpGet]
        [Route("GetUsuarioById")]
        public IActionResult GetUsuarioById(int id)
        {
            var usuario = (from u in _contexto.Usuarios
                          where u.usuarioId == id
                          select u).FirstOrDefault();
            if (usuario == null) return NotFound();
            return Ok(usuario);
        }

        /// <summary>
        /// Endpoint que crea un nuevo usuario
        /// </summary>
        [HttpPost]
        [Route("CreateUsuario")]
        public IActionResult CreateUsuario([FromBody] Usuarios usuario)
        {
            try
            {
                _contexto.Usuarios.Add(usuario);
                _contexto.SaveChanges();
                return Ok("Usuario creado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint que actualiza un usuario existente
        /// </summary>
        [HttpPut]
        [Route("UpdateUsuario")]
        public IActionResult UpdateUsuario([FromBody] Usuarios usuario)
        {
            try
            {
                _contexto.Usuarios.Update(usuario);
                _contexto.SaveChanges();
                return Ok("Usuario actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint que elimina un usuario por su id
        /// </summary>
        [HttpDelete]
        [Route("DeleteUsuario")]
        public IActionResult DeleteUsuario(int id)
        {
            var usuario = (from u in _contexto.Usuarios
                          where u.usuarioId == id
                          select u).FirstOrDefault();
            if (usuario == null) return NotFound();

            try
            {
                _contexto.Usuarios.Remove(usuario);
                _contexto.SaveChanges();
                return Ok("Usuario eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}