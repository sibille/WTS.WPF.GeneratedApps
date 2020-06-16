using System;
using System.Windows.Controls;

namespace HamburgerMenuApp.Contracts.Services
{
    public interface IPageService
    {
        Type GetPageType(string key);

        Page GetPage(string key);
    }
}
