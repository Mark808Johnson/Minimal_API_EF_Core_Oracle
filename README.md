# Minimal_API_EF_Core_Oracle
Simple CRUD minimal API integrating EF Core with Oracle 11g and minimal API functionality (including simple model validation).

Builds on the Oracle quickstart guide for .NET Core, as found here:

https://www.oracle.com/tools/technologies/quickstart-dotnet-for-oracle-database.html#third-option-tab

Initial model created using Database-First approach, before transferring to a Code-First approach via EF Core Migrations. 
   
<b>SDK:</b> .Net 7.0 

<b>Database Server:</b> Oracle 11.2.0.2.0 (11g) 

<b>IDE:</b> Visual Studio 2022

<b>How to run project:</b>
1. Clone this project to your local device.

2. Run **dotnet build** 

3. Amend TodoItemContext connection string in appsettings.json file to match your own Oracle 11g DB.
   Ensure that you have a user/schema by the name "DEMODOTNET" in your DB (as per the quickstart guide). 

    "ConnectionStrings": {
    "TodoItemContext": "User Id=      ;Password=       ;Data Source=    "
  }

5. Run **dotnet ef database update**.
   This creates the database in your server via code-first migrations.

6. Run the project. The API will automatically open in Swagger within your browser. All routes are displayed thus: 

<b>API functionality</b> 
- GET /todoitems (Gets all items)
- GET /todoitems/{id} (Gets item by id)
- GET /todoitems/done (Gets all items where done = true)
- POST /todoitems (Creates new item)
- PUT /todoitems/{id} (Updates item by Id)
- DELETE /todoitems/{id} (Deletes item by Id}

<b>Entity class</b> 

<ins>TodoItem</ins>:
- Id (int) 
- Description (string)
- CreationTs (DateTimeOffset)
- Done (bool)
