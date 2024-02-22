using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace SimpleTaskSystem.Tasks.Dto
{
    /// <summary>
    /// A DTO class that can be used in various application service methods when needed to send/receive Task objects.
    /// </summary>
    /// 
    [AutoMap(typeof(Task))]
    public class TaskDto : EntityDto<long>
    {
        public int? AssignedUserId { get; set; }

        public string AssignedUserName { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public byte State { get; set; }

    }
}
