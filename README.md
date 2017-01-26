# Kong
Detect browsers using user agent strings in .NET. Inspired by [Bowser](https://github.com/ded/bowser).

## License
[MIT License](https://github.com/BigBadBleuCheese/SignalREST/blob/master/LICENSE)

## What is this for?
This library can be used to detect the characteristics of a web browser by examining the value of its HTTP request User-Agent header.

## How to use

### Step 1: Install the NuGet package
You can either use the Package Manager Console:

    Install-Package Epiforge.Kong

Or use the NuGet Package Manager to install `Epiforge.Kong` as a NuGet package in your project.

### Step 2: Create instances of the Browser class with User-Agent header values
Example in a [Microsoft Web API](https://www.asp.net/web-api) controller:

```
using System.Web.Http;

public class ExampleController : ApiController
{
    [HttpGet, Route("isMobile")]
    public IHttpActionResult IsMobile()
    {
        // Return true if the caller is a mobile browser; otherwise, false.
        return Ok(new Kong.Browser(string.Join(" ", Request.Headers.GetValues("User-Agent"))).Mobile);
    }
}
```

Example in a [Microsoft SignalR](https://www.asp.net/signalr) hub:

```
using Microsoft.AspNet.SignalR;

public class ExampleHub : Hub
{
    public bool IsMobile()
    {
        // Return true if the connected client is a mobile browser; otherwise, false.
        return new Kong.Browser(string.Join(" ", Context.Request.Headers.GetValues("User-Agent"))).Mobile;
    }
}
```
