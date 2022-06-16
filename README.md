## ExcitelLead

### Installation:
1. Change the connestion strings for MS SQL and Redis in appsettings.json file in the API project
2. Publish the database project in the chosen MS SQL.

Build and start the API project

### Changing the persistance:

Change the unit of work interface injected into the Query or Command constructors in the application layer/project.

<ul>
    <li>GetLeadByIdQuery.cs -> change the IUnitOfWorkEF to IUnitOfWorkRedis</li>
    <li>CreateLeadCommand.cs -> change the IUnitOfWorkEF interface to IUnitOfWorkRedis</li>
    <li>DeleteLeadCommand.cs -> change the IUnitOfWorkEF interface to IUnitOfWorkRedis</li>
    <li>UpdateLeadCommand.cs -> change the IUnitOfWorkEF interface to IUnitOfWorkRedis</li>
</ul>
