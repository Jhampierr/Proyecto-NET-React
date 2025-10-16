using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AccesoDatos.Operaciones
{
    public class AlumnoDAO
    {
        public BdProyectoReactContext contexto = new BdProyectoReactContext();
        public List<Alumno> seleccionarTodos()
        {
            var alumnos = contexto.Alumnos.ToList<Alumno>();
            return alumnos;
        }

        public Alumno seleccionarPorId(int id)
        {
            //var alumno = contexto.Alumnos.Find(id).FirstOrDefault();
            var alumno = contexto.Alumnos.Where(a => a.Id == id).FirstOrDefault();

            return alumno;
        }

        public Alumno seleccionarPorDni(string dni)
        {
            var alumno = contexto.Alumnos.Where(a => a.Dni.Equals(dni)).FirstOrDefault();

            return alumno;
        }

        public bool insertar(string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                Alumno alumno = new Alumno();
                alumno.Dni = dni;
                alumno.Nombre = nombre;
                alumno.Direccion = direccion;
                alumno.Edad = edad;
                alumno.Email = email;

                contexto.Alumnos.Add(alumno);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool actualizar(int id, string dni, string nombre, string direccion, int edad, string email)
        {
            try
            {
                var alumno = this.seleccionarPorId(id);
                if (alumno != null)
                {
                    alumno.Dni = dni;
                    alumno.Nombre = nombre;
                    alumno.Direccion = direccion;
                    alumno.Edad = edad;
                    alumno.Email = email;
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool eliminar(int id)
        {
            try
            {
                var alumno = this.seleccionarPorId(id);
                if (alumno != null)
                {
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<AlumnoAsignatura> seleccionarAlumnosAsignaturas()
        {
            var query = from a in contexto.Alumnos
                        join m in contexto.Matriculas on a.Id equals m.AlumnoId
                        join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                        select new AlumnoAsignatura
                        {
                            NombreAlumno = a.Nombre,
                            NombreAsignatura = asig.Nombre
                        };
            return query.ToList();
        }

        public List<AlumnoProfesor> seleccionarAlumnosProfesor(string usuario)
        {
            var query = from a in contexto.Alumnos
                        join m in contexto.Matriculas on a.Id equals m.AlumnoId
                        join asig in contexto.Asignaturas on m.AsignaturaId equals asig.Id
                        where asig.Profesor == usuario
                        select new AlumnoProfesor
                        {
                            Id = a.Id,
                            Dni = a.Dni,
                            Nombre = a.Nombre,
                            Direccion = a.Direccion,
                            Edad = a.Edad,
                            Email = a.Email,
                            Asignatura = asig.Nombre
                        };
            return query.ToList();
        } 

        public bool insertarAlumnoYMatricular(string dni, string nombre, string direccion, int edad, string email, int id_asig)
        {
            try
            {
                var existe = this.seleccionarPorDni(dni);
                Matricula matricula = new Matricula();

                if (existe == null)
                {
                    insertar(dni, nombre, direccion, edad, email);
                    var nuevo = this.seleccionarPorDni(dni);

                    matricula.AlumnoId = nuevo.Id;
                    matricula.AsignaturaId = id_asig;
                    contexto.Matriculas.Add(matricula);
                    contexto.SaveChanges();

                }
                else
                {
                    //Matricula matricula = new Matricula();
                    matricula.AlumnoId = existe.Id;
                    matricula.AsignaturaId = id_asig;
                    contexto.Matriculas.Add(matricula);
                    contexto.SaveChanges();
                }

                 return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool eliminarAlumnoYMatriculas(int id)
        {
            try
            {
                var alumno = this.seleccionarPorId(id);
                if (alumno != null)
                {
                    var matriculas = contexto.Matriculas.Where(m => m.AlumnoId == id).ToList();
                    foreach(Matricula m in matriculas)
                    {
                        var calificaciones = contexto.Calificacions.Where(c => c.MatriculaId == m.Id).ToList();
                        contexto.Calificacions.RemoveRange(calificaciones);

                    }
                    contexto.Matriculas.RemoveRange(matriculas);
                    contexto.Alumnos.Remove(alumno);
                    contexto.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

    }
}
