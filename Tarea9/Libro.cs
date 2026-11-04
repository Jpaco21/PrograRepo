using System;
using System.Collections.Generic;
using System.Text;

namespace Tarea9
{
    public class Libro
    {
        public string Nombre { get; set; }
        public string Autor { get; set; }
        public int Anio { get; set; }

        public Libro(string nombre, string autor, int anio)
        {
            Nombre = nombre;
            Autor = autor;
            Anio = anio;
        }
    }
}
