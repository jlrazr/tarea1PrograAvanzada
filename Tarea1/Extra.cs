using System.ComponentModel.DataAnnotations;
using System;

namespace Tarea1
{
    public class Extra
    {
        private static int SiguienteId = 1; // Compartida para todas las instancias 

        public int ID { get; private set; }
        public string Descripcion { get; set; }

        public int IdCategoriaPlato { get; set; }
        public bool Activo { get; set; }
        public int Precio { get; set; }


        // Constructor
        public Extra(string descripcion, int idCategoriaPlato, bool activo, int precio)
        {
            ID = SiguienteId;
            Descripcion = descripcion;
            IdCategoriaPlato = idCategoriaPlato;
            Activo = activo;
            Precio = precio;

            SiguienteId++;
        }
    }
}


