# DotNetCore Tutorial for Unity3d for absolute noobs


## What is .NET Core
- Cross Platform C#
- Runs from a folder on OSX or Linux
- Stripped down high performance
- WebApi / MVC is an http framework build on Core

## What is this ?
- A minimalistic HTTP server with...
- SQL(Lite) Database using Entity Framework
- High Score Api Controller
- Chat Websocket service
- Unity3d client

## Prerequisites 
- GET IT https://www.microsoft.com/net/core#windows
- READ IT https://docs.asp.net/en/latest/tutorials/first-web-api.html

## Good Links
- https://weblog.west-wind.com/posts/2016/Jun/06/Publishing-and-Running-ASPNET-Core-Applications-with-IIS
- https://docs.efproject.net/en/latest/cli/dotnet.html#installation
- https://dotnet.github.io/
- http://tattoocoder.com/aspnet-slack-sign-up/ (SLACK SUPPORT !)
- https://github.com/aspnet/EntityFramework/wiki
- https://medium.com/@turowicz/websockets-in-asp-net-5-6094319a15a2#.kejwy8ync
- www.getpostman.com a http debug client that runs in chrome (for testing)
- https://github.com/hakobera/Simple-WebSocket-Client websocket chrome client (for testing)
- http://blogs.msdn.com/b/pfxteam/archive/2012/02/12/10266983.aspx

## 1) Facts
- All apps in dotnetcore are glorified console apps. Program.cs is our entry point.
- In Main, we configure our web server. Check out my comments
- In Startup we configure the MVC/WebApi part of the app. Check out my comments.
- For the most part you can leave this alone even in advanced scenarios.
- Besides Startup and Program.cs code exists in /Infrastructure and /Modules
 - Infrastructure includes utilities and componenets
 - Modules includes services, controllers, and domain logic

## 2) Entity Framework
Entity framework is an Database Object Relationship Manager. Simply put, it is a strongly typed api for manipulating persistent data. With EF you have a DataContext (the database object and unit of work), DBSets or lists of tables in the database, and entities or classes which have properties which map to the columns of your tables. Everything in EF is code first, so, you write a C# file, close your eyes and you have a database. There are many other features such as navigational properties (table joins) and providers for other database types such as postgre.


### Import Entity Framework Using Nuget

We will use something called Nuget to import dependencies. 

- Open PackageManagerConsole

- Type This

> Install-Package Microsoft.EntityFrameworkCore -Pre

> Install-Package Microsoft.EntityFrameworkCore.Tools -Pre

> Install-Package Microsoft.EntityFrameworkCore.Sqlite -Pre

> *PROTIP* Update-Package -reinstall will re-reference all dlls if things break

## 3) Define a database

- Open ScoreModel.cs, this defines our single data table
- Open ScoreContext.cs, this defines our database
- Note that we ensure the database is create in Programe.cs
- Generally the database would exist outside in a shared domain and reference models from all domains.
- The ScoreContext defines that it is using SQLite, this should really be handled by Startup

## 4) Test it

- On the project file, right click, options, set the default url to point to our ScoreController
- I use POSTMON chrome extension, now make up some HTTP requests to the server
- Server supports GET/ POST / DELETE verbs
- GET http://{url}/api/Score
- GET http://{url}/api/Score/{id}
- POST http://{url}/api/Score/ (with Json Body
- Delete http://{url}/api/Score/{id}

## 5) Setup socket for real time chat

- Get the Nuget package

> Import-Package Microsoft.AspNetCore.WebSockets.Server -Pre

- You will need to define a handler for websocket requests (ChatService.cs and ChatClient.cs).

- You will also need to register this with the web app in Startup.cs

- You can test it (Websocket extension above) by connectin to ws://{localhost:port}

- The chat service is a simple broadcast relay


# Unity Example

look at the code. Everything runs from Debug ContextMenu commands on the debug behaviour instance (on the main camera). Running the app is required for the chat demo due to main thread callback mechinism.




