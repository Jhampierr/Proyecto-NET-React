using AccesoDatos.Models;
using AccesoDatos.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private AlumnoDAO alumnoDAO = new AlumnoDAO();

        [HttpGet("alumnoProfesor")]
        public List<AlumnoProfesor> alumnoProfesor(string usuario)
        {
            return alumnoDAO.seleccionarAlumnosProfesor(usuario);
        }

        [HttpGet("listarAlumnoId/{id}")]
        public Alumno GetAlumno(int id)
        {
            return alumnoDAO.seleccionarPorId(id);
        }

        [HttpPost("insertarAlumno")]
        public bool PostAlumno([FromBody] Alumno alumno)
        {
            return alumnoDAO.insertar(alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email);
        }

        [HttpPut("actualizarAlumno/{id}")]
        public bool PutAlumno(int id, [FromBody] Alumno alumno)
        {
            return alumnoDAO.actualizar(id, alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email);
        }

        [HttpPost("insertarAlumnoYMatricular")]
        public bool PostAlumnoYMatricular([FromBody] Alumno alumno, int id_asig)
        {
            return alumnoDAO.insertarAlumnoYMatricular(alumno.Dni, alumno.Nombre, alumno.Direccion, alumno.Edad, alumno.Email, id_asig);
        }

        [HttpDelete("EliminarAlumnoYMatricula")]
        public bool DeleteAlumnoYMatricula(int id) {
            return alumnoDAO.eliminarAlumnoYMatriculas(id);
        }
    }
}
