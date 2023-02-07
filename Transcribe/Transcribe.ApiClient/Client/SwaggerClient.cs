using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcribe.ApiClient.Client
{
    public class SwaggerClient
    {

        public const string BASE_URL = "http://10.0.2.2:8000";
        public string BaseUrl = BASE_URL;

        public SwaggerClient() 
        {
        }

        public static HttpClient CreateClient()
        {
            HttpClient client = new(new HttpClientHandler(), false)
            {
                Timeout = TimeSpan.FromMinutes(3)
            };

            return client;
        }
    }
}
