using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Transcribe.ApiClient.Client
{
    public partial class TranscribeClient
    {
        partial void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url)
        {
            if (request.Content is not StreamContent streamContent)
            {
                return;
            }

            if (streamContent.Headers.ContentType?.MediaType != "multipart/form-data")
            {
                return;
            }

            // workaround for when we are working with multipart requests
            // see https://github.com/RicoSuter/NSwag/issues/2419#issuecomment-818433921
            var boundary = System.Guid.NewGuid().ToString();

            var content = new System.Net.Http.MultipartFormDataContent(boundary);

            content.Headers.Remove("Content-Type");
            content.Headers.TryAddWithoutValidation("Content-Type", "multipart/form-data; boundary=" + boundary);
            content.Add(streamContent, "file", "file");
            request.Content = content;

        }
    }
}
