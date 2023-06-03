using System.ComponentModel.DataAnnotations;
using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace Tarea1
{
    public class Helpers
    {
        public static void RegistrarRestaurante(ManagerRestaurantes manager)
        {
            Console.Write("Ingrese el nombre del restaurante: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese la dirección del restaurante: ");
            string direccion = Console.ReadLine();

            Console.Write("Está el restaurante activo? (s/n): ");
            bool activo = Console.ReadLine().ToLower() == "s";

            Console.Write("Ingrese el teléfono del restaurante: ");
            string telefono = Console.ReadLine();


            Restaurante restaurante = new(nombre, direccion, activo, telefono);

            manager.Registrar(restaurante);

            Console.Write("Desea ingresar otro restaurante? (s) para confirmar: ");
            string eleccion = Console.ReadLine();

            if (eleccion == "s")
            {
                RegistrarRestaurante(manager);
            }
        }

        public static void MostrarRestaurantes(ManagerRestaurantes manager)
        {
            Restaurante[] restaurantes = manager.GetTodos();

            if (restaurantes[0] != null)
            {
                Console.WriteLine($"El número de entradas en restaurantes es: {restaurantes.Length}");
                Console.Write("---------  Inicio de la lista de restaurantes  ---------\n\n");
                Console.Write("Los restaurantes registrados son: \n\n");
                foreach (var restaurante in restaurantes)
                {
                    if (restaurante != null)
                    {
                        Console.WriteLine($"ID: {restaurante.Id}, Nombre: {restaurante.Nombre}, Dirección: {restaurante.Direccion}, Activo: {restaurante.Activo}, Teléfono: {restaurante.Telefono}");
                    }
                }
                Console.Write("\n\n---------  Fin de la lista de restaurantes  ---------");
            } else
            {
                Console.WriteLine("No existen registros de restaurantes.");
            }
        }

        public static void RegistrarPlato(ManagerPlatos managerPlatos, ManagerCategPlatos managerCategPlatos) // Broken from here as the vars names are wrong.
        {
            Console.Write("Ingrese el nombre del plato: ");
            string nombre = Console.ReadLine();

            Console.Write("Ingrese el precio del plato: ");
            int precio = Convert.ToInt32(Console.ReadLine());

            Console.Write("Ingrese el ID de la categoría del plato: ");
            int idCategoria = Convert.ToInt32(Console.ReadLine());

            CategoriaPlato categoria = null;
            foreach (var categ in managerCategPlatos.GetTodos())
            {
                if (categ != null && categ.Id == idCategoria)
                {
                    categoria = categ;
                    break;
                }
            }

            if (categoria == null)
            {
                Console.WriteLine("El ID ingresado no pertenece a ninguna categoría.");
                return;
            }
            Plato plato = new(nombre, precio, categoria);

            managerPlatos.Registrar(plato);

            Console.Write("Desea ingresar otro plato? (s) para confirmar: ");
            string eleccion = Console.ReadLine();

            if (eleccion == "s")
            {
                RegistrarPlato(managerPlatos, managerCategPlatos);
            }
        }

        public static void mostrarPlatos(ManagerPlatos manager)
        {
            Plato[] platos = manager.GetTodos();

            if (platos[0] != null)
            {
                Console.WriteLine($"El número de entradas en platos es: {platos.Length}");
                Console.Write("---------  Inicio de la lista de platos  ---------\n\n");
                Console.Write("Los platos registrados son: \n\n");

                foreach (var plato in platos)
                {
                    if (plato != null)
                    {
                        Console.WriteLine($"ID: {plato.Id}, Nombre: {plato.Nombre}, PRecio: {plato.Precio}, ID de la categoría: {plato.Categoria.Id}, Descripción de la categoría: {plato.Categoria.Descripcion}");
                    }
                }
                Console.Write("\n\n---------  Fin de la lista de platos  ---------");
            } else
            {
                Console.WriteLine("No existen registros de platos.");
            }

        }

        public static void RegistrarCategPlatos(ManagerCategPlatos manager)
        {
            Console.Write("Ingrese la descripción de la categoría: ");
            string descripcion = Console.ReadLine();

            Console.Write("Es una categoría activa? (s/n): ");
            bool activa = Console.ReadLine().ToLower() == "s";

            CategoriaPlato categoria = new(descripcion, activa);

            manager.Registrar(categoria);

            Console.Write("Desea ingresar otra categoría? (s) para confirmar: ");
            string eleccion = Console.ReadLine();

            if (eleccion == "s")
            {
                RegistrarCategPlatos(manager);
            }
        }

        public static void MostrarCategPlatos(ManagerCategPlatos manager)
        {
            CategoriaPlato[] categorias = manager.GetTodos();

            if (categorias[0] != null)
            {
                Console.WriteLine($"El número de categorías registradas es: {categorias.Length}");
                Console.Write("---------  Inicio de la lista de categorías de platos  ---------\n\n");
                Console.Write("Las categorías registradas son: \n\n");
                foreach (var categoria in categorias)
                {
                    if (categoria != null)
                    {
                        Console.WriteLine($"ID: {categoria.Id}, Descripción: {categoria.Descripcion},  Activa: {categoria.Activa}");
                    }
                }
                Console.Write("\n\n---------  Fin de la lista de categorías  ---------");
            }
            else
            {
                Console.WriteLine("No existen registros de categorías de platos.");
            }
        }

        public static void RegistrarCliente(ManagerClientes manager)
        {

        }

        public static void MostrarClientes(ManagerClientes manager)
        {

        }
    }
}
