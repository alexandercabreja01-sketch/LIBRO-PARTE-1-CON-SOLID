using ColegioSimple.Modelos;

namespace ColegioSimple.Interfaces;


public interface IDescuento
{
    decimal Calcular(Estudiante estudiante, decimal monto);
}


public interface INotificador
{
    void Enviar(string destinatario, string mensaje);
}


public interface ICalculadorPromedio
{
    double Calcular(List<Calificacion> notas);
}
