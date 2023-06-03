using System.ComponentModel.DataAnnotations;
using System;

namespace Tarea1
{
    public class Cliente
    {
        private static int SiguienteId = 1; // Compartida para todas las instancias
        public int Id { get; private set; }
        public string Nombre { get; set; }
        public string PrimApellido { get; set; }
        public string SegApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Genero { get; set; }


        // Constructor
        public Cliente(string nombre, string primApellido, string segApellido, DateTime fechaNacimiento, char genero)
        {
            Id = SiguienteId;
            Nombre = nombre;
            PrimApellido = primApellido;
            SegApellido = segApellido;
            FechaNacimiento = fechaNacimiento;
            Genero = genero;

            SiguienteId++;
        }
    }

}
