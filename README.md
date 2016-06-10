# DotNetCore Tutorial for Unity3d for absolute noobs


## What is .NET Core
- Cross Platform C#
- Runs from a folder on OSX or Linux
- Stripped down high performance
- WebApi / MVC is an http framework build on Core

## Prerequisites 
- GET IT https://www.microsoft.com/net/core#windows
- READ IT https://docs.asp.net/en/latest/tutorials/first-web-api.html

## Good Links
- https://weblog.west-wind.com/posts/2016/Jun/06/Publishing-and-Running-ASPNET-Core-Applications-with-IIS
- https://docs.efproject.net/en/latest/cli/dotnet.html#installation
- https://github.com/aspnet/EntityFramework/wiki
	
## Goals
- Build a simple HTTP server
- SQL Database using Entity Framework
- High Score Controller
- Chat Websocket service (TODO)
- Unity3d client

## 1) Init the thing
- Install the sdk
- Open VS (Or get another tutorial)
- File/New Project .NET Core/WebApplication
- Select WebAPI
- I suggest No Authentication (Identity works great and has many OAUTH extensions, but I prefer to do that all myself).
- Close your eyes
- Open PackageManagerConsole
- Restore packages
  - nugget is a package / dependency repository. Like a free asset store.
  
Run the app, you now have a web server running.

## 2) Configuration
- All apps in dotnetcore are glorified console apps. Program.cs is our entry point.
- In Main, we configure our web server. Check out my comments
- In Startup we configure the MVC/WebApi part of the app. Check out my comments.
- For the most part you can leave this alone even in advanced scenarios.

## 3) Entity Framework
Entity framework is an Database Object Relationship Manager. Simply put, it is a strongly typed api for manipulating persistent data. With EF you have a DataContext (the database object and unit of work), DBSets or lists of tables in the database, and entities or classes which have properties which map to the columns of your tables. Everything in EF is code first, so, you write a C# file, close your eyes and you have a database. There are many other features such as navigational properties (table joins) and providers for other database types such as postgre.


## 4) Import EF
Add these things to the project.json. Note that we are using SQLITE as our persistence provider.

- Open PackageManagerConsole
- Type This

> Install-Package Microsoft.EntityFrameworkCore -Pre

> Install-Package Microsoft.EntityFrameworkCore.Tools -Pre

> Install-Package Microsoft.EntityFrameworkCore.Sqlite -Pre

> *PROTIP* Update-Package -reinstall will re-reference all dlls things break

## 5) Define a database

- Open ScoreModel.cs, this defines our single data table
- Open ScoreContext.cs, this defines our database
- Note that we ensure the database is create in Programe.cs

## 6) Define our controller

Next we must define a controller, this is responsible for serving the data to the client. Here is the controller life cycle.

- Application receives a request
- Application routes the request to a controller and action
- Routing is managed by the Route filter
- Magic happens, and the request becomes a strongly typed object or parameter array
- Action returns an http result

There are a number of extensibility points here. Namely :
- Global Filters are 'pre' and 'post' request/result processors
- Controller and Action filters are pre/post processors, but at a more granular level
 - Filters for most everything: Caching, authentication, Sanity checks, ect
- Routes are tied to the url path. You can be as complex as you want.
- Most routes follow the http://{site.com}/{controller}/{optional:id} paradigm with HTTPVERBS use to select to correct action
- Verbs include GET, POST, PUT, DELETE
- The full http request and response object is available, for things like JWT and BASIC authentication in the header.
- I personally like to use http://{site.com}/{controller}/{action}/{optional:id} paradigm and use POST for everything.
 - This was due to Unity's WWW limitation

## 7) Test it

- On the project file, right click, options, set the default url to point to our ScoreController
- I use POSTMON chrome extension, now make up some HTTP requests to the server
- Server supports GET/ POST / DELETE verbs
- GET http://{url}/api/Score
- GET http://{url}/api/Score/{id}
- POST http://{url}/api/Score/ (with Json Body
- Delete http://{url}/api/Score/{id}

## 8) Setup socket for real time chat
- TODO






