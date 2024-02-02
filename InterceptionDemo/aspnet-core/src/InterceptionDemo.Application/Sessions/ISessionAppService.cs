﻿using System.Threading.Tasks;
using Abp.Application.Services;
using InterceptionDemo.Sessions.Dto;

namespace InterceptionDemo.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
