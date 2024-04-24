using BlazorApp2.Utility;
using static BlazorApp2.Utility.SD;

namespace BlazorApp2.Model
{
    public class RequestDTO
    {
        public ApiType ApiType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
    }
}
