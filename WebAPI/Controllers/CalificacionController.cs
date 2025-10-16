using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private CalificacionDAO calificacionDAO = new CalificacionDAO();

        [HttpGet("listarCalificacionPorIdMatricula/{idMatricula}")]
        public List<Calificacion> GetCalificaionYMatricula(int idMatricula)
        {
            return calificacionDAO.seleccionarPorIdMatricula(idMatricula);
        }

        [HttpPost("insertarCalificacion")]
        public bool PostCalificacion([FromBody] Calificacion calificacion)
        {
            return calificacionDAO.insertarCalificacion(calificacion);
        }

        [HttpDelete("eliminarCalificacion/{id}")]
        public bool DeleteCalificacion(int id)
        {
            return calificacionDAO.eliminarCalificacion(id);
        }
    }
}
