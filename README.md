# SequelMovieAPI
Implementation of REST API in .NET Core C#. Based on the following steps:
1. Installing and configuring Swagger 
2. Scaffolding dbcontext from the used database (MySql in this example) and configuring the needed connections (see Database.sequelmovieContext, appsettings.json, Startup.cs)
3. Installing AutoMapper and creating a class which inherits Profile (see Mapper->Mapper.cs)
4. Creating a Model class library with models that are equivalent to the ones in the database (no objects or collections, only include foreign keys)
5. Creating Requests for each model (Search requests are parameters used for filtering results on the API side, Upsert requests are equivalent to the models - if the primary key is autonumber exclude the primary key property)
6. Creating the IService and ICRUDService and implementing them in BaseService and BaseCRUDService with the adequate dbcontext
7. Creating a service class for each model which inherits the BaseCRUDService 
8. Creating maps for each model in Mapper.cs (Database.Model -> Model.Model and Database.Model -> UpsertRequest.ReverseMap, see Mapper.cs)
9. Overriding methods if needed
10. Creating BaseController and BaseCRUDController and inheriting the needed services (see Controllers)
11. Creating a controller for each model and inheriting the BaseCRUDController (see Controllers.ArtisteController)
12. Configuring the dependency injections using Scoped type (see Startup.cs)
