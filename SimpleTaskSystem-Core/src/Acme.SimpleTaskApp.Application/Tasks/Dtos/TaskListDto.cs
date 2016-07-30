using System;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace Acme.SimpleTaskApp.Tasks.Dtos
{
    [AutoMapFrom(typeof(Task))]
    public class TaskListDto : EntityDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }
    }
}