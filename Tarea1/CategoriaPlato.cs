using System.ComponentModel.DataAnnotations;
using System;

namespace Tarea1
{
    public class CategoriaPlato
    {
        private static int SiguienteId = 1; // Compartida para todas las instancias
        public int Id { get; private set; }
        public string Descripcion { get; set; }
        public bool Activa { get; set; }



        // Constructor
        public CategoriaPlato(string descripcion, bool activa)
        {
            Id = SiguienteId;
            Descripcion = descripcion;
            Activa = activa;

            SiguienteId++;
        }
    }
}

