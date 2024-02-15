namespace Api.Services;

/*
 Create a class that matches the following JSON:
```json 
{
   "icon_url" : "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
   "id" : "Bup36JbASxW5R-HzSI5ygA",
   "url" : "",
   "value" : "Chuck Norris once participated in a 100 mt race and obviously came first, but Albert Einstein died after watching that cos light came second."
}
```
*/

public class Joke
{
    public string IconUrl { get; set; }
    public string Id { get; set; }
    public string Url { get; set; }
    public string Value { get; set; }
}










