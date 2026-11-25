using ColegioSimple.Interfaces;
using ColegioSimple.Modelos;
using ColegioSimple.Servicios;


IDescuento descuento = new DescuentoHermanos();   
INotificador notificador = new ConsolaNotificador();
ICalculadorPromedio calculador = new PromedioSimple();

ServicioPagos servicioPagos = new ServicioPagos(descuento, notificador);
ServicioCalificaciones servicioNotas = new ServicioCalificaciones(calculador);
ServicioMatricula servicioMatricula = new ServicioMatricula();


Profesor profe = new Profesor(1, "Ana", "Perez", "ana@colegio.edu", "Matematicas");
Administrativo admin = new Administrativo(2, "Luis", "Gomez", "luis@colegio.edu", "Secretario");
Padre padre = new Padre(3, "Carlos", "Diaz", "carlos@mail.com", "809-555-0101");

Estudiante pedro = new Estudiante(4, "Pedro", "Diaz", "pedro@colegio.edu", "2026-001");
Estudiante maria = new Estudiante(5, "Maria", "Diaz", "maria@colegio.edu", "2026-002");


pedro.Padre = padre;
maria.Padre = padre;
padre.Hijos.Add(pedro);
padre.Hijos.Add(maria);

Aula aula = new Aula("A-101", 30);
Asignatura matematicas = new Asignatura("Matematicas", profe);
Curso curso = new Curso("5to A", aula);
curso.Asignaturas.Add(matematicas);

Horario horario = new Horario(curso, matematicas, "Lunes", "08:00", "09:30");


Console.WriteLine("== Personas ==");
Console.WriteLine(profe);
Console.WriteLine(admin);
Console.WriteLine(padre);
Console.WriteLine(pedro);
Console.WriteLine(maria);

servicioMatricula.Inscribir(pedro, curso);
servicioMatricula.Inscribir(maria, curso);
Console.WriteLine("\nEstudiantes en " + curso.Nombre + ": " + curso.Estudiantes.Count);

Console.WriteLine("\n== Horario ==");
Console.WriteLine(horario);

Console.WriteLine("\n== Pago (con descuento por hermanos) ==");
Pago pago = servicioPagos.Registrar(pedro, "Mensualidad", 5000m);
Console.WriteLine(pago);

Console.WriteLine("\n== Calificaciones ==");
servicioNotas.Registrar(pedro, matematicas, 90, "P1");
servicioNotas.Registrar(pedro, matematicas, 80, "P2");
Console.WriteLine("Promedio de " + pedro.NombreCompleto() + ": " + servicioNotas.PromedioDe(pedro));
