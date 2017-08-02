using System.Reflection;
using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Authorization.Roles;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Acme.PhoneBook.Authorization;
using Acme.PhoneBook.Authorization.Roles;
using Acme.PhoneBook.Authorization.Users;
using Acme.PhoneBook.MultiTenancy;
using Acme.PhoneBook.Roles.Dto;
using Acme.PhoneBook.Users.Dto;
using AutoMapper;

namespace Acme.PhoneBook
{
    [DependsOn(
        typeof(PhoneBookCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class PhoneBookApplicationModule : AbpModule
    {

        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<PhoneBookAuthorizationProvider>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PhoneBookApplicationModule).GetAssembly());

            // TODO: Is there somewhere else to store these, with the dto classes
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                // Role and permission
                cfg.CreateMap<Permission, string>().ConvertUsing(r => r.Name);
                cfg.CreateMap<RolePermissionSetting, string>().ConvertUsing(r => r.Name);    

                cfg.CreateMap<CreateRoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());
                cfg.CreateMap<RoleDto, Role>().ForMember(x => x.Permissions, opt => opt.Ignore());

                IRepository<Role, int> repository = IocManager.Resolve<IRepository<Role, int>>();
                // User and role
                cfg.CreateMap<UserRole, string>().ConvertUsing(  (r) =>  {
                    //TODO: Fix, this seems hacky
                    Role role = repository.FirstOrDefault(r.RoleId);
                    return role.DisplayName;
                });

                IocManager.Release(repository);
                
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<UserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

                cfg.CreateMap<CreateUserDto, User>();
                cfg.CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());
            });
        }
    }
}