using System;

namespace HamburgerMenuApp.Contracts.Services
{
    public interface IApplicationInfoService
    {
        Version GetVersion();
    }
}
