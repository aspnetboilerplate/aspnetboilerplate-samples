using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Hotel.Authorization;

namespace Hotel
{
    [DependsOn(
        typeof(HotelCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class HotelApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<HotelAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(HotelApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
