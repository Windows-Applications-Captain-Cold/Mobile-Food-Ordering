using System.Collections;
using Windows.Web.Http;

namespace Teamer.Repository
{
    public interface IRepository<T>
    {
        HttpClient HttpClient { get; set; }

        ICollection GetAsync(string url);

        ICollection GetByIdAsync();

        ICollection PutAsync();

        ICollection DeleteAsync();

        ICollection PostAsyng();
    }
}