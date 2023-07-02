using Tarea1;

internal class Program
{
    // Inicialización de los managers
    public static ManagerRestaurantes managerRest = new();
    public static ManagerPlatos managerPlatos = new();
    public static ManagerCategPlatos managerCategPlatos = new();
    public static ManagerClientes managerClientes = new();
    public static ManagerRestaurantePlatos managerRestPlatos = new();
    public static ManagerExtra managerExtra = new();

    private static void Main(string[] args)
    {
        int eleccion = 0;

        while (eleccion != 12)
        {
            eleccion = MuestraMenu();

            switch (eleccion)
            {
                case 1:
                    Console.Clear();
                    Helpers.RegistrarRestaurante(managerRest);
                    break;
                case 2:
                    Console.Clear();
                    Helpers.RegistrarCategPlatos(managerCategPlatos);
                    break;
                case 3:
                    Console.Clear();
                    Helpers.RegistrarPlato(managerPlatos, managerCategPlatos);
                    break;
                case 4:
                    Console.Clear();
                    Helpers.RegistrarCliente(managerClientes);
                    break;
                case 5:
                    Console.Clear();
                    Helpers.RegistrarRestaurantePlato(managerRestPlatos, managerRest, managerPlatos);
                    break;
                case 6:
                    Console.Clear();
                    Helpers.MostrarRestaurantes(managerRest);
                    break;
                case 7:
                    Console.Clear();
                    Helpers.MostrarCategPlatos(managerCategPlatos);
                    break;
                case 8:
                    Console.Clear();
                    Helpers.mostrarPlatos(managerPlatos);
                    break;
                case 9:
                    Console.Clear();
                    Helpers.MostrarClientes(managerClientes);
                    break;
                case 10:
                    Console.Clear();
                    Helpers.MostrarRestaurantePlato(managerRestPlatos, managerRest, managerPlatos);
                    break;
                case 11:
                    Console.Clear();
                    Helpers.RegisterExtra(managerExtra, managerCategPlatos);
                    break;
                case 12:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Por favor ingrese un número entre 1 y 12.");
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
            Console.WriteLine("11. Registrar extra para una categoría");
            Console.WriteLine("-------------------------------------------------------------------------");
            Console.WriteLine("12. Salir");

            Console.Write("\nIngrese su elección (1-12): ");
            int eleccion;

            try
            {
                eleccion = Int32.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                eleccion = MuestraMenu(); // Muestra el menú de nuevo si se ingresa un valor incorrecto
            }

            return eleccion;
        }
    }
}