// See https://aka.ms/new-console-template for more information
using AccesoDatos.Models;
using AccesoDatos.Operaciones;

AlumnoDAO opAlumno = new AlumnoDAO();
//var insertAlumno = opAlumno.insertar("12345678", "Juan Perez", "Calle Falsa 123", 20, "jperez@email.com");
//var actualizarAlumno = opAlumno.actualizar(11, "12345678", "Juan Perez Paredes", "Calle Verdadera 321", 20, "jperez@email.com");
//var eliminarAlumno = opAlumno.eliminar(11);

/*Console.WriteLine("****************");
var alumnos = opAlumno.seleccionarTodos();
foreach (var alumno in alumnos)
{
    Console.WriteLine($"ID: {alumno.Id}, Nombre: {alumno.Nombre}, DNI: {alumno.Dni}, Edad: {alumno.Edad}, Direccion: {alumno.Direccion}, Email: {alumno.Email}");
}

Console.WriteLine("****************");

var alumno1 = opAlumno.seleccionarPorId(2);

if(alumno1 != null)
{
    Console.WriteLine($"ID: {alumno1.Id}, Nombre: {alumno1.Nombre}, DNI: {alumno1.Dni}, Edad: {alumno1.Edad}, Direccion: {alumno1.Direccion}, Email: {alumno1.Email}");
}
else
{
    Console.WriteLine("Alumno no encontrado");
}*/

Console.WriteLine("****************");
var alumasig = opAlumno.seleccionarAlumnosAsignaturas();
foreach (AlumnoAsignatura alasig in alumasig)
{
    Console.WriteLine($"Alumno: {alasig.NombreAlumno}, Asignatura: {alasig.NombreAsignatura}");
}