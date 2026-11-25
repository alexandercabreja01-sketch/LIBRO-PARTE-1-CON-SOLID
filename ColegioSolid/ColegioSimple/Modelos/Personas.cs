namespace ColegioSimple.Modelos;


public abstract class Persona
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Correo { get; set; }

    public Persona(int id, string nombre, string apellido, string correo)
    {
        Id = id;
        Nombre = nombre;
        Apellido = apellido;
        Correo = correo;
    }

    public string NombreCompleto()
    {
        return Nombre + " " + Apellido;
    }

    public abstract string Rol();

    public override string ToString()
    {
        return "[" + Rol() + "] " + NombreCompleto();
    }
}


public class Profesor : Persona
{
    public string Especialidad { get; set; }

    public Profesor(int id, string nombre, string apellido, string correo, string especialidad)
        : base(id, nombre, apellido, correo)
    {
        Especialidad = especialidad;
    }

    public override string Rol()
    {
        return "Profesor";
    }
}

public class Administrativo : Persona
{
    public string Cargo { get; set; }

    public Administrativo(int id, string nombre, string apellido, string correo, string cargo)
        : base(id, nombre, apellido, correo)
    {
        Cargo = cargo;
    }

    public override string Rol()
    {
        return "Administrativo";
    }
}

public class Estudiante : Persona
{
    public string Matricula { get; set; }
    public Padre Padre { get; set; }          
    public Curso CursoActual { get; set; }    

    public Estudiante(int id, string nombre, string apellido, string correo, string matricula)
        : base(id, nombre, apellido, correo)
    {
        Matricula = matricula;
    }

    public override string Rol()
    {
        return "Estudiante";                
    }
}

public class Padre : Persona
{
    public string Telefono { get; set; }
    public List<Estudiante> Hijos { get; set; } = new List<Estudiante>();

    public Padre(int id, string nombre, string apellido, string correo, string telefono)
        : base(id, nombre, apellido, correo)
    {
        Telefono = telefono;
    }

    public override string Rol()
    {
        return "Padre";
    }
}
