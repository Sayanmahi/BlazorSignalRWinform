using BlazorApp.Model;

namespace BlazorApp.Service
{
    public interface IBaseService
    {
        Task<string> SendAsync(RequestDTO requestDTO);
    }
}
