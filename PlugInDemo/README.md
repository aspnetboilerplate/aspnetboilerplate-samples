# Plug-In Demo

This project shows simple usage of dynamically loding ABP modules.

## How To Run?

* Download the sample solution.
* Open in VS 2015.
* Restore nuget packages.
* Run "Update-Database" command for Entity Framework migrations.
* Run the application.

## How To Test?

* .Web project includes a PlugIns folder. You can put any ABP based module dll here to load it dynamically (without referencing from your projects).
* There is a sample plugin, named DatabaseMaintainer. It just includes a background worker to delete old audit logs (see DeleteOldAuditLogsWorker.cs)
* To test it, build the entire solution (DatabaseMaintainer.dll is automatically copied into PlugIns folder). Run the application. See logs (DeleteOldAuditLogsWorker is working...). Also, you can see that DatabaseMaintainerModule is loaded in the logs.

## How It Works?

In the Global.asax, we added this code:

````C#
AbpBootstrapper.IocManager.IocContainer.Register(
    Component.For<IAssemblyFinder>().UsingFactoryMethod(
        () => new MultiSourceAssemblyFinder(
            new WebAssemblyFinder(),
            new FolderAssemblyFinder(HttpContext.Current.Server.MapPath("~/PlugIns"))
            )
        )
    ); 
````

It ensures that ABP loads modules also from PlugIns folder.
