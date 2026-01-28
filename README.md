# ASP.NET-MVC-5-Demos

## Introduction
Demo web apps in ASP.NET MVC 5 (.NET Framework 4.8)

## `Startup.cs` file is missing

This is completely normal in the world of ASP.NET MVC 5 on .NET Framework 4.8.

This type of application does **NOT** use `Startup.cs` by default.

In ASP.NET MVC 5 (.NET Framework), the application pipeline is initialized by `Global.asax` and `Web.config`.

`Startup.cs` is not required, because MVC 5 was created before **OWIN** became a standard.

Configuration was done in a “classic” way, not centrally in `Startup.cs`.

## Where is the startup of an MVC 5 application?

`Global.asax.cs` is the entry point of the application.
This is the equivalent of `Program.cs` / `Startup.cs` in ASP.NET Core.

```cs
public class MvcApplication : HttpApplication
{
    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }
}
```

`Web.config` file contains pipeline configuration.

MVC 5 relies on IIS + `Web.config`, not on Kestrel hosting.

Here you configure:

- authentication
- errors
- modules / handlers
- connection strings
- compilation / debug settings


## What about **OWIN** and `Startup.cs` ?
`Startup.cs` appears only if you use **OWIN** 👉 for example:
  - ASP.NET Identity
  - OAuth / OpenID
  - cookie authentication via OWIN
  - classic SignalR
 
In that case, **you add it yourself**:
```cs
[assembly: OwinStartup(typeof(MyApp.Startup))]
namespace MyApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // middleware
        }
    }
}
```

## Comaparison: MVC 5 vs ASP.NET Core

*[paste screenshot here]*
