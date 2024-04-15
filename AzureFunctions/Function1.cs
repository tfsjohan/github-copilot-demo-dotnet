// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using System;
using Azure.Identity;
using Azure.Messaging;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace AzureFunctions
{
    // Create an Azure Function that listens to an Event Grid event and stores the event data in a Cosmos DB collection.
    public static class Function1
    {
        [Function("Function1")]
        public static void Run([EventGridTrigger] EventGridEvent eventGridEvent, FunctionContext context)
        {
            

        }
    }
    
}
