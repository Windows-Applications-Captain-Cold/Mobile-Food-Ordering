using System.Collections;

namespace Teamer.Repository
{
    public interface IRepository<T>
    {
        ICollection GetAsync();

        ICollection GetByIdAsync();

        ICollection PutAsync();

        ICollection DeleteAsync();

        ICollection PostAsyng();
    }
}