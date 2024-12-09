using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Models;

public class GestorTareas
{
    private List<Tarea> tareas;

    public GestorTareas()
    {
        tareas = new List<Tarea>();
    }

    public void AgregarTarea(string descripcion)
    {
        tareas.Add(new Tarea(descripcion));
    }

    public void MostrarTareas()
    {
        Console.WriteLine("Lista de tareas:");
        if (tareas.Count == 0)
        {
            Console.WriteLine("No hay tareas para mostrar.");
        }
        else
        {
            foreach (var tarea in tareas)
            {
                Console.WriteLine(tarea);
            }
        }
    }

    public List<Tarea> ObtenerTareas()
    {
        return tareas;
    }

    public void EliminarTarea()
    {
        Console.WriteLine("Ingrese el Id de la tarea a eliminar:");
        if (int.TryParse(Console.ReadLine(), out int tareaId))
        {
            // Buscar la tarea por Id
            Tarea? tareaEliminar = tareas.FirstOrDefault(t => t.Id == tareaId);

            if (tareaEliminar != null)
            {
                // Confirmar eliminación
                Console.WriteLine($"¿Estás seguro de eliminar la tarea: {tareaEliminar.Descripcion}? (si/no)");
                string? confirmation = Console.ReadLine();

                if (confirmation?.ToLower() == "si")
                {
                    tareas.Remove(tareaEliminar);  // Eliminar la tarea de la lista
                    Console.WriteLine($"La tarea '{tareaEliminar.Descripcion}' ha sido eliminada con éxito.");
                }
                else
                {
                    Console.WriteLine("La tarea no ha sido eliminada.");
                }
            }
            else
            {
                Console.WriteLine("No se encontró una tarea con ese Id.");
            }
        }
        else
        {
            Console.WriteLine("El Id ingresado no es válido.");
        }
    }
}