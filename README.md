# expenda
Expense tracker built with .NET and React

A personal playground project that is using the onion architecture. If intended to run locally, install the latest version of postgresql, .NET 8, and the latest LTS version of NodeJS. Docker support will soon be added.

1. Restore the projects in Expenda.sln
2. Install the global efcore tools & run the database migrations from the Expenda.API project (In case your postgresql password is different, please change in appsettings.development.json)
3. Restore the packages in Expenda.Web using the 'yarn' command
4. Run the Expenda.API project.
5. Run the Expenda.Web project using the 'yarn dev' command.
6. At the time of writing, registration via the web app is not yet functional, so please use swagger to register a user (example username: 'string', example password: 'Password1!').
7. Then login using the newly created user's credentials.
