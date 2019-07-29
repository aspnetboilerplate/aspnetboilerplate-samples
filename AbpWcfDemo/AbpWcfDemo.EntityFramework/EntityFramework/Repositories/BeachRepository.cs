using Abp.EntityFramework;
using AbpWcfDemo.Beachs;

namespace AbpWcfDemo.EntityFramework.Repositories {

    public class BeachRepository : SoapRepositoryBase<Beach, int>, IBeachRepository {

        public BeachRepository(IDbContextProvider<WcfDbContext> dbContextProvider)
            : base(dbContextProvider) {
        }

    }

}
