using CMS.Areas.Admin.Models.Db.Account;
using CMS.Areas.Admin.Models.View.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMS.Infrastructure.Helpers
{
    public static class AccountHelpers
    {
        public static User ConvertToModel(UserView result)
        {
            var userModel = new User
            {
               Id = result.Id,
               Name = result.Name,
               Surname = result.Surname,
               UserName = result.UserName,
               Email = result.Email
            };

            return userModel;
        }

        public static UserView ConvertToView(User result)
        {
            var userView = new UserView
            {
                Id = result.Id,
                Name = result.Name,
                Surname = result.Surname,
                UserName = result.UserName,
                Email = result.Email
            };
            return userView;
        }

        public static User MergeViewWithModel(User model, UserView view)
        {
            model.UserName = view.UserName;
            model.Email = view.Email;
            model.Name = view.Name;
            model.Surname = view.Surname;

            return model;
        }
    }
}
