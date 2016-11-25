using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Abp.Auditing;
using Abp.Authorization.Users;
using Abp.MultiTenancy;
using PlugInDemo.Users;

namespace PlugInDemo.Web.Models.Account
{
    public class RegisterViewModel : IValidatableObject
    {
        /// <summary>
        /// Not required for single-tenant applications.
        /// </summary>
        [StringLength(AbpTenantBase.MaxTenancyNameLength)]
        public string TenancyName { get; set; }

        [Required]
        [StringLength(User.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(User.MaxSurnameLength)]
        public string Surname { get; set; }

        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [StringLength(User.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string Password { get; set; }

        public bool IsExternalLogin { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var emailRegex = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            if (!UserName.Equals(EmailAddress) && emailRegex.IsMatch(UserName))
            {
                yield return new ValidationResult("Username cannot be an email address unless it's same with your email address !");
            }
        }
    }
}