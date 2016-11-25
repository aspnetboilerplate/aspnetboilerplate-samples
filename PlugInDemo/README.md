# Plug-In Demo

This project shows simple usage of dynamically loding ABP modules.

## How To Run?

* Download the sample solution.
* Open in VS 2015.
* Restore nuget packages.
* Run "Update-Database" command for Entity Framework migrations.
* Rebuild the solution.
* Run the application.
* If you see "DeleteOldAuditLogsWorker is working..." in logs in every 5 seconds, then it's properly working.

## How To Test?

* To test it, rebuild the entire solution (DatabaseMaintainer.dll is automatically copied into PlugIns folder). Run the application. See logs (DeleteOldAuditLogsWorker is working...). Also, you can see that DatabaseMaintainerModule is loaded in the logs.

## How It Works?

* .Web project includes a PlugIns folder. You can put any ABP based module dll here to load it dynamically (without referencing from your projects).
* There is a sample plugin, named DatabaseMaintainer. It just includes a background worker to delete old audit logs (see DeleteOldAuditLogsWorker.cs)
* When you rebuild the solution, DatabaseMaintainer.dll is copied to the PlugIns folder automatically (configured in project's build options).
* We just added the following line to global.asax to add the plugin folder.

````C#
AbpBootstrapper.PlugInSources.AddFolder(Server.MapPath("/PlugIns"));
````

It ensures that ABP loads plugin modules from the PlugIns folder.
