using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;

namespace CallApiFromConsole
{
    public class GetRolesInput
    {
        public string Permission { get; set; }
    }

    public class RoleListDto : EntityDto, IHasCreationTime
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsStatic { get; set; }

        public bool IsDefault { get; set; }

        public DateTime CreationTime { get; set; }
    }
}