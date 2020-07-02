# OpenSource CMS - ASP .NET Core 3.1 

***

### [System Review](https://www.youtube.com/watch?v=ihhuuw4gdfM&t)

***
### Run locally - check list

1. Install MySQL with MySQL Workbench locally to manage project database
2. Create fork and clone repository
3. Create secrets.json in CMS folder from this snipped
```
{
  "ConnectionStrings": {
    "DefaultConnection": "server=[YOUR_SERVER_NAME];database=[YOUR_DB_NAME];user=[YOUR_USER_NAME];password=[YOUR_DB_PASSWORD]",
  },
  "CloudinarySettings": {
    "CloudName": "",
    "ApiKey": "",
    "ApiSecret": ""
  },
  "SlackSettings": {
    "Url": ""
  },
  "SendinblueSettings": {
    "ApiKey": ""
  }
}
```

***

### Deploy - check list

#### Instructions in progress