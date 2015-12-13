# Multiple DbContext Demo

A sample project to show multiple EF DbContext working together.

## How To Run

* Open project in Visual Studio 2013+.
* Select MultipleDbContextDemo.Web as start project.

### Run Migrations

* Open Package Manager Console, select MultipleDbContextDemo.EntityFramework as default project.
* Run command to create first db: Update-Database -ConfigurationTypeName "MultipleDbContextDemo.Migrations.Configuration"
* Run command to create second db: Update-Database -ConfigurationTypeName "MultipleDbContextDemo.MigrationsSecond.Configuration"

### Run Application

* Run application with F5.
* You can see peole and course list.
* You can create a new person here.

### Notes

* MSDTC (Distributed Transaction Coordinator) should be running on your computer.
