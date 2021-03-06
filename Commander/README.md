# .NET Core 3.1 MVC REST API - Commander
<img src="https://img.shields.io/badge/c%23%20-%23239120.svg?&style=for-the-badge&logo=c-sharp&logoColor=white"/><img src="https://img.shields.io/badge/docker%20-%230db7ed.svg?&style=for-the-badge&logo=docker&logoColor=white"/>

## What does it do?

Manages (create, update and delete) a list of command lines descriptions.

Example:

| Id | HowTo             | Line                                     | Platform              |
|----|-------------------|------------------------------------------|-----------------------|
| 1  | Create migrations | dotnet ef migrations add <MigrationName> | Entity Framework Core |

## What do I need to create this project?

- Visual Studio Code or Visual Studio
- .NET Core
- Docker
- SQL Server and Microsoft SQL Server Management Studio (optional)
- Postman or another API Client software (optional)

## End Points Descriptions

|        **URI**         |  **Verb**	| **Operation**	|    **Description**	         |       **Success**	        |      **Failure**                      |
|:------------------:|:------:|:---------:|:------------------------:|:----------------------:|:---------------------------------:|
|/api/commands/	     |   **GET**	|   **READ**	  | Read all resources	     |        200 OK	        | 400 Bad Request / 404 Not Found   |
|/api/commands/{id}  |   **GET**	|   **READ**    | Read a single resource   |	      200 OK          |	400 Bad Request / 404 Not Found   |
|/api/commands/      |  **POST**	|  **CREATE**	  | Create a new resource	   |     201 Created        |	400 Bad Request / 405 Not Allowed |
|/api/commands/{id}  |  **PUT**	  | **UPDATE**	  | Update an entire resource|	 204 No Content       |	             -                    |
|/api/commands/{id}  | **PATCH**  |	**UPDATE**    |	Update partial resource	 |   204 No Content       |	             -                    |
|/api/commands/{id}  | **DELETE** |	**DELETE**    | Delete a single resource |200 OK / 204 No Content	|              -                    |
|api/commands/       | **DELETE** | **DELETE**    | Delete all resources     |200 OK / 204 No Content	|              -                    |

## Project Design Description

![](https://github.com/BernardoSlailati/dotnetcore/blob/master/Commander/assets/project_description.svg)

## References

- [Base Project](https://www.youtube.com/watch?v=fmvcAzHpsk8&list=PLMOI5f5peuFEqUWhNii6jl8XkH2ufMM5h&index=1&ab_channel=LesJackson)
- [GitHub Official Repository](https://github.com/binarythistle)
