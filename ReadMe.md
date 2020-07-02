# OpenSource CMS - ASP .NET Core 3.1 

***

### [System Review](https://www.youtube.com/watch?v=ihhuuw4gdfM&t) (PL)

***
### Run locally - check list

1. Install MySQL with MySQL Workbench locally to manage project database
2. Create fork and clone repository
3. Create secrets.json in CMS folder fromsnipped
4. Create account on [Cloudinary](https://cloudinary.com/) and get CloudName, ApiKey and ApiSecret from dashboard.
5. Create account on [Sendinblue](https://www.sendinblue.com/) and get ApiKey from api settings.
6. Create your own [Slack Channel](https://api.slack.com/) and get Slack WebHook Url. 
7. Create your locally database in MySQL Workbench and paste your connection string to **secrets.json**.
8. Hit **F5** and enjoy OpenCMS :)

**secrets.json snippet**

```
{
  "ConnectionStrings": {
    "DefaultConnection": "server=[YOUR_SERVER_NAME];database=[YOUR_DB_NAME];user=[YOUR_USER_NAME];password=[YOUR_DB_PASSWORD]",
  },
  "CloudinarySettings": {
    "CloudName": "...",
    "ApiKey": "...",
    "ApiSecret": "..."
  },
  "SlackSettings": {
    "Url": "..."
  },
  "SendinblueSettings": {
    "ApiKey": "..."
  }
}
```

**INFO**: CloudinarySettings, SlackSettings, SendinblueSettings are optionals but recommended to fully functionality. If you do not want to use the functionality, remove the sections from secrets.json

**Video instruction**: [Youtube instructions](https://www.youtube.com/watch?v=RK5WvsT_4Pk) (PL)

***

### Deploy - check list

#### Instructions in progress
