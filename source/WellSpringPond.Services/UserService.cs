
namespace WellSpringPond.Services
{
    using System.Collections.Generic;
    using WellSpringPond.Models.EntityModels;
    using WellSpringPond.Models.ViewModels.Users;

    public class UserService : Service
    {
        
        public IEnumerable<AdminUserBasicDataVm> GetAllUserForAdminList()
        {
            IEnumerable<ApplicationUser> users = this.Context.Users;

            List<AdminUserBasicDataVm> vms = new List<AdminUserBasicDataVm>();

            foreach (var applicationUser in users)
            {
                vms.Add(new AdminUserBasicDataVm()
                {
                    Username = applicationUser.UserName,
                    Role = "not sure how to fetch this yet"
                });
            }

            return vms;
        }
    }
}
