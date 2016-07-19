namespace SimpleTaskSystem.Tasks.Dtos
{
    public class GetTasksInput
    {
        public TaskState? State { get; set; }

        public int? AssignedPersonId { get; set; }
    }
}