Project I made for school, just for fun.
Small business application to keep track of employers and clients.
The application in it self is specific to be used for a car-mechanic business,
but the main intention was to make it flexible, so with a few changes it is easy to make it work for any type of enterprise.


Functionalities:

  -add-edit-remove-assign employees clients, manage workflow
  -multi-level login & access
  -blog style communication extension
  -automated invoice
  -product / service management(includes pricing)
  
The app can be run after creating the two database files:
⦁	Update-Database –ConfigurationTypeName SzereloCegApp.CegContextMigrations.Configuration

⦁	Update-Database -ConfigurationTypeName SzereloCegApp.RolesContextMigrations.Configuration

If you encounter error with simplemembership provider, you might need to update webhelpers:
⦁ Update-Package –reinstall Microsoft.AspNet.WebHelpers
