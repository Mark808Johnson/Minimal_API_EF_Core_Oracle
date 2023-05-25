# Minimal_API_EF_Core_Oracle
Simple minimal API integrating EF Core and Oracle DB (11g)

<b>SDK:</b> .Net 7.0 

<b>Database Server:</b> Oracle 11.2.0.2.0 (11g) 

<b>IDE:</b> Visual Studio 2022

<b>How to run project:</b>
1. Clone this project to your local device.

2. Run **dotnet build** 

3. Amend TodoItemContext connection string in appsettings.json file to match your own Oracle 11g DB.

4. Ensure that you have 

4. Navigate to project and run **dotnet ef database update**.
   This creates the database in your server.

5. Run the project. The API will automatically open in Swagger within your browser. All routes are displayed thus: 

<b>API functionality</b> 
- GET /todoitems (Gets all items)
- GET /todoitems/{id} (Gets item by id)
- GET /todoitems/done (Gets all items where done = true)
- POST /todoitems (Creates new item)
- PUT /todoitems/{id} (Updates item by Id)
- DELETE /todoitems/{id} (Deletes item by Id}

<b>Class properties</b> 

<ins>TodoItem</ins>:
- Id (int) 
- Description (string)
- CreationTs (DateTimeOffset)
- Done (bool)
