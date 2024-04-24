using BlazorApp2.Model;
using static BlazorApp2.Utility.SD;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace BlazorApp2.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> SendAsync(RequestDTO requestDTO)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("WebAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(requestDTO.Url);
                if (requestDTO.Data != null)
                {
                   message.Content = new StringContent(JsonConvert.SerializeObject(requestDTO.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? apiResponse = null;
                switch (requestDTO.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                apiResponse = await client.SendAsync(message);
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return( "Not Found" );
                    case HttpStatusCode.Forbidden:
                        return ("Forbidden");
                    case HttpStatusCode.Unauthorized:
                        return ("Unauthorized");
                    case HttpStatusCode.InternalServerError:
                        return ("Internal Server Error");
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDTO = JsonConvert.DeserializeObject<string>(apiContent);
                        return apiResponseDTO;
                       

                }
            }
            catch (Exception e)
            {
                return (e.Message.ToString());
            }
        }
    }
}
