using Abp.EntityFramework;
using AbpWcfDemo.Events;

namespace AbpWcfDemo.EntityFramework.Repositories {

    public class EventRepository : SoapRepositoryBase<Event, int>, IEventRepository {

        public EventRepository(IDbContextProvider<WcfDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }
    }

}
