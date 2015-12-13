using System;
using Abp.Dependency;
using Abp.Events.Bus.Entities;
using Abp.Events.Bus.Handlers;

namespace MultipleDbContextDemo.Services
{
    public class MyCourseCreateHandler : IEventHandler<EntityCreatedEventData<Course>>, ITransientDependency
    {
        public void HandleEvent(EntityCreatedEventData<Course> eventData)
        {
            throw new ApplicationException("This is throwed to rollback transaction!");
        }
    }
}