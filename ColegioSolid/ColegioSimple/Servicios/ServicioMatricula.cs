using ColegioSimple.Modelos;

namespace ColegioSimple.Servicios;


public class ServicioMatricula
{
    public void Inscribir(Estudiante estudiante, Curso curso)
    {
        
        if (curso.Estudiantes.Count >= curso.Aula.Capacidad)
        {
            throw new Exception("El aula " + curso.Aula.Codigo + " esta llena.");
        }

        curso.Estudiantes.Add(estudiante);
        estudiante.CursoActual = curso;
    }
}
