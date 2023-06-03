using System.Xml.Linq;

namespace Tarea1
{
    public class ManagerPlatos : IManager<Plato>
    {
        private Plato[] _platos = new Plato[20];
        private int _cuentaPlatos = 0;

        public void Registrar(Plato plato)
        {
            if (_cuentaPlatos < 20)
            {
                _platos[_cuentaPlatos++] = plato;
                Console.WriteLine("El plato fue registrado con éxito.");
            }
        }

        public Plato[] GetTodos()
        {
            return _platos;
        }

        public Plato GetPorId(int id)
        {
            foreach (var plato in _platos)
            {
                if (plato != null && plato.Id == id)
                {
                    return plato;
                }
            }

            return null;
        }
    }
}
