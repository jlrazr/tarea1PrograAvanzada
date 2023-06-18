using System.ComponentModel.DataAnnotations;
using System;
using System.Diagnostics;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Tarea1
{
    public class Helpers
    {
        public static void RegistrarRestaurante(ManagerRestaurantes manager)
        {
            Console.Write("Ingrese el nombre del restaurante: ");
            string nombre = Console.ReadLine();
            while (nombre == "")
            {
                Console.Write("Debe ingresar un nombre válido.\n");
                Console.Write("Ingrese el nombre del restaurante: ");
                nombre = Console.ReadLine();
            }


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

        public static void RegistrarPlato(ManagerPlatos managerPlatos, ManagerCategPlatos managerCategPlatos)
        {
            Console.Write("Ingrese el nombre del plato: ");
            string nombre = Console.ReadLine();
            while (nombre == "")
            {
                Console.Write("Debe ingresar un nombre válido.\n");
                Console.Write("Ingrese el nombre del plato: ");
                nombre = Console.ReadLine();
            }

            int precio = 0;
            bool esValido = false;

            while (!esValido)
            {
                try
                {
                    Console.Write("Ingrese el precio del plato: ");
                    precio = Convert.ToInt32(Console.ReadLine());
                    esValido = true;
                }
                catch (FormatException) {
                    Console.Write("Debe ingresar un precio válido.\n");
                }
            }


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
                Console.WriteLine("El ID ingresado no pertenece a ninguna categoría. El plato no fue registrado. \nVolviendo al menú principal...");
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
                        Console.WriteLine($"ID: {plato.Id}, Nombre: {plato.Nombre}, Precio: {plato.Precio}, ID de la categoría: {plato.Categoria.Id}, Descripción de la categoría: {plato.Categoria.Descripcion}");
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
            while (descripcion == "")
            {
                Console.Write("Debe ingresar una descripción válida.\n");
                Console.Write("Ingrese la descripción de la categoría: ");
                descripcion = Console.ReadLine();
            }

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
            Console.Write("Ingrese el nombre del cliente (sin apellidos): ");
            string nombre = Console.ReadLine();
            while (nombre == "")
            {
                Console.Write("Debe ingresar un nombre válido.\n");
                Console.Write("Ingrese el nombre del cliente (sin apellidos): ");
                nombre = Console.ReadLine();
            }

            Console.Write("Ingrese el primer apellido del cliente: ");
            string primApellido = Console.ReadLine();
            while (primApellido == "")
            {
                Console.Write("Debe ingresar un apellido válido.\n");
                Console.Write("Ingrese el primer apellido del cliente: ");
                primApellido = Console.ReadLine();
            }

            Console.Write("Ingrese el segundo apellido del cliente: ");
            string segApellido = Console.ReadLine();
            while (segApellido == "")
            {
                Console.Write("Debe ingresar un apellido válido.\n");
                Console.Write("Ingrese el segundo apellido del cliente: ");
                segApellido = Console.ReadLine();
            }

            DateTime fechaNacim = new DateTime();
            bool esValido = false;

            while (!esValido)
            {
                try
                {
                    Console.Write("Ingrese la fecha de nacimiento del cliente con el formato mm/dd/aaaa: ");
                    fechaNacim = DateTime.Parse(Console.ReadLine());
                    esValido = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("La fecha ingresada no es inválida.");
                }
            }

            char genero = '\0';
            bool generoValido = false;

            while (!generoValido)
            {
                try
                {
                    Console.Write("Ingrese el género (M/F): ");
                    genero = Char.ToUpper(Console.ReadKey().KeyChar);

                    if (genero == 'M' || genero == 'F')
                        generoValido = true;
                    else
                        throw new FormatException();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Valor inválido.");
                }
            }

            Cliente cliente = new(nombre, primApellido, segApellido, fechaNacim, genero);

            manager.Registrar(cliente);

            Console.Write("\nDesea ingresar otro cliente? (s) para confirmar: ");
            string eleccion = Console.ReadLine();

            if (eleccion == "s")
            {
                RegistrarCliente(manager);
            }
        }

        public static void MostrarClientes(ManagerClientes manager)
        {
            Cliente[] clientes = manager.GetTodos();

            if (clientes[0] != null)
            {
                Console.WriteLine($"El número de entradas en clientes es: {clientes.Length}");
                Console.Write("---------  Inicio de la lista de clientes  ---------\n\n");
                Console.Write("Los clientes registrados son: \n\n");
                foreach (var cliente in clientes)
                {
                    if (cliente != null)
                    {
                        Console.WriteLine($"ID: {cliente.Id}, Nombre: {cliente.Nombre}, Apellidos: {cliente.PrimApellido} {cliente.SegApellido}, Género: {cliente.Genero}, Fecha de nacimiento: {cliente.FechaNacimiento}");
                    }
                }
                Console.Write("\n\n---------  Fin de la lista de clientes  ---------");
            }
            else
            {
                Console.WriteLine("No existen registros de clientes.");
            }
        }

        public static void RegistrarRestaurantePlato(ManagerRestaurantePlatos managerRestPlato, ManagerRestaurantes managerRest, ManagerPlatos managerPlato)
        {
            int idRestaurante = 0;
            int idPlato = 0;
            bool esValido = false;

            // Valida los datos ingresados
            while (!esValido)
            {
                try
                {
                    Console.Write("Ingrese el ID del restaurante: ");
                    idRestaurante = Convert.ToInt32(Console.ReadLine());
                    esValido = true;
                }
                catch (FormatException)
                {
                    Console.Write("Debe ingresar un ID de restaurante válido.\n");
                }

                try
                {
                    Console.Write("Ingrese el ID del plato: ");
                    idPlato = Convert.ToInt32(Console.ReadLine());
                    esValido = true;
                }
                catch (FormatException)
                {
                    Console.Write("Debe ingresar un ID de plato válido.\n");
                }
            }


            // Revisa si existen los IDs ingresados
            if (managerRest.GetPorId(idRestaurante) != null && managerPlato.GetPorId(idPlato) != null)
            {
                RestaurantePlato restPlato = new(idRestaurante, idPlato);

                managerRestPlato.Registrar(restPlato);
                Console.WriteLine("Plato registrato en el restaurante de manera correcta.");
            }
            else
            {
                Console.WriteLine("El ID del restaurante o plato no existe.");
            }

            Console.Write("\nDesea registrar otro plato en un restaurante? (s) para confirmar: ");
            string eleccion = Console.ReadLine();

            if (eleccion == "s")
            {
                RegistrarRestaurantePlato(managerRestPlato, managerRest, managerPlato);
            }
        }

        public static void MostrarRestaurantePlato(ManagerRestaurantePlatos managerRestPlato, ManagerRestaurantes managerRest, ManagerPlatos managerPlato)
        {
            int idRestaurante;
            bool esValido = false;

            while (!esValido)
            {
                try
                {
                    Console.Write("Ingrese el ID del restaurante: ");
                    idRestaurante = Convert.ToInt32(Console.ReadLine());
                    esValido = true;

                    // Valida que el restaurante exista
                    if (managerRest.GetPorId(idRestaurante) != null)
                    {
                        Restaurante restaurante = managerRest.GetPorId(idRestaurante);
                        Console.WriteLine($"El restaurante elegido es:\nID: {restaurante.Id}, Nombre: {restaurante.Nombre}, Dirección: {restaurante.Direccion}, Activo: {restaurante.Activo}, Teléfono: {restaurante.Telefono}");
                        Console.WriteLine($"Los platos asociados al restaurante {managerRest.GetPorId(idRestaurante).Nombre} son:\n");

                        foreach (var restaurantePlato in managerRestPlato.GetTodos())
                        {
                            if (restaurantePlato != null && restaurantePlato.IdRestaurante == idRestaurante)
                            {
                                var plato = managerPlato.GetPorId(restaurantePlato.IdPlato);
                                Console.WriteLine($"ID del plato: {plato.Id}, nombre: {plato.Nombre}, Precio: {plato.Precio}, ID de la categoría: {plato.Categoria.Id}, Descripción de la categoría: {plato.Categoria.Descripcion}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Id de restaurante inválido.");
                    }
                }
                catch (FormatException)
                {
                    Console.Write("Debe ingresar un ID válido.\n");
                }
            }
        }
    }
}
