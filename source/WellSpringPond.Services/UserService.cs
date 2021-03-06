﻿
namespace WellSpringPond.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WellSpringPond.Models.EntityModels;
    using WellSpringPond.Models.ViewModels.Users;

    public class UserService : Service{
        
        public IEnumerable<AdminUserBasicDataVm> GetAllUserForAdminList()
        {
            IEnumerable<ApplicationUser> users = this.Context.Users;

            List<AdminUserBasicDataVm> vms = new List<AdminUserBasicDataVm>();

            foreach (var applicationUser in users)
            {
                vms.Add(new AdminUserBasicDataVm()
                {
                    Username = applicationUser.UserName,
                    Role = "not sure how to fetch this yet" // Role manager.... i forgot.
                });
            }

            return vms;
        }

        public ApplicationUser GetUserByUserName(string name)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == name);
            return user;
        }

       
    }
}
