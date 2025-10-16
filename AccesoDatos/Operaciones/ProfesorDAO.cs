using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public class ProfesorDAO
    {
        public BdProyectoReactContext contexto = new BdProyectoReactContext();

        public Profesor login (string usuario, string pass)
        {
            try
            {
                var profesor = contexto.Profesors
                    .Where(p => p.Usuario == usuario && p.Pass == pass)
                    .FirstOrDefault();
                return profesor;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al iniciar sesión: " + ex.Message);
            }
        }
    }
}
