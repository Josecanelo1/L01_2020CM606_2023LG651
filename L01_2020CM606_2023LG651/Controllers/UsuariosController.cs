using L01_2020CM606_2023LG651.Models;
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

            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
            return Ok("Usuario creado exitosamente");
        }

        /// <summary>
        /// Endpoint que actualiza un usuario existente
        /// </summary>
        [HttpPut]
        [Route("UpdateUsuario")]
        public IActionResult UpdateUsuario([FromBody] Usuarios usuario)
        {

            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
            return Ok("Usuario actualizado exitosamente");
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

            _contexto.Usuarios.Remove(usuario);
            _contexto.SaveChanges();
            return Ok("Usuario eliminado exitosamente");

        }

        /// <summary>
        /// Endpoint que retorna el TOP N de usuarios con más comentarios
        /// </summary>
        /// <param name="topN">Cantidad de usuarios a mostrar</param>
        [HttpGet]
        [Route("GetTopNUsuariosByComentarios/{topN}")]
        public IActionResult GetTopNUsuariosByComentarios(int topN)
        {
            if (topN <= 0)
            {
                return BadRequest("El número debe ser mayor a 0");
            }

            var topUsuarios = (from c in _contexto.Comentarios
                               group c by c.usuarioId into g
                               select new
                               {
                                   UsuarioId = g.Key,
                                   TotalComentarios = g.Count()
                               })
                            .Take(topN)
                            .ToList();
            return Ok(topUsuarios);
        }

        /// <summary>
        /// Endpoint que filtra usuarios por nombre y apellido
        /// </summary>
        /// <param name="filtro">Texto a buscar en nombre o apellido</param>
        [HttpGet]
        [Route("FindByNombreApellido/{filtro}")]
        public IActionResult FindByNombreApellido(string filtro)
        {
            var usuarios = (from u in _contexto.Usuarios
                            where u.nombre.Contains(filtro) ||
                                  u.apellido.Contains(filtro)
                            select u).ToList();

            if (!usuarios.Any())
            {
                return NotFound($"No se encontraron usuarios que contengan '{filtro}' en su nombre o apellido");
            }
            return Ok(usuarios);
        }

        /// <summary>
        /// Endpoint que filtra usuarios por rol
        /// </summary>
        /// <param name="rolId">ID del rol a filtrar</param>
        [HttpGet]
        [Route("FindByRol/{rolId}")]
        public IActionResult FindByRol(int rolId)
        {
            var usuarios = (from u in _contexto.Usuarios
                            where u.rolId == rolId
                            select u).ToList();

            if (!usuarios.Any())
            {
                return NotFound($"No se encontraron usuarios con el rol ID: {rolId}");
            }
            return Ok(usuarios);
        }
    }
}