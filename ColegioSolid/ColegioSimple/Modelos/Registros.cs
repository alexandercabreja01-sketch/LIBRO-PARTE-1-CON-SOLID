namespace ColegioSimple.Modelos;

public class Pago
{
    public Estudiante Estudiante { get; set; }
    public string Concepto { get; set; }
    public decimal Monto { get; set; }
    public DateTime Fecha { get; set; }

    public Pago(Estudiante estudiante, string concepto, decimal monto)
    {
        Estudiante = estudiante;
        Concepto = concepto;
        Monto = monto;
        Fecha = DateTime.Now;
    }

    public override string ToString()
    {
        return Fecha.ToString("dd/MM/yyyy") + " | " + Estudiante.NombreCompleto() + " | " + Concepto + " | RD$ " + Monto.ToString("N2");
    }
}


public class Calificacion
{
    public Estudiante Estudiante { get; set; }
    public Asignatura Asignatura { get; set; }
    public double Nota { get; set; }
    public string Periodo { get; set; }

    public Calificacion(Estudiante estudiante, Asignatura asignatura, double nota, string periodo)
    {
        if (nota < 0 || nota > 100)
        {
            throw new Exception("La nota debe estar entre 0 y 100.");
        }

        Estudiante = estudiante;
        Asignatura = asignatura;
        Nota = nota;
        Periodo = periodo;
    }
}
