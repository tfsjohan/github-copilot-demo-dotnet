using System.Text.Json.Serialization;

namespace Api.Services;

/*
Create a class Joke class that can be serialized from the Chuck Norris API.
Make sure to use the correct property names and types.
Serialize/deseralize **all** property names to lowercase snake case.

```json
{
   "icon_url" : "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
   "id" : "Bup36JbASxW5R-HzSI5ygA",
   "url" : "",
   "value" : "Chuck Norris once participated in a 100 mt race and obviously came first, light came second."
}
```
*/

public class Joke
{
    [JsonPropertyName("icon_url")] public string IconUrl { get; set; }

    [JsonPropertyName("id")] public string Id { get; set; }

    [JsonPropertyName("url")] public string Url { get; set; }

    [JsonPropertyName("value")] public string Value { get; set; }
}