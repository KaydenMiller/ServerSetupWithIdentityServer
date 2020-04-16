# How to get this template setup
There are several things that need to be done to configure this template.

## Recommended Changes
* Change the ports for the applications to be different from the standard ports to avoid
  conflicts with other applications.
* The project is currently setup using the default Dependency Injection service for ASP.NET projects
  I would recommend replacing this with a service such as `AutoFac`
  
## For Development
Search the project for any `TODO:` comments an they should point you to changes that need to be made.
* Configure the Auth server for an api's and client's you might need
* Add any users into ASP.NET Identity as you need for server configuration
* Build your migrations as needed for ASP.NET Identity

## For Production
* Change the developer signing credential to be a production one
* Configure SSL
* Configure Kestrel or your chosen proxy service