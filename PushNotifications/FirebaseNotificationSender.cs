using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace PushNotifications;

public class FirebaseNotificationSender(IConfiguration configuration)
{
    public PushNotificationResponse? Send(PushNotification model)
    {
        try
        {
            const string url = "https://fcm.googleapis.com/fcm/send";
            var serverKey = configuration["gcm:ServerKey"];

            var httpWReq = (HttpWebRequest)WebRequest.Create(url);

            Encoding encoding = new UTF8Encoding();

            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var json = JsonConvert.SerializeObject(model, Formatting.None, settings);
            var data = encoding.GetBytes(json);

            httpWReq.ProtocolVersion = HttpVersion.Version11;
            httpWReq.Method = "POST";
            httpWReq.ContentType = "application/json";

            httpWReq.Headers[HttpRequestHeader.Authorization] = $"key={serverKey}";
            httpWReq.ContentLength = data.Length;

            var stream = httpWReq.GetRequestStream();
            stream.Write(data, 0, data.Length);
            stream.Close();

            var response = (HttpWebResponse)httpWReq.GetResponse();
            var responseStream = response.GetResponseStream();
            if (responseStream != null)
            {
                using (var reader = new StreamReader(responseStream))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var serializer = new JsonSerializer();
                        return serializer.Deserialize<PushNotificationResponse>(jsonReader);
                    }
                }
            }

            return null;
        }
        catch (WebException ex)
        {
            Console.WriteLine($"Failed to sent notification: {ex.Message}");
            return null;
        }
    }
}
