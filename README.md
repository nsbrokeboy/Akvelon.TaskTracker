Akvelon.TaskTracker
===================
###### Test task for a candidate on .NET intern position
###### Three-level project architecture (data access level, logic level, representation)
-------------------------------------------------
#### Web-API for Task Tracker application

The application allows you to keep track of projects containing various tasks.
Projects have name, start and finish dates, status (NotStarted / Active / Completed) and priority.
Tasks have a name, description, status (ToDo / InProgress / Done) and priority.
You can create, view, edit and delete projects and tasks. You can also sort and filter projects by various values.

-------------------------------------------------
#### Stack
* Core: ASP .NET Core 5
* ORM: Entity Framework
* Database: PostgreSQL
-------------------------------------------------
#### Instructions
1. Firstly, you must change connection string in _appsettings.json_ file stored in _Akvelon.TaskTracker.PL_ project.

Example:
```
"ConnectionStrings": {
    "ConnectionString": "yourConnectionString"
  }
```
2. Secondly, run with _dotnet-cli_ in project directory:
```
dotnet ef database update -s ../Akvelon.TaskTracker.PL/ -p ../Akvelon.TaskTracker.DAL/
```
3. Run _Akvelon.TaskTracker.PL_ project.
