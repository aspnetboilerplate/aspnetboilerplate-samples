using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;

namespace SimpleTaskSystem.Tasks.Dtos
{
    public class CreateTaskInput : IInputDto
    {
        public int? AssignedPersonId { get; set; }

        [Required]
        public string Description { get; set; }
    }
}