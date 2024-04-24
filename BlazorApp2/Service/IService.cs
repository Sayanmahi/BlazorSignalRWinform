using BlazorApp2.Model;

namespace BlazorApp2.Service
{
    public interface IService
    {
        Task AddEmployee(Employee e);
        Task AddMessage(string message);
    }
}
