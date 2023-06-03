using System.Xml.Linq;

namespace Tarea1
{
    public interface IManager<T>
    {
        void Registrar(T item);
        T[] GetTodos();
    }
}
