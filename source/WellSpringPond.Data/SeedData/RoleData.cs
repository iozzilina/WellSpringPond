namespace WellSpringPond.Data.SeedData
{
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using WellSpringPond.Models.EntityModels;


    internal class RoleData
    {
        internal static void SeedRoles(WellSpringPond.Data.WellSpringPondContext context)
        {
            var rStore = new RoleStore<IdentityRole>(context);
            var rManager = new RoleManager<IdentityRole>(rStore);

            if (!context.Roles.Any(role => role.Name == RoleNames.ROLE_SUPERADMINISTRATOR))
            {
                var role = new IdentityRole(RoleNames.ROLE_SUPERADMINISTRATOR);
                rManager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == RoleNames.ROLE_ADMINISTRATOR))
            {
                var role = new IdentityRole(RoleNames.ROLE_ADMINISTRATOR);
                rManager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == RoleNames.ROLE_MODERATOR))
            {
                var role = new IdentityRole(RoleNames.ROLE_MODERATOR);
                rManager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == RoleNames.ROLE_TRAVELER))
            {
                var role = new IdentityRole(RoleNames.ROLE_TRAVELER);
                rManager.Create(role);
            }
        }
    }
}
