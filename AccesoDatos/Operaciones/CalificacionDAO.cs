using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class CalificacionDAO
    {
        public BdProyectoReactContext contexto = new BdProyectoReactContext();

        public List<Calificacion> seleccionarPorIdMatricula(int id)
        {
            var calificaciones = contexto.Calificacions.Where(c => c.MatriculaId == id).ToList();

            return calificaciones;
        }

        public bool insertarCalificacion(Calificacion calificacion)
        {
            try
            {
                
                contexto.Calificacions.Add(calificacion);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        public bool eliminarCalificacion(int id)
        {
            try
            {
                var calificacion = contexto.Calificacions.Where(a => a.Id == id).FirstOrDefault();
                if (calificacion != null)
                {
                    contexto.Calificacions.Remove(calificacion);
                    contexto.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

    }

}
