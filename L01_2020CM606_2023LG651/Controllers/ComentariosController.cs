using L01_2020CM606_2023LG651.Models;
using L01_2020CM606_2023LG651.Models.Tablas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L01_2020CM606_2023LG651.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentariosController : ControllerBase
    {
        private readonly ApplicationDbContext _contexto;

        public ComentariosController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Endpoint que retorna la lista de comentarios existentes
        /// </summary>
        [HttpGet]
        [Route("GetAllComentarios")]
        public IActionResult Get()
        {
            var comentarios = (from c in _contexto.Comentarios
                               select c).ToList();
            return Ok(comentarios);
        }

        /// <summary>
        /// Endpoint que retorna un comentario por su id
        /// </summary>
        [HttpGet]
        [Route("GetComentarioById")]
        public IActionResult GetComentarioById(int id)
        {
            var comentario = (from c in _contexto.Comentarios
                              where c.cometarioId == id
                              select c).FirstOrDefault();
            if (comentario == null) return NotFound();
            return Ok(comentario);
        }

        /// <summary>
        /// Endpoint que crea un nuevo comentario
        /// </summary>
        [HttpPost]
        [Route("CreateComentario")]
        public IActionResult CreateComentario([FromBody] Comentarios comentario)
        {
            _contexto.Comentarios.Add(comentario);
            _contexto.SaveChanges();
            return Ok("Comentario creado exitosamente");
        }

        /// <summary>
        /// Endpoint que actualiza un comentario existente
        /// </summary>
        [HttpPut]
        [Route("UpdateComentario")]
        public IActionResult UpdateComentario([FromBody] Comentarios comentario)
        {
            _contexto.Comentarios.Update(comentario);
            _contexto.SaveChanges();
            return Ok("Comentario actualizado exitosamente");
        }

        /// <summary>
        /// Endpoint que elimina un comentario por su id
        /// </summary>
        [HttpDelete]
        [Route("DeleteComentario")]
        public IActionResult DeleteComentario(int id)
        {
            var comentario = (from c in _contexto.Comentarios
                              where c.cometarioId == id
                              select c).FirstOrDefault();
            if (comentario == null) return NotFound();

            _contexto.Comentarios.Remove(comentario);
            _contexto.SaveChanges();
            return Ok("Comentario eliminado exitosamente");
        }

        /// <summary>
        /// Endpoint que retorna los comentarios de un usuario específico
        /// </summary>
        /// <param name="usuarioId">ID del usuario a filtrar</param>
        [HttpGet]
        [Route("GetComentariosByUsuario/{usuarioId}")]
        public IActionResult GetComentariosByUsuario(int usuarioId)
        {
            var comentarios = (from c in _contexto.Comentarios
                               where c.usuarioId == usuarioId
                               select c).ToList();

            if (!comentarios.Any())
            {
                return NotFound($"No se encontraron comentarios para el usuario ID: {usuarioId}");
            }

            return Ok(comentarios);
        }
    }
}
