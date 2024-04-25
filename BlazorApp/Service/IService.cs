using BlazorApp.Model;

namespace BlazorApp.Service
{
    public interface IService
    {
        Task AddEmployee(Employee e);
        Task AddMessage(string message);
        Task<string> SeeConnectedUsers();
    }
}
