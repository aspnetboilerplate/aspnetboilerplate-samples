using Abp.Application.Editions;
using Abp.Domain.Repositories;
using OrganizationUnitsDemo.Features;

namespace OrganizationUnitsDemo.Editions
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
