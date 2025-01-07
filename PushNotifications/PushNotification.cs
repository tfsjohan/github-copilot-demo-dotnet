using Newtonsoft.Json;

namespace PushNotifications;

public class PushNotification
{

    [JsonProperty("to")]
    public string To { get; set; }

    [JsonProperty("registration_ids")]
    public string[] RegistrationIDs { get; set; }

    [JsonProperty("data")]
    public Dictionary<string, string> Data { get; set; }

    [JsonProperty("notification")]
    public PushNotificationMessage Notification { get; set; }

    [JsonProperty("content_available")]
    public bool ContentAvailable { get; set; } = true;

    public string Priority { get; set; } = "high";

    [JsonProperty("collapse_key")]
    public string CollapeKey { get; set; }

    [JsonProperty("android")]
    public PushNotificationPlatformOverride Android { get; set; }

    [JsonProperty("apns")]
    public PushNotificationPlatformOverride Ios { get; set; }

    [JsonProperty("webpush")]
    public PushNotificationPlatformOverride Web { get; set; }
}

//public static class PushNotificationClickActionExtensions
//{
//    public static void AndroidClickAction(this PushNotification notification, string clickAction)
//    {
//        notification.Android = new PushNotificationPlatformOverride()
//        {
//            Notification = new PushNotificationClickAction()
//            {
//                ClickAction = clickAction
//            }
//        };
//    }

//    public static void WebClickAction(this PushNotification notification, string clickAction)
//    {
//        notification.Web = new PushNotificationPlatformOverride()
//        {
//            Notification = new PushNotificationClickAction()
//            {
//                ClickAction = clickAction
//            }
//        };
//    }

//    public static void IosClickAction(this PushNotification notification, string clickAction)
//    {
//        notification.Ios = new PushNotificationPlatformOverride()
//        {
//            Notification = new PushNotificationClickAction()
//            {
//                ClickAction = clickAction
//            }
//        };
//    }
//}

public class PushNotificationPlatformOverride
{
    [JsonProperty("data")]
    public Dictionary<string, string> Data { get; set; }

    [JsonProperty("notification")]
    public PushNotificationMessage Notification { get; set; }
}

public class PushNotificationClickAction
{
    [JsonProperty("click_action")]
    public string ClickAction { get; set; }
}

public class PushNotificationMessage
{
    public string Title { get; set; }

    public string Body { get; set; }

    [JsonProperty("click_action")]
    public string ClickAction { get; set; }

    public string Sound { get; set; } = "default";

    public string Icon { get; set; } = "ic_notification";
}


public class PushNotificationResponse
{
    [JsonProperty("multicast_id")]
    public long MulticastId { get; set; }

    [JsonProperty("success")]
    public int Success { get; set; }

    [JsonProperty("failure")]
    public int Failure { get; set; }

    [JsonProperty("canonical_ids")]
    public int CanonicalIds { get; set; }

    [JsonProperty("results")]
    public PushNotificationResponseResult[] Results { get; set; }
}

public class PushNotificationResponseResult
{
    [JsonProperty("message_id")]
    public string MessageId { get; set; }
}

public static class PushNotificationClickActions
{
    public static string Group = "se.digitalthjarta.carehood.GROUP";
}