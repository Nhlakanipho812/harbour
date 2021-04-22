# harbour
The application is built with 6 layers
built using code first approach
using .NET 5 Core webapi

1. API -- The main application
2. harbour.integration -- couples all the integrations of the weather API
3. harbour.model__views -- contains all user representation models i.e view models
4. harboour.models -- contains all the database interfacing classes i.e. your representational database model.
5. harbour.services -- contains all the business logic
6. and finally harbour.helpers -- contains the data context

Project Properties
This project was built using .Net Core 5.0.100. It uses swagger v5 for documentation. It also requires that you have SQL server running in your machine, however it should still work as long as Visual Studio (localDb) Dependancies have been installed. Please ensure you also have .Net Core 5 SDK and runtime installed as well as .Net Core CLI if will be using the command line, otherwise you can use Package Manager Console on Visual Studio. The database is a code first approach and uses migrations to manage the database schemas.

here are a few links to get you started: Download .Net Core 5 Documentation donet cli

How to run
It is relatively simple to get stared.

Make sure you are in the root directory of the app.
First, If you choose to build the project, It will install and restore all the nuget packages.
In case you skipped and/or are not successful in the above step, or to ensure its done run command dotnet restore if running on VS, go to project solution explorer right click and choose restore nuget. if your project gets errors after building and installing these packages, run command dotnet nuget locals all --clear this will help clear the error in .Net Core 5
Afterwards, run command dotnet ef database update if there are no migrations you can start by adding one dotenet ef migrations add <Migration Name> on Visual Studio under PM you can run update-database or if there are no migrations run add-migration <Migration name> please refer to the documentation Managing Schemas
Make sure everything is builds successfully. Errors may arise because of your connection string. Otherwise on AppSettings.json You can modify the connection string to match your computer.
If the above is successful, run command dotnet run to run the application. if using visual studio, you can press F5 or simply the green run button.
If having problems, do not hesitate, contact me on musa.buthelezi@outlook.com
 
