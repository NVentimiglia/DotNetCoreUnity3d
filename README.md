# DotNetCore Tutorial for Unity3d for absolute noobs


## What is .NET Core
- Cross Platform C#
- Runs from a folder on OSX or Linux
- Stripped down high performance
- WebApi / MVC is an http framework build on Core

## Prerequesits 
- GET IT https://www.microsoft.com/net/core#windows
- READ IT https://docs.asp.net/en/latest/tutorials/first-web-api.html

## Good Links
- https://weblog.west-wind.com/posts/2016/Jun/06/Publishing-and-Running-ASPNET-Core-Applications-with-IIS
- https://medium.com/@pierrickblons/playing-around-with-entity-framework-7-and-asp-net5-ec5a5d8de549#.zcbn6qovx
- https://github.com/aspnet/EntityFramework/wiki
- https://github.com/statianzo/Fleck
- https://github.com/StackExchange/NetGain
	
## Goals
- Build a simple HTTP server
- SQL DB using EF
- High Score Controller
- Chat Websocket service
- Unity3d client

## 1) Init the thing
- Install the sdk
- Open VS (Or get another tutorial)
- File/New Project .NET Core/WebApplication
- Fucking uncheck Insights to the right
- Select WebAPI
- Fucking uncheck Host in the cloud
- I suggest No Authentication (Identity works great and has many OAUTH extensions, but I prefer to do that all myself).
- Close your eyes
- Open PackageManagerConsole
- Restore packages
  - nugget is a package / dependency repository. Like a free asset store.
  
> *PROTIP* Update-Package -reinstall will re-reference all dlls if shit breaks from moving shit

Run the app, you now have a web server running.

## 2) Configuration
- All apps in dotnetcore are glorified console apps. Program.cs is our entry point.
- In Main, we configure our web server. Check out my comments
- In Startup we configure the MVC/WebApi part of the app. Check out my comments.
- For the most part you can leave this alone even in advanced scenarios.

## 3) Entity Framework
Entity framework is an Database Object Relationship Manager. Simply put, it is a strongly typed api for manipulating persistent data. With EF you have a DataContext (the database object and unit of work), DBSets or lists of tables in the database, and entities or classess which have properties which map to the columns of your tables. Everything in EF is code first, so, you write a C# file, close your eyes and you have a database. There are many other features such as navigational properties (table joins) and providers for other database types such as postgre.

- 


