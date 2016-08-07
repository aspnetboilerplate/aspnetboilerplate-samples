using System;
using System.ComponentModel.DataAnnotations;
using Abp.AutoMapper;

namespace Acme.SimpleTaskApp.Tasks.Dtos
{
    [AutoMapTo(typeof(Task))]
    public class CreateTaskInput
    {
        [Required]
        [MaxLength(Task.MaxTitleLength)]
        public string Title { get; set; }

        [MaxLength(Task.MaxDescriptionLength)]
        public string Description { get; set; }

        public Guid? AssignedPersonId { get; set; }
    }
}