﻿using CMS.Areas.Admin.Models.Db.Account;
using CMS.Areas.Admin.Models.Db.Seo;
using CMS.Areas.Admin.Models.Db.Settings;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Context
{
    public class Seed
    {

        public static async Task SeedData(CMSContext context, UserManager<User> userManager)
        {
            // Seed dla podstawowych kont użytkowników
            if (!userManager.Users.Any())
            {
                var users = new List<User>
                {
                    new User
                    {
                        UserName = "admin",
                        Email = "admin@admin.pl",
                        Name = "admin",
                        Surname = "adminowski"
                    },
                    new User
                    {
                        UserName = "user",
                        Email = "user@user.pl",
                        Name = "user",
                        Surname = "userowski"
                    }
                };

                foreach (var user in users)
                {
                    await userManager.CreateAsync(user, "haslo");
                }
            }

            // Seed dla ustawień systemu
            if (!context.BlogSettings.Any())
            {
                var blogSettings = new BlogModel
                {
                    CommentsNotify = false,
                    PostPerPage = 12,
                    AllowComments = false,
                    DateFormat = "dd-MM-yyyy",
                    TimeFormat = "H:mm:ss"
                };

                await context.BlogSettings.AddAsync(blogSettings);
                await context.SaveChangesAsync();
            }

            // seed dla ustawień e-maila
            if (!context.EmailSettings.Any())
            {
                var emailsettings = new EmailModel
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EmailTo = "odbiorca@gmail.com",
                    EmailFrom = "nadawca@gmail.com",
                    Password = "password",
                    EnableSSL = true,
                };

                await context.EmailSettings.AddAsync(emailsettings);
                await context.SaveChangesAsync();
            }

            // Seed dla polityki prywatności
            if (!context.PrivacyPolicySettings.Any())
            {
                var privacySettings = new PrivacyPolicyModel
                {
                    PageUrl = "https://test.pl",
                    CompanyName = "Nazwa firmy",
                    Street = "ul. ulicowska 45",
                    City = "miasto",
                    ZipCode = "12-345",
                    Email = "polityka@prywatnosci.pl",
                    HostingName = "hosting.pl"
                };

                await context.PrivacyPolicySettings.AddAsync(privacySettings);
                await context.SaveChangesAsync();
            }

            // Seed dla polityki prywatności
            if (!context.IntegrationSettings.Any())
            {
                var integrationSettings = new IntegrationModel { };

                await context.IntegrationSettings.AddAsync(integrationSettings);
                await context.SaveChangesAsync();
            }

            // Seed dla ogólnych ustawień seo
            if (!context.SeoSettings.Any())
            {
                var generalSettings = new GeneralSeoSettingsModel
                {
                    MainUrl = "https://cmsopen.net",
                    Title = "Twoja pierwsza strona w systemie CMSOPEN"
                };

                await context.SeoSettings.AddAsync(generalSettings);
                await context.SaveChangesAsync();
            }
        }
    }
}

