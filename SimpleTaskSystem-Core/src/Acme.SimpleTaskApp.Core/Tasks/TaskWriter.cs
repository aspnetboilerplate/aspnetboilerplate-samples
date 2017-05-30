using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.BackgroundJobs;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;
using Acme.SimpleTaskApp.People;

namespace Acme.SimpleTaskApp.Core.Tasks
{
    public class TaskCreatedHandler :
        IEventHandler<Abp.Events.Bus.Entities.EntityCreatingEventData<Acme.SimpleTaskApp.Tasks.Task>>,
        ITransientDependency
    {
        private IBackgroundJobManager _mgr;
        private IRepository<Person, Guid> _repo;

        public TaskCreatedHandler(IBackgroundJobManager mgr, IRepository<Person, Guid> repo)
        {
            _mgr = mgr;
            _repo = repo;
        }

        public void HandleEvent(
            Abp.Events.Bus.Entities.EntityCreatingEventData<Acme.SimpleTaskApp.Tasks.Task> eventData)
        {
            Debug.WriteLine("*** Task Created ***");
            var result = _repo.GetAll();
        }
    }
}
