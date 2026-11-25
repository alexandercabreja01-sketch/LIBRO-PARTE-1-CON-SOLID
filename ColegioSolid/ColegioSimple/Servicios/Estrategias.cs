using ColegioSimple.Interfaces;
using ColegioSimple.Modelos;

namespace ColegioSimple.Servicios;


public class SinDescuento : IDescuento
{
    public decimal Calcular(Estudiante estudiante, decimal monto)
    {
        return monto;   
    }
}

public class DescuentoHermanos : IDescuento
{
    public decimal Calcular(Estudiante estudiante, decimal monto)
    {
        if (estudiante.Padre != null && estudiante.Padre.Hijos.Count > 1)
        {
            return monto * 0.90m;
        }
        return monto;
    }
}



public class ConsolaNotificador : INotificador
{
    public void Enviar(string destinatario, string mensaje)
    {
        Console.WriteLine("  >> Aviso para " + destinatario + ": " + mensaje);
    }
}



public class PromedioSimple : ICalculadorPromedio
{
    public double Calcular(List<Calificacion> notas)
    {
        if (notas.Count == 0)
        {
            return 0;
        }

        double suma = 0;
        foreach (Calificacion c in notas)
        {
            suma = suma + c.Nota;
        }
        return suma / notas.Count;
    }
}
