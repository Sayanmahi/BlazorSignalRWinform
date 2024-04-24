namespace BlazorApp.Utility
{
    public class SD
    {
        public static string WebApi { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
