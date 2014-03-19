You have successfully added Theme support in your ASP.NET MVC application.


A sample Theme named "Sample" with a _layout.cshtml is created as a demo.

An appsettings is also added to your web.config file:
simple change it to 
- <add key="ThemedViewName" value="Sample" />

Then you can test this "Sample" Theme


Please note: all view's that doesn't exist under "Theme" folder will use the default view.

