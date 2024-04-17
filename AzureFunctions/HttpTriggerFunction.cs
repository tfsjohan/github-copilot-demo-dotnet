using Microsoft.Azure.Functions.Worker;

namespace AzureFunctions
{

    public static class BatchProcessUrls
    {
        [Function("BatchProcessUrls")]
        public static void Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] InputModel model, 
            FunctionContext context)
        {
            

        }
    }

    public class InputModel {
        public IEnumerable<string> Urls { get; set; } = [];
    }

    public class ApiData {
        public required string Url { get; set; }
        public required string Title { get; set; }
        public string? Body { get; set; }
    }

    public class OutputModel {
        public IEnumerable<ApiData> Data { get; set; } = [];
    }
    
}