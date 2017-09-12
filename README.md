# TopshelfNancyEFDemo

Create a service utilizing topshelf and a selfhosted NancyFX Api and an EF Code first database for Users 
and log API requests to a file utilizing nuget package “Microsoft.Extensions.Logging”
 
                General
·        Code should use async wherever possible
Logging
·        Use Microsoft.Extensions.Logging with Serilog as backing to the abstraction
·        Serilog Rolling File + Serilog Console
·        Configure in application bootstrapper
                DB
·        Be code first
·        Separate assembly from rest of project
·        Context should have 1 table for users
o   Id
o   First
o   Last
o   Email
·        Have migrations enabled
·        Automatic migrations disabled
·        Be seeded via configuration with at least 10 user records – dealer’s choice but hardcoded in EF configuration
                Nancy should auto register its URL to the system
                Endpoints
·        /user
o   /add
§  Adds a user to the db
o   /delete/{id}
§  Deletes a user from db
o   /{id}
§  Single user
o   /list, /
§  Lists all users in db
·        /time
o   /
§  Return json object with the following fields derived from DateTime.Now
·        UTC milliseconds
·        ISO 8601 full date format (e.g. 20170809T221816Z )
·        /system
o   /
§  Return JSON object with the following fields
·        Machine Name
·        Processor Count
·        OS Version
