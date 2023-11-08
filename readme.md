## DataBalk - Task Management API


## Dependencies

Used NuGet packages

## Migrations / Table schema

We have users and tasks table

Note. Task is reserved for System.Threading.Tasks

- users(id, username, email, password, ApiKey)
- taskitems(id, user_id, title, description, due_date) 

To manage schema we use the following command

```sh

 dotnet ef migrations add Initial #use to create a clean new migration for DBCOntext
# or

 dotnet ef database update --context <ModelNameContext> # to update the database with the new migration
```

## Authentication

Provide XApiKey in the header to authenticate the user

```sh
X-Api-Key: <API_KEY>
```

## Documentation 

Using Swagger for API  [documentation @ 🔗](https://localhost:7128/swagger/index.html)

## Tests

I used MSTest for unit testing, to run the tests use the following command

```sh
dotnet test
```