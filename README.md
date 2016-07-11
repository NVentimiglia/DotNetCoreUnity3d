# DotNetCore Tutorial for Unity3d for absolute noobs


## What is .NET Core
- Cross Platform C#
- Runs from a folder on OSX or Linux
- Stripped down high performance
- WebApi / MVC is an http framework built on Core

## What is this ?
- A minimalistic HTTP server with...
- SQL(Lite) Database using Entity Framework
- High Score Api Controller
- Chat Websocket service
- Unity3d client

## Prerequisites 
- GET IT https://www.microsoft.com/net/core#windows
- READ IT https://docs.asp.net/en/latest/tutorials/first-web-api.html

## Official Links
- [Installation Guide](https://docs.efproject.net/en/latest/cli/dotnet.html#installation)
- [Github repo for dotnetcore](https://dotnet.github.io/)
- [SLACK SUPPORT !](http://tattoocoder.com/aspnet-slack-sign-up/)
- [Entity Framework Wiki](https://github.com/aspnet/EntityFramework/wiki)

## Tools
- [Chrome HTTP Client](www.getpostman.com)
- [Chrome Websocket Client](https://github.com/hakobera/Simple-WebSocket-Client)
- [Docker tutorial] (http://blog.alexellis.io/instant-dotnet-core-rc2-with-docker/)
- [Digital Ocean Videos](https://www.youtube.com/watch?v=IpwHTs7QbQs)


## Good Samples
- [MVC Music Store 'website'](https://docs.asp.net/en/latest/tutorials/first-mvc-app/index.html)

## Good to knows
- [Routing Deep Dive](http://stephenwalther.com/archive/2015/02/07/asp-net-5-deep-dive-routing)
- [Basic Websockets](https://medium.com/@turowicz/websockets-in-asp-net-5-6094319a15a2#.kejwy8ync)
- [Async Locks](http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10266983.aspx)
- [Custom View Locations](http://hossambarakat.net/2016/02/16/asp-net-core-mvc-feature-folders/)
- [JWT Authentication](http://stackoverflow.com/questions/30546542/token-based-authentication-in-asp-net-5-vnext-refreshed/33217340#33217340)
- [OAuth LinkedIn Example](https://auth0.com/blog/2016/06/13/authenticating-a-user-with-linkedin-in-aspnet-core/)
- [ELMAH exception web viewer](http://dotnetthoughts.net/using-elmah-in-aspnet-core/)
- [OData protocal (Lambda Queries !)](http://www.odata.org/)


## Facts
- All apps in dotnetcore are glorified console apps. Program.cs is our entry point.
- In Startup.cs we configure the MVC/WebApi part of the app.
- Besides Startup and Program.cs code exists as /Infrastructure or /Modules
 - Infrastructure includes utilities and componenets
 - Modules includes domain services, controllers, and models
- MVC has some magic that might be hard to grasp.
 - Routing is the convention to send HTTP requests to 'controllers'
 - View Location is the convention for finding html 'views' from controllers (for non API controller)
 - Entity framework defines a database using annotations
 - ModelState can validate a data object using annotations

## Entity Framework
Entity framework is an Database Object Relationship Manager. Simply put, it is a strongly typed api for manipulating and persistent data. With EF you have a DataContext (the database object and unit of work). Inside the context you have DBSets, a collection type, one for each table in the database. DBSets are generic of you entity type. Entities define your table columns by way of properties and annotations. Everything in EF is code first, so, you write a C# file, close your eyes and you have a database. There are many other features such as navigational properties (table joins) and providers for other database types such as postgres.

We will use something called Nuget to import dependencies. 

- Open PackageManagerConsole

- Type This

> Install-Package Microsoft.EntityFrameworkCore -Pre

> Install-Package Microsoft.EntityFrameworkCore.Tools -Pre

> Install-Package Microsoft.EntityFrameworkCore.Sqlite -Pre

> *PROTIP* Update-Package -reinstall will re-reference all dlls if things break


### Define a database

- Open ScoreModel.cs, this defines our single data table
- Open ScoreContext.cs, this defines our database
- Note that we ensure the database is create in Program.cs
- Generally the database would exist outside in a shared domain and reference models from all domains.
- The ScoreContext defines that it is using SQLite, this should really be handled by Startup

## Test it

- On the project file, right click, options, set the default url to point to our ScoreController
- I use POSTMON chrome extension, now make up some HTTP requests to the server
- Server supports GET/ POST / DELETE verbs
- GET http://{url}/api/Score
- GET http://{url}/api/Score/{id}
- POST http://{url}/api/Score/ (with Json Body
- Delete http://{url}/api/Score/{id}

## Setup socket for real time chat

- Get the Nuget package

> Import-Package Microsoft.AspNetCore.WebSockets.Server -Pre

- You will need to define a handler for websocket requests (ChatService.cs and ChatClient.cs).

- You will also need to register this with the web app in Startup.cs

- You can test it (Websocket extension above) by connectin to ws://{localhost:port}

- The chat service is a simple broadcast relay


## Unity Example

look at the code. Everything runs from Debug ContextMenu commands on the debug behaviour instance (on the main camera). Running the app is required for the chat demo due to main thread callback mechinism.
