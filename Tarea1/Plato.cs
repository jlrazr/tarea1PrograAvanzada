using System.ComponentModel.DataAnnotations;
using System;

namespace Tarea1
{
    public class Plato
    {
        private static int SiguienteId = 1; // Compartida para todas las instancias
        public int Id { get; private set; }

        public string Nombre { get; set; }
        public int Precio { get; set; }
        public CategoriaPlato Categoria { get; set; }

        // Constructor
        public Plato(string nombre, int precio, CategoriaPlato categoria)
        {
            Id = SiguienteId;
            Nombre = nombre;
            Precio = precio;
            Categoria = categoria;

            SiguienteId++;
        }
    }

}
