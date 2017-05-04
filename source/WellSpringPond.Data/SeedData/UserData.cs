namespace WellSpringPond.Data.SeedData
{
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WellSpringPond.Models.EntityModels;

    public class UserData
    {
        internal static void SeedUsers(WellSpringPond.Data.WellSpringPondContext context)
        {
            Dictionary<string, string> userSeedData = new Dictionary<string, string>();

            userSeedData.Add("User01@me.com", "Aa!123");
            userSeedData.Add("User02@me.com", "Aa!123");
            userSeedData.Add("User03@me.com", "Aa!123");
            userSeedData.Add("User04@me.com", "Aa!123");
            userSeedData.Add("User05@me.com", "Aa!123");
            userSeedData.Add("User06@me.com", "Aa!123");
            userSeedData.Add("User07@me.com", "Aa!123");
            userSeedData.Add("User08@me.com", "Aa!123");
            userSeedData.Add("User09@me.com", "Aa!123");
            userSeedData.Add("User10@me.com", "Aa!123");

            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string userName;
            string password;

            foreach (var kvp in userSeedData)
            {
                userName = kvp.Key;
                password = kvp.Value;
                string roleToAssign = RoleNames.ROLE_TRAVELER;

                CreateUserwRole(userManager, userName, password, roleToAssign);
            }

            CreateUserwRole(userManager, "IAmTheAdmin@me.com", "Aa!123", RoleNames.ROLE_ADMINISTRATOR);
            CreateUserwRole(userManager, "SuperAdminAmI@me.com", "Aa!123", RoleNames.ROLE_SUPERADMINISTRATOR);
            CreateUserwRole(userManager, "ModeratorAmI@me.com", "Aa!123", RoleNames.ROLE_MODERATOR);

        }

        private static void CreateUserwRole(UserManager<ApplicationUser> userManager, string userName, string password, string roleToAssign)
        {
            ApplicationUser user = userManager.FindByName(userName);
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    UserName = userName,
                    Email = userName,
                    EmailConfirmed = true
                };

                IdentityResult userResult = userManager.Create(user, password);
                if (userResult.Succeeded)
                {
                    var result = userManager.AddToRole(user.Id, roleToAssign);
                }
            }
        }
    }
}


