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
            try
            {
                _contexto.Comentarios.Add(comentario);
                _contexto.SaveChanges();
                return Ok("Comentario creado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Endpoint que actualiza un comentario existente
        /// </summary>
        [HttpPut]
        [Route("UpdateComentario")]
        public IActionResult UpdateComentario([FromBody] Comentarios comentario)
        {
            try
            {
                _contexto.Comentarios.Update(comentario);
                _contexto.SaveChanges();
                return Ok("Comentario actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

            try
            {
                _contexto.Comentarios.Remove(comentario);
                _contexto.SaveChanges();
                return Ok("Comentario eliminado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}