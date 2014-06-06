using System.Collections.Generic;
using System.Linq;
using Abp.Domain.Repositories.NHibernate;
using NHibernate.Linq;
using SimpleTaskSystem.Tasks;

namespace SimpleTaskSystem.NHibernate.Repositories
{
    public class TaskRepository : NhRepositoryBase<Task, long>, ITaskRepository
    {
        public List<Task> GetAllWithPeople(int? assignedPersonId, TaskState? state)
        {
            var query = GetAll();
            
            if (assignedPersonId.HasValue)
            {
                query = query.Where(task => task.AssignedPerson.Id == assignedPersonId.Value);
            }

            if (state.HasValue)
            {
                query = query.Where(task => task.State == state);
            }

            return query
                .OrderByDescending(task => task.CreationTime)
                .Fetch(task => task.AssignedPerson)
                .ToList();
        }
    }
}
