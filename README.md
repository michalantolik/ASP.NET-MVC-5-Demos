# ASP.NET-MVC-5-Demos

## Introduction
Demo web apps in ASP.NET MVC 5 (.NET Framework 4.8)

## "Startup.cs" file is missing

This is completely normal in the world of ASP.NET MVC 5 on .NET Framework 4.8.

This type of application does **NOT** use `Startup.cs` by default.

In ASP.NET MVC 5 (.NET Framework), the application pipeline is initialized by `Global.asax` and `Web.config`.

`Startup.cs` is not required, because MVC 5 was created before `OWIN` became a standard.

Configuration was done in a “classic” way, not centrally in `Startup.cs`.
