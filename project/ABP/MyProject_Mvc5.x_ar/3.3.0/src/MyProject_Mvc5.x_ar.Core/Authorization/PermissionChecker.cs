using Abp.Authorization;
using MyProject_Mvc5.x_ar.Authorization.Roles;
using MyProject_Mvc5.x_ar.Authorization.Users;

namespace MyProject_Mvc5.x_ar.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
