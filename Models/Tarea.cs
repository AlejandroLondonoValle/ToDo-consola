using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SOLID.Models;
public class Tarea
{
    private static int contadorId = 1;
    public int Id { get; set; }
    public string Descripcion { get; set; }
    public bool EstaCompletada { get; set; }

    public Tarea(string descripcion)
    {
        Id = contadorId++;
        Descripcion = descripcion;
        EstaCompletada = false;
    }

    public override string ToString()
    {
        return $"|{Id}|{Descripcion} - {(EstaCompletada ? "Completada" : "Pendiente")}";
    }
}