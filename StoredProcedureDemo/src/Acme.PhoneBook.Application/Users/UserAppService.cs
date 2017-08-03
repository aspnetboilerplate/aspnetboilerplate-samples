using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Acme.PhoneBook.Authorization;
using Acme.PhoneBook.Authorization.Users;
using Acme.PhoneBook.Users.Dto;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using Abp.Authorization;
using Abp.Domain.Uow;
using Microsoft.EntityFrameworkCore;
using Abp.IdentityFramework;
using Acme.PhoneBook.Authorization.Roles;
using Acme.PhoneBook.Authorization.Users.Dtos;
using Acme.PhoneBook.EntityFrameworkCore.Repositories;
using Acme.PhoneBook.Roles.Dto;

namespace Acme.PhoneBook.Users
{
    [AbpAuthorize(PermissionNames.Pages_Users)]
    public class UserAppService : AsyncCrudAppService<User, UserDto, long, PagedResultRequestDto, CreateUserDto, UserDto>, IUserAppService
    {
        private readonly UserManager _userManager;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IRepository<Role> _roleRepository;
        private readonly IUserRepository _userRepository;

        public UserAppService(IUserRepository userRepository, IRepository<User, long> repository, UserManager userManager, IPasswordHasher<User> passwordHasher, IRepository<Role> roleRepository)
            : base(repository)
        {
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _roleRepository = roleRepository;
            _userRepository = userRepository;
        }
        
        public override async Task<UserDto> Create(CreateUserDto input)
        {
            CheckCreatePermission();

            var user = ObjectMapper.Map<User>(input);

            user.TenantId = AbpSession.TenantId;
            user.Password = _passwordHasher.HashPassword(user, input.Password);
            user.IsEmailConfirmed = true;

            CheckErrors(await _userManager.CreateAsync(user));

            if (input.Roles != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.Roles));
            }

            CurrentUnitOfWork.SaveChanges();

            return MapToEntityDto(user);
        }

        public override async Task<UserDto> Update(UserDto input)
        {
            CheckUpdatePermission();

            var user = await _userManager.GetUserByIdAsync(input.Id);

            MapToEntity(input, user);

            CheckErrors(await _userManager.UpdateAsync(user));

            if (input.Roles != null)
            {
                CheckErrors(await _userManager.SetRoles(user, input.Roles));
            }

            return await Get(input);
        }

        public override async Task Delete(EntityDto<long> input)
        {
            var user = await _userManager.GetUserByIdAsync(input.Id);
            await _userManager.DeleteAsync(user);
		}

        public async Task<ListResultDto<RoleDto>> GetRoles()
        {
            var roles = await _roleRepository.GetAllListAsync();
            return new ListResultDto<RoleDto>(ObjectMapper.Map<List<RoleDto>>(roles));
        }
        
        public async Task<List<string>> GetUsers()
        {
            return await _userRepository.GetUserNames();
        }
        
        public async Task<List<string>> GetAdminUsernames()
        {
            return await _userRepository.GetAdminUsernames();
        }
        
        public async Task DeleteUser(EntityDto input)
        {
            await _userRepository.DeleteUser(input);
        }
        
        public async Task UpdateEmail(UpdateEmailDto input)
        {
            await _userRepository.UpdateEmail(input);
        }
        
        public async Task<GetUserByIdOutput> GetUserById(EntityDto input)
        {
            return await _userRepository.GetUserById(input);
        }

        protected override User MapToEntity(CreateUserDto createInput)
        {
            var user = ObjectMapper.Map<User>(createInput);
            user.SetNormalizedNames();
            return user;
        }

        protected override void MapToEntity(UserDto input, User user)
        {
            ObjectMapper.Map(input, user);
            user.SetNormalizedNames();
        }
        
        protected override IQueryable<User> CreateFilteredQuery(PagedResultRequestDto input)
        {
            return Repository.GetAllIncluding(x => x.Roles);
        }

        protected override async Task<User> GetEntityByIdAsync(long id)
        {
            return await Repository.GetAllIncluding(x => x.Roles).FirstOrDefaultAsync(x => x.Id == id);
        }
        
        protected override IQueryable<User> ApplySorting(IQueryable<User> query, PagedResultRequestDto input)
        {
            return query.OrderBy(r => r.UserName);
        }

        protected virtual void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}