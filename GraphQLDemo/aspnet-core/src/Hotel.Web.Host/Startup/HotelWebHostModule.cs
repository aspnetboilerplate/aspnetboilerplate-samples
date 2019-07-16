using Abp.AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Hotel.Configuration;
using Hotel.Guests;
using Hotel.Reservations;
using Hotel.Rooms;
using Hotel.Web.Host.Models;

namespace Hotel.Web.Host.Startup
{
    [DependsOn(
       typeof(HotelWebCoreModule))]
    public class HotelWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public HotelWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(HotelWebHostModule).GetAssembly());

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<Guest, GuestModel>();
                config.CreateMap<Room, RoomModel>();
                config.CreateMap<Reservation, ReservationModel>();
            });
        }
    }
}
