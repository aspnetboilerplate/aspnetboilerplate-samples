using Abp.Application.Editions;
using Abp.Domain.Repositories;
using InterceptionDemo.Features;

namespace InterceptionDemo.Editions
{
    public class EditionManager : AbpEditionManager
    {
        public const string DefaultEditionName = "Standard";

        public EditionManager(
            IRepository<Edition> editionRepository,
            FeatureValueStore featureValueStore)
            : base(
                editionRepository,
                featureValueStore)
        {
        }
    }
}
