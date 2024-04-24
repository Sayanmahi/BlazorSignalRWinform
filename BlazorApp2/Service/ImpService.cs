using BlazorApp2.Model;
using BlazorApp2.Utility;
using Newtonsoft.Json.Linq;

namespace BlazorApp2.Service
{
    public class ImpService : IService
    {
        private readonly IBaseService _baseService;
        public ImpService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task AddEmployee(Employee e)
        {
             await _baseService.SendAsync(new RequestDTO()
            {
                ApiType = SD.ApiType.POST,
                Data = e,
                Url = "https://localhost:7031/api/Home/Post"


             });
        }

        public async Task AddMessage(string message)
        {
                await _baseService.SendAsync(new RequestDTO()
                {
                    ApiType = SD.ApiType.POST,
                    Data = message,
                    Url = "https://localhost:7031/PushMessage"


                });
        }
    }
}
