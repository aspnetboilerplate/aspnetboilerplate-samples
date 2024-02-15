using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleTaskSystem.Tasks.Dto
{
    public class UpdateTaskInput: EntityDto<long>
    {
        public TaskState? State { get; set; }
    }
}
