// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using Azure.Messaging.EventGrid;
using Microsoft.Azure.Functions.Worker;


namespace AzureFunctions
{
    

    
    
    public class ClimateSensorData {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public required string SensorId { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}
