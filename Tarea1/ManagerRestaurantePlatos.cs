using System.Xml.Linq;

namespace Tarea1
{
    public class ManagerRestaurantePlatos : IManager<RestaurantePlato>
    {
        private RestaurantePlato[] _restaurantePlatos = new RestaurantePlato[20];
        private int _cuentaRestaurantePlatos = 0;

        public void Registrar(RestaurantePlato restaurantePlato)
        {
            if (_cuentaRestaurantePlatos < 20)
            {
                _restaurantePlatos[_cuentaRestaurantePlatos++] = restaurantePlato;
            } else
            {
                Console.WriteLine("El número máximo de platos (20) ya se ha alcanzado.");
            }
        }
        public RestaurantePlato[] GetTodos()
        {
            return _restaurantePlatos;
        }
    }
}
