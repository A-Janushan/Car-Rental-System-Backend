# Car Rental Project

https://chatgpt.com/share/673d6c45-3d30-800f-b416-17d2dcc6a9d0

i want to create a car rental API in dot net core 8. 
To do so i need to have following Entities.

## Entities
- Car [ id, registration no , brand (fk),model(fk),engine capacity, engine number, chasy number,fuel type(electric,petrol,diesel,hybrid), year of manufacture ]
- Brand [id, brand Name]
- model [id, brand(fk),model name]

for the above requirements plz create a web api using dotnet core, SQLite , entity framework core using the following folder structure

[DTOs, controllers , service , repository ,helpers]

meantime the response of the system should be unique by obeying the pattern {success,payload:{},message:,errors:[]}

for DTOs validation need to be applied

### veryfy whether dotnet & entityframework tools got installed
```bash
dotnet --version
dotnet ef --version

dotnet tool install --global dotnet-ef
```

## How to create project 

```bash
dotnet new webapi -n CarRentalAPI -controllers

dotnet new gitignore
```