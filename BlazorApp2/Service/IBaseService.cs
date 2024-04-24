using BlazorApp2.Model;

namespace BlazorApp2.Service
{
    public interface IBaseService
    {
        Task<string> SendAsync(RequestDTO requestDTO);
    }
}
