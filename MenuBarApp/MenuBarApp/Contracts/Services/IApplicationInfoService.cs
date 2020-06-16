using System;

namespace MenuBarApp.Contracts.Services
{
    public interface IApplicationInfoService
    {
        Version GetVersion();
    }
}
