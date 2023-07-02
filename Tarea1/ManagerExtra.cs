using System.Xml.Linq;

namespace Tarea1
{
    public class ManagerExtra
    {
        private Extra[] _extras;
        private int _numeroExtras;

        public ManagerExtra()
        {
            _extras = new Extra[20];
            _numeroExtras = 0;
        }

        public void RegistrarExtra(Extra extra)
        {
            if (_numeroExtras < 20)
            {
                _extras[_numeroExtras] = extra;
                _numeroExtras++;
            }
        }

        public Extra GetPorId(int id)
        {
            foreach (var extra in _extras)
            {
                if (extra != null && extra.ID == id)
                {
                    return extra;
                }
            }

            return null;  // Devuelve null si no hay resultados
        }

        public Extra[] GetTodos()
        {
            return _extras;
        }
    }
}
