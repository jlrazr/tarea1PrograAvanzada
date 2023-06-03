using System.Xml.Linq;

namespace Tarea1
{
    public class ManagerRestaurantes : IManager<Restaurante>
    {
        private Restaurante[] _restaurantes = new Restaurante[20];
        private int _cuentaRestaurantes = 0;

        public void Registrar(Restaurante restaurante)
        {
            if (_cuentaRestaurantes < 20)
            {
                _restaurantes[_cuentaRestaurantes++] = restaurante;
                Console.WriteLine("El restaurante fue registrado con éxito.");
            } else
            {
                Console.WriteLine("El número máximo de restaurantes (20) ya se ha alcanzado.");
            }
        }

        public Restaurante[] GetTodos()
        {
            return _restaurantes;
        }

        public Restaurante GetPorId(int id)
        {
            foreach (var restaurante in _restaurantes)
            {
                if (restaurante != null && restaurante.Id == id)
                {
                    return restaurante;
                }
            }

            return null;
        }
    }
}
