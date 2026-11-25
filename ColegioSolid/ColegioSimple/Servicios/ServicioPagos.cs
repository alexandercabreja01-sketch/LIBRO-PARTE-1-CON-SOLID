using ColegioSimple.Interfaces;
using ColegioSimple.Modelos;

namespace ColegioSimple.Servicios;


public class ServicioPagos
{
    private List<Pago> _pagos = new List<Pago>();
    private IDescuento _descuento;
    private INotificador _notificador;

    public ServicioPagos(IDescuento descuento, INotificador notificador)
    {
        _descuento = descuento;
        _notificador = notificador;
    }

    public Pago Registrar(Estudiante estudiante, string concepto, decimal monto)
    {
        if (monto <= 0)
        {
            throw new Exception("El monto debe ser mayor que cero.");
        }

    
        decimal montoFinal = _descuento.Calcular(estudiante, monto);

        Pago pago = new Pago(estudiante, concepto, montoFinal);
        _pagos.Add(pago);

        if (estudiante.Padre != null)
        {
            _notificador.Enviar(estudiante.Padre.Correo, "Pago recibido: " + concepto + " por RD$ " + montoFinal.ToString("N2"));
        }

        return pago;
    }
}
