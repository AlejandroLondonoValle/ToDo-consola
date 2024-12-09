using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Models;

public class Admin
{
    private string archivoTareas = "tareas.txt";
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

    // Menú para la gestión de tareas
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

            // Validación para asegurar que la opción es un número
            if (!int.TryParse(Console.ReadLine(), out int option))
            {
                Console.WriteLine("Opción no válida, por favor ingrese un número.");
                System.Threading.Thread.Sleep(2000);
                continue;
            }

            // Controlar las diferentes opciones del menú
            switch (option)
            {
                case 1:
                    // Agregar tarea
                    Console.Write("Ingresa la descripción de la tarea: ");
                    string? descripcion = Console.ReadLine();
                    gestor.AgregarTarea(descripcion);
                    break;
                case 2:
                    // Mostrar tareas
                    gestor.MostrarTareas();
                    Thread.Sleep(7000);

                    break;
                case 3:
                    // Eliminar tarea
                    gestor.EliminarTarea();
                    break;
                case 4:
                    // Guardar tareas en archivo
                    Archivo.GuardarTareas(gestor.ObtenerTareas(), archivoTareas);
                    break;
                case 0:
                    // Salir
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Opción no válida, intente nuevamente.");
                    System.Threading.Thread.Sleep(2000);
                    break;
            }
        }
    }
}