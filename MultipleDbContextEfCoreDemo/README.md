# Multiple DbContext Demo

A sample project to show multiple Entity Framework Core DbContexts working together.

## How To Run

* Open project in Visual Studio 2017+.
* Select MultipleDbContextEfCoreDemo.Web as start project.

### Run Migrations

* Open Package Manager Console, select MultipleDbContextEfCoreDemo.EntityFrameworkCore as default project.
* Run command to create first db migration file: **add-migration Added_Person_Entity -Context MultipleDbContextEfCoreDemoDbContext**
* Run command to create second db migration file: **add-migration Added_Course_Entity -Contex MultipleDbContextEfCoreDemoSecondDbContext**
* Run the ***.Migrator project** to apply the changes to the database.

### Run Application

* Run application with F5.
* You can see peole and course list.
* You can create a new person here.
