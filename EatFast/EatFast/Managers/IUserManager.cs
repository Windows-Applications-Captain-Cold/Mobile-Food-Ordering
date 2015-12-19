namespace Teamer.Managers
{
    using System.Threading.Tasks;
    public interface IUserManager
    {
        Task<string> Login(string username, string password);
        Task<string> Register(string username, string password);
    }
}