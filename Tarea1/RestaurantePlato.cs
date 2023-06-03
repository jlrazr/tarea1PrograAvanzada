using System.ComponentModel.DataAnnotations;
using System;

namespace Tarea1
{
    public class RestaurantePlato
    {
        private static int SiguienteId = 1; // Compartida para todas las instancias
        public int IdRestaurante { get; set; }
        public int IdPlato { get; set; }
        public DateOnly FechaAfiliacion { get; set; }


        // Constructor
        public RestaurantePlato(int idRest, int idPlato)
        {
            IdRestaurante = idRest;
            IdPlato = idPlato;
            FechaAfiliacion = new DateOnly();
        }
    }
}
