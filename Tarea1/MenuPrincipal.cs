using Tarea1;

internal class Program
{
    // Inicialización de los managers
    public static ManagerRestaurantes managerRest = new();
    public static ManagerPlatos managerPlatos = new();
    public static ManagerCategPlatos managerCategPlatos = new();
    public static ManagerClientes managerClientes = new();

    private static void Main(string[] args)
    {
        int eleccion = 0;

        while (eleccion != 11)
        {
            eleccion = MuestraMenu();

            switch (eleccion)
            {
                case 1:
                    Helpers.RegistrarRestaurante(managerRest);
                    break;
                case 2:
                    Helpers.RegistrarCategPlatos(managerCategPlatos);
                    break;
                case 3:
                    Helpers.RegistrarPlato(managerPlatos, managerCategPlatos);
                    break;
                case 4:
                    Helpers.RegistrarCliente(managerClientes);
                    break;
                case 5:
                    // Call method to register dishes per each restaurant
                    break;
                case 6:
                    Helpers.MostrarRestaurantes(managerRest);
                    break;
                case 7:
                    Helpers.MostrarCategPlatos(managerCategPlatos);
                    break;
                case 8:
                    Helpers.mostrarPlatos(managerPlatos);
                    break;
                case 9:
                    Helpers.MostrarClientes(managerClientes);
                    break;
                case 10:
                    // Call method to query dishes per restaurant
                    break;
                case 11:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor ingrese un número entre 1 y 11.");
                    break;
            }
        }

        static int MuestraMenu()
        {
            Console.WriteLine("\nMENÚ PRINCIPAL");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("1. Registrar restaurante");
            Console.WriteLine("2. Registrar categorias de platos");
            Console.WriteLine("3. Registrar platos");
            Console.WriteLine("4. Registrar clientes");
            Console.WriteLine("5. Registrar platos para un restaurante");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("6. Consultar restaurantes");
            Console.WriteLine("7. Consultar categorias de platos");
            Console.WriteLine("8. Consultar platos");
            Console.WriteLine("9. Consultar clientes");
            Console.WriteLine("10. Consultar platos por restaurante");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("11. Salir");

            Console.Write("\nIngrese su elección (1-11): ");
            int eleccion;

            try
            {
                eleccion = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Opción inválida. Por favor ingrese un número entre 1 y 11.");
                eleccion = MuestraMenu(); // Muestra el menú de nuevo si se ingresa un valor incorrecto
            }

            return eleccion;
        }
    }
}