# Installation and Environment Setup

## Dependencies

WIP

## Migrations / Table schema

We have users and tasks table

Note. Task is reserved for System.Threading.Tasks

- users(id, username, email, password,)
- taskitems(id, user_id, title, description, due_date) 

To manage schema we use the following command

```sh

 dotnet ef migrations add Initial #use to create a clean new migration for DBCOntext
# or

 dotnet ef database update --context <ModelNameContext> # to update the database with the new migration
```

## Documentation 

Using Swagger for API documentation [@ 🔗](https://localhost:7128/swagger/index.html)
