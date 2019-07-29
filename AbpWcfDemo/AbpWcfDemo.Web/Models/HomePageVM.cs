using System;
using AbpWcfDemo.Events.Dto;

namespace AbpWcfDemo.Web.Models {

    [Serializable]
    public class HomePageVM {
        public EventDto NextEvent { get; set; }
    }
}