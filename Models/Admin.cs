namespace SOLID.Models;

public class Admin
{
    private string archivoTareas = "Tareas.txt";
    private GestorTareas gestor;

    // Constructor para inicializar el gestor y cargar las tareas desde el archivo
    public Admin()
    {
        gestor = new GestorTareas();
        // Cargar tareas desde el archivo si existen
        var tareasGuardadas = Archivo.CargarTareas(archivoTareas);
        foreach (var tarea in tareasGuardadas)
        {
            gestor.AgregarTarea(tarea.Descripcion);
        }
    }


    public void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=========================================================================");
            Console.WriteLine("                              TO DO LIST                                 ");
            Console.WriteLine("=========================================================================");
            Console.WriteLine("| {0,-1} | {1,-43} |", " No ", "                           Opción                             ");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("| {0,-1} | {1,-43} |", "(1) ", "Añadir una nueva tarea                                        ");
            Console.WriteLine("| {0,-1} | {1,-43} |", "(2) ", "Mostrar todas las tareas                                      ");
            Console.WriteLine("| {0,-1} | {1,-43} |", "(3) ", "Eliminar una tarea                                            ");
            Console.WriteLine("| {0,-1} | {1,-43} |", "(4) ", "Exportar todas las tareas en txt                              ");
            Console.WriteLine("| {0,-1} | {1,-43} |", "    ", "                                                              ");
            Console.WriteLine("| {0,-1} | {1,-53} |", "(0) ", "Salir                                                         ");
            Console.WriteLine("=========================================================================");
            Console.Write("Seleccione una opción del menú: ");

            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Opción no válida, por favor ingrese un número.");
                Thread.Sleep(2000);
                continue;
            }

            switch (option)
            {
                case 1:
                    Console.Write("Ingresa la descripción de la tarea: ");
                    string? descripcion = Console.ReadLine();
                    gestor.AgregarTarea(descripcion);
                    break;

                case 2:
                    gestor.MostrarTareas();
                    Thread.Sleep(7000);
                    break;

                case 3:
                    gestor.EliminarTarea();
                    break;

                case 4:
                    Archivo.GuardarTareas(gestor.ObtenerTareas(), archivoTareas);
                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
}