using ColegioSimple.Interfaces;
using ColegioSimple.Modelos;

namespace ColegioSimple.Servicios;


public class ServicioCalificaciones
{
    private List<Calificacion> _notas = new List<Calificacion>();
    private ICalculadorPromedio _calculador;

    public ServicioCalificaciones(ICalculadorPromedio calculador)
    {
        _calculador = calculador;
    }

    public void Registrar(Estudiante estudiante, Asignatura asignatura, double nota, string periodo)
    {
        Calificacion c = new Calificacion(estudiante, asignatura, nota, periodo);
        _notas.Add(c);
    }

    public double PromedioDe(Estudiante estudiante)
    {

        List<Calificacion> susNotas = new List<Calificacion>();
        foreach (Calificacion c in _notas)
        {
            if (c.Estudiante == estudiante)
            {
                susNotas.Add(c);
            }
        }

        return _calculador.Calcular(susNotas);
    }
}
