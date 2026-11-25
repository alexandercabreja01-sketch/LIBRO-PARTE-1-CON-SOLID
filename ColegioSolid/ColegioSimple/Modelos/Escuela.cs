namespace ColegioSimple.Modelos;


public class Aula
{
    public string Codigo { get; set; }
    public int Capacidad { get; set; }   

    public Aula(string codigo, int capacidad)
    {
        Codigo = codigo;
        Capacidad = capacidad;
    }
}

public class Asignatura
{
    public string Nombre { get; set; }
    public Profesor Profesor { get; set; }   
    public Asignatura(string nombre, Profesor profesor)
    {
        Nombre = nombre;
        Profesor = profesor;
    }
}

public class Curso
{
    public string Nombre { get; set; }
    public Aula Aula { get; set; }
    public List<Asignatura> Asignaturas { get; set; } = new List<Asignatura>();
    public List<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    public Curso(string nombre, Aula aula)
    {
        Nombre = nombre;
        Aula = aula;
    }
}

public class Horario
{
    public Curso Curso { get; set; }
    public Asignatura Asignatura { get; set; }
    public string Dia { get; set; }
    public string HoraInicio { get; set; }
    public string HoraFin { get; set; }

    public Horario(Curso curso, Asignatura asignatura, string dia, string horaInicio, string horaFin)
    {
        Curso = curso;
        Asignatura = asignatura;
        Dia = dia;
        HoraInicio = horaInicio;
        HoraFin = horaFin;
    }

    public override string ToString()
    {
        return Dia + " " + HoraInicio + "-" + HoraFin + " | " + Asignatura.Nombre + " | Aula " + Curso.Aula.Codigo;
    }
}
