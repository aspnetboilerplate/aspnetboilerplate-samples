using Abp.Authorization;
using Abp.Threading;
using AbpWcfDemo.Events;
using AbpWcfDemo.Events.Dto;
using AbpWcfDemo.Wcf;

namespace AbpWcfDemo.Services {

    [AbpAuthorize]
    public class EventsSoapService : AbpService, IEventsSoapService {

        private readonly IEventsAppService _eventsAppService;
        //public IAbpSession AbpSession { get; set; }
        //public IPermissionManager PermissionManager { get; set; }
        //public ISettingManager SettingManager { get; set; }
        //public IPermissionChecker PermissionChecker { protected get; set; }
        //public ILogger Logger { get; set; }

        public EventsSoapService(IEventsAppService eventsAppService) {
            //AbpSession = NullAbpSession.Instance;
            //Logger = NullLogger.Instance;
            //PermissionChecker = NullPermissionChecker.Instance;

            _eventsAppService = eventsAppService;
        }

        //public EventDto GetData(int id) {
        //    return _eventsAppService.Get(id);
        //}

        [AbpAllowAnonymous]
        public string GetNextAvailable() {
            EventDto eventz = null;
            AsyncHelper.RunSync(async () => {
                eventz = await _eventsAppService.NextAvailable();
            });

            return $"{eventz.Title} - start on {eventz.Start}";
        }

    }
}
