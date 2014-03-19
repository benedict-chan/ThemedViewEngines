#Themed Razor ViewEngines

Razor ViewEngines with Theme support for new or existing ASP.NET MVC 4 application.

## Features
- When a "theme" is configured, use the views under the corresponding `Themes` folder
- If the requested view does not exist, fallback to use the original ASP.NET MVC view route as a default
- Support __Areas__ (make sure to copy web.config, ViewStart.cshtml) 
- Support __Partial Views__


## Install using nuget
[ThemedViewEngines.MVC4](https://www.nuget.org/packages/ThemedViewEngines.MVC4)
	
    PM> Install-Package ThemedViewEngines.MVC4


## What the nuget installed
Once installed, the following is added to your ASP.NET MVC project:
- `~\App_Start\ThemedViewEnginesBootstrapper.cs` 
- A sample theme folder and files `~\Themes\Sample\Views\Shared\_Layout.cshtml`
- An appSettings `ThemeName` in web.config


## Logics to select theme
You can implement your own logics by implementing the interface `IThemeSelectorService`
```cs
    public interface IThemeSelectorService
    {
        string GetThemeName();
        void SetThemeName(string themeName);
    }
```


## CSS, Javascripts
You can solve these by using ASP.NET bundles.


## TODO
- Cache support
- WebForm ViewEngine


### Reference and ideas
[A Custom View Engine with Dynamic View Location](http://weblogs.asp.net/imranbaloch/archive/2011/06/27/view-engine-with-dynamic-view-location.aspx)
