using Microsoft.AspNetCore.Http;

namespace UltimateSolutions.WebAPI.Helper
{
    public static class Extensions
    {
        // add header for http to show error with respons
        public static void AddApplicationError(this HttpResponse response, string Message)
        {
            response.Headers.Add("UltimateSolutions-Application-Error", Message);
            response.Headers.Add("Access-Control-Expose-Headers", "Invoice-Application-Error");
            response.Headers.Add("Access-Control-Allow-Origin", "*");
        }
    }
}