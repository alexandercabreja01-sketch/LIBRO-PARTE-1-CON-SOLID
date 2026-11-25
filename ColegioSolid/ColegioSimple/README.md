# ColegioSimple - Sistema de gestion de colegio con SOLID (C#)

Para ejecutar: `dotnet run` (necesita .NET 8) o abrir la carpeta en Visual Studio.

## Que hay en cada carpeta
- `Modelos/`      -> los datos: personas, aulas, cursos, pagos, notas.
- `Interfaces/`   -> las 3 promesas (interfaces).
- `Servicios/`    -> la logica: pagos, notas, matricula, y las clases que cumplen las interfaces.
- `Program.cs`    -> arma todo y lo prueba.

## Clases
Profesor, Estudiante, Administrativo, Padre (todas heredan de Persona),
Aula, Asignatura, Curso, Horario, Pago, Calificacion.

## SOLID en simple
- S (una tarea por clase): ServicioPagos solo cobra, ServicioMatricula solo inscribe, etc.
- O (agregar sin modificar): para un descuento nuevo creas otra clase que cumpla IDescuento.
- L (la hija reemplaza a la madre): Profesor, Padre, etc. se usan como Persona.
- I (interfaces pequenas): cada interfaz tiene un solo metodo.
- D (depender de interfaces): ServicioPagos recibe IDescuento e INotificador, no clases concretas.
