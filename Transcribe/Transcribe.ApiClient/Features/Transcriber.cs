using Transcribe.ApiClient.Client;


namespace Transcribe.ApiClient.Features
{
    public class Transcriber : BaseFeature
    {
        public static async Task<TranscribeResponse> Transcribe(string language, Stream fileStream)
        {
            TranscribeClient client = new(SwaggerClient.BASE_URL, SwaggerClient.CreateClient());
            return await client.UploadAsync(language, fileStream);
        }
    }
}
