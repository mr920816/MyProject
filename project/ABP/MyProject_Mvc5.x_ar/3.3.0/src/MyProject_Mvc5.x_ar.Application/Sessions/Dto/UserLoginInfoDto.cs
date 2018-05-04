using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using MyProject_Mvc5.x_ar.Authorization.Users;
using MyProject_Mvc5.x_ar.Users;

namespace MyProject_Mvc5.x_ar.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
    }
}
