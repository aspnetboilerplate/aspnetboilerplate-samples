using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace SimpleTaskSystem.Tasks.Dto
{
    [AutoMapTo(typeof(Task))]
    public class CreateTaskInput
    {
        public string Description { get; set; }
        public int AssignedUserId { get; set; }
    }
}
