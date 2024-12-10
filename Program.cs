//Objetivo principios Solid

/*
Crea un programa que permita gestionar una lista de tareas. Debe permitir:

- Agregar una tarea a la lista.
- Mostrar todas las tareas.
- Guardar las tareas en un archivo de texto.
- Divide cada funcionalidad en métodos independientes para que cada uno tenga una única responsabilidad.
*/

using System;
using SOLID.Models;

class Program
{
    static void Main(string[] args)
    {
        // Crear una instancia del administrador
        Admin admin = new Admin();
        
        // Llamar al menú 
        admin.Menu();
    }
}