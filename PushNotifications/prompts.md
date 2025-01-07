# Migrate Firebase Rest SDK to Firebase Admin SDK

````
This code uses a depracted firebase rest api to send push notifications. I need to update this code to use Firebase Admin SDK instead. Here's what I want help with:

* Update FirebaseNotificationSender to use Firebase Admin SDK
* Make sure it can send to multiple tokens in a single call
* Can handle data-only notifications and content notifications
* Update the PushNotification model to be less coupled to firebase rest sdk. It must have properties for Tokens, Title, Body, Data, ContentAvailable and ClickAction.
* Notification must be able send to Android, iOS and Web.

````

````
Good, but remove all unused properties and classes in PushNotifications.cs
````

````
I don't want the SendAsync method to return a class couple to the Firebase Admin SDK. Make an owned response class with information about how many tokens was valid and invalid and a distinct list of invalid tokens.
````


