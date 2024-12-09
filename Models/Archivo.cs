using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Models;

public class Archivo
{
    // Cargar tareas desde el archivo de texto
    public static List<Tarea> CargarTareas(string archivo)
    {
        List<Tarea> tareas = new List<Tarea>();

        if (File.Exists(archivo))
        {
            var lineas = File.ReadAllLines(archivo);

            foreach (var linea in lineas)
            {
                // Suponemos que las tareas están separadas por "|"
                var partes = linea.Split('|');

                if (partes.Length == 3)
                {
                    // Extraer los valores del Id, Descripcion y Estado
                    int id = int.TryParse(partes[0], out id) ? id : 0;
                    string descripcion = partes[1].Trim();
                    bool estaCompletada = partes[2].Trim().ToLower() == "completada";

                    // Crear una nueva tarea con la información extraída
                    Tarea tarea = new Tarea(descripcion)
                    {
                        Id = id,
                        EstaCompletada = estaCompletada
                    };

                    tareas.Add(tarea);
                }
            }
        }

        return tareas;
    }

    // Guardar tareas en el archivo de texto
    public static void GuardarTareas(List<Tarea> tareas, string archivo)
    {
        List<string> lineas = new List<string>();

        foreach (var tarea in tareas)
        {
            // Guardamos el Id, Descripción y el estado de la tarea
            string linea = $"|{tarea.Id}|  {tarea.Descripcion}  |{(tarea.EstaCompletada ? "Completada" : "Pendiente")}";
            lineas.Add(linea);
        }

        // Escribir todas las líneas en el archivo
        File.WriteAllLines(archivo, lineas);
    }
}
