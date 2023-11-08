## DataBalk - Task Management API

This is a simple task management API, it allows you to create, update, delete and list tasks.

<img width="945" alt="Screenshot 2023-11-08 at 12 43 53" src="https://github.com/brunoalfred/DataBalkInterview/assets/55545250/b20310df-f40f-47f9-a1e9-dc1f7408fa2e">
<img width="889" alt="Screenshot 2023-11-08 at 12 44 29" src="https://github.com/brunoalfred/DataBalkInterview/assets/55545250/b751466e-5ae3-4e6e-998b-8e2c036df54b">

### Dependencies

Used NuGet packages

### Migrations / Table schema

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

### Authentication

Provide XApiKey in the header to authenticate the user

```sh
X-Api-Key: <API_KEY>
```

### Documentation 

Using Swagger for API  [documentation @ 🔗](https://localhost:7128/swagger/index.html)

### Tests

I used MSTest for unit testing, to run the tests use the following command

```sh
dotnet test
```
