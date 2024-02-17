# GitHub Copilot

## General tips

Sometimes Copilot will suggest code that is not the best practice. It's important to always review the code and make
sure it's following the best practices. You can often ask Copilot Chat if the code actually is following best practices.

Copilot AutoComplete is great at completing code or having a comment as a prompt, but sometimes it can be a bit too keen
on suggesting more comments instead of code.In these cases, it helps to start writing some code to get it started.

It also helps to already have a `namespace` and some `using` statements.

A top level comment can add useful context for the purpose of the file. Keep it short, specific and to the point.

Copilot does not yet know about the latest C# features, so it might suggest older ways of doing things. For example how
to handle nulls and primary constructors.

Copilot might not get it right the first time, so don't forget to iterate on the prompts or code to improve it over
time.

And don't forget, Copilot is a tool to help you, not replace you.

## The Chuck Norris Joke API

Let's see if we can make a Chuck Norris API with GitHub Copilot. The API is available at
`https://api.chucknorris.io/jokes/random`. Your mission, if you choose to accept it, is to create an API
that fetches a random joke from the Chuck Norris API using Copilot and making sure that the code
follows the best practices.

Here's what we'll try to do:

* Make a `Joke` class
* Make a `JokeService` that can be used in dependency injection
* Make a `JokeController` that can serve up some fresh jokes
* Make some tests

> **Tip:** Copilot can use context from all open files, so try to open files related to what you're working on.

### Make a Joke class

Here's a sample response from the joke api:

```json
{
  "icon_url": "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
  "id": "Bup36JbASxW5R-HzSI5ygA",
  "url": "",
  "value": "Chuck Norris once participated in a 100 mt race and obviously came first, light came second."
}
```

**Create a class called `Joke` that represent the joke response.**

> Pay extra attention to the `icon_url` field. Can you make sure that the `icon_url` is mapped
> to the C# property `IconUrl`? There are several ways to do this, try to find the best one. Is Copilot Chat or
> Autocomplete better? Does it matter if you have added a `using` statement for `System.Text.Json.Serialization`?

<details>
<summary>Example prompt (Autocomplete)</summary>
<pre>
/*
Create a class Joke class that can be serialized from the Chuck Norris API. 
Make sure to use the correct property names and types. Serialize/deserialize all properties names to lower snake case.
```json 
{
   "icon_url" : "https://assets.chucknorris.host/img/avatar/chuck-norris.png",
   "id" : "Bup36JbASxW5R-HzSI5ygA",
   "url" : "",
   "value" : "Chuck Norris once participated in a 100 mt race and obviously came first, but Albert Einstein died after watching that cos light came second."
}
```
*/
</pre>
</details>

### Make a JokeService

Let's create a service called `JokeService` that will be responsible for fetching the joke from the API. The class
should fetch a random joke from the API and return it as a `Joke` object. The API endpoint
is `https://api.chucknorris.io/jokes/random`.

This service should be **registered with the Dependency Injection container**. Make sure that it is testable and that
the http calls to the api can be mocked. Can Copilot Chat help you with that?

For that **you will need a IJokeService interface that has a public method called GetRandomJoke that returns a Joke.
You will also need a JokeService class that implements the IJokeService interface**.

> The method will make a http call, so is there something you need to be specific about in the interface and
> implementation to make that work?

> Can you avoid having the base url hardcoded in the JokeService class and define in `Program.cs`? Is that something
> Copilot Chat can help with?

<details>
<summary>Example prompt (Autocomplete) for IJokeService</summary>
<pre>
// Make a public interface called IJokeService that has a public async method called GetRandomJoke.
// The method returns a Joke object. 
</pre>
</details>

<details>
<summary>Example prompt (Autocomplete) for JokeService</summary>
<pre>
/*
 * Create a JokeService class that implements IJokeService.
 * The class should take an HttpClient as a constructor argument.
 * The GetRandomJoke method should make a GET request to `https://api.chucknorris.io/jokes/random` and return the result as a Joke object.
 */ 
</pre>
</details>

### Add documentation to the GetRandomJoke method

Use the `/doc` slash command to add documentation for the GetRandomJoke method. 

### Make a JokeController

Let's make the JokeController that will have a single GET endpoint that returns a random joke.

The controller should get an instance of `IJokeService` injected in the constructor.

**Make a `GET` endpoint for `/` that returns a random joke.**

> How does the result of your prompts differ if you have IJokeService and JokeService open or closed?

<details>
<summary>Example prompt (Autocomplete)</summary>
<pre>
// Make a JokeController that uses the IJokeService.
// The controller should have a single Http Get endpoint that returns a random joke.
</pre>
</details>

### Add Swagger documentation for the JokeController

See if you can get Copilot to help you add Swagger documentation for the JokeController.
It can produce both a 200 Ok response for a Joke and a 500 Internal Server Error response.

<details>
<summary>Example prompt (Chat)</summary>
<pre>
Add Swagger documentation attributes to the GetJoke action
</pre>
</details>

