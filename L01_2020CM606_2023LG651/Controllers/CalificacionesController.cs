using L01_2020CM606_2023LG651.Models;
using L01_2020CM606_2023LG651.Models.Tablas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L01_2020CM606_2023LG651.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionesController : ControllerBase
    {
        private readonly ApplicationDbContext _contexto;

        public CalificacionesController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        /// <summary>
        /// Endpoint que retorna la lista de calificaciones existentes
        /// </summary>
        [HttpGet]
        [Route("GetAllCalificaciones")]
        public IActionResult Get()
        {
            var calificaciones = (from c in _contexto.Calificaciones
                                select c).ToList();
            return Ok(calificaciones);
        }

        /// <summary>
        /// Endpoint que retorna una calificación por su id
        /// </summary>
        [HttpGet]
        [Route("GetCalificacionById")]
        public IActionResult GetCalificacionById(int id)
        {
            var calificacion = (from c in _contexto.Calificaciones
                            where c.calificacionId == id
                            select c).FirstOrDefault();
            if (calificacion == null) return NotFound();
            return Ok(calificacion);
        }

        /// <summary>
        /// Endpoint que crea una nueva calificación
        /// </summary>
        [HttpPost]
        [Route("CreateCalificacion")]
        public IActionResult CreateCalificacion([FromBody] Calificaciones calificacion)
        {
            _contexto.Calificaciones.Add(calificacion);
            _contexto.SaveChanges();
            return Ok("Calificación creada exitosamente");
        }

        /// <summary>
        /// Endpoint que actualiza una calificación existente
        /// </summary>
        [HttpPut]
        [Route("UpdateCalificacion")]
        public IActionResult UpdateCalificacion([FromBody] Calificaciones calificacion)
        {
            _contexto.Calificaciones.Update(calificacion);
            _contexto.SaveChanges();
            return Ok("Calificación actualizada exitosamente");
        }

        /// <summary>
        /// Endpoint que elimina una calificación por su id
        /// </summary>
        [HttpDelete]
        [Route("DeleteCalificacion")]
        public IActionResult DeleteCalificacion(int id)
        {
            var calificacion = (from c in _contexto.Calificaciones
                            where c.calificacionId == id
                            select c).FirstOrDefault();
            if (calificacion == null) return NotFound();

            _contexto.Calificaciones.Remove(calificacion);
            _contexto.SaveChanges();
            return Ok("Calificación eliminada exitosamente");
        }
    }
}
