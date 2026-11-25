namespace SistemaEnvios;

// 1. ENUM 
// Define una lista de constantes con nombres legibles para representar estados fijos
public enum EstadoEnvio {
    Pendiente,
    EnCamino,
    Entregado
}

// 2. Struct 
// para datos pequeños y ligeros (como coordenadas geográficas)
public struct CoordenadaGPS {
    public double Latitud;
    public double Longitud;

    // Constructor del struct para inicializar las coordenadas
    public CoordenadaGPS(double latitud, double longitud) {
        Latitud = latitud;
        Longitud = longitud;
    }
}

// 3. Interface 
// Obliga a cualquier clase que la implemente a tener el método 'EnviarNotificacion'
public interface INotificable {
    void EnviarNotificacion();
}

// 4. Clase principal
// Utiliza el Enum, el Struct y cumple con el contrato de la Interface
public class Paquete : INotificable {
    public string CodigoTracking;
    public EstadoEnvio Estado; // Aquí usamos el Enum
    public CoordenadaGPS Destino; // Aquí usamos el Struct

    public Paquete(string codigo, EstadoEnvio estado, CoordenadaGPS destino) {
        CodigoTracking = codigo;
        Estado = estado;
        Destino = destino;
    }

    // Implementación obligatoria del método exigido por la Interface 'INotificable'
    public void EnviarNotificacion() {
        Console.WriteLine($"[ALERTA DE ENVÍO]");
        Console.WriteLine($"Paquete: {CodigoTracking}");
        Console.WriteLine($"Estado actual: {Estado}");
        Console.WriteLine($"Coordenadas de destino -> Lat: {Destino.Latitud}, Lon: {Destino.Longitud}\n");
    }
}

internal class Program {
    static void Main() {
        Console.WriteLine("Iniciando seguimiento de paquetes \n");

        // Creamos una coordenada usando el Struct
        CoordenadaGPS destinoFinal = new(18.4861, -69.9312);

        // Creamos el objeto Paquete usando el Enum para el estado
        Paquete miPaquete = new("PKG-2026-X", EstadoEnvio.EnCamino, destinoFinal);

        // Llamamos al método definido por la interfaz
        miPaquete.EnviarNotificacion();
    }
}