using System.Security.AccessControl;
using static BlazorApp.Utility.SD;

namespace BlazorApp.Model
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
