using System;
using System.Diagnostics;
using System.Reflection;

using HamburgerMenuApp.Contracts.Services;

using OSVersionHelper;

using Windows.ApplicationModel;

namespace HamburgerMenuApp.Services
{
    public class ApplicationInfoService : IApplicationInfoService
    {
        public ApplicationInfoService()
        {
        }

        public Version GetVersion()
        {
            if (WindowsVersionHelper.HasPackageIdentity)
            {
                // Packaged application
                // Set the app version in HamburgerMenuApp.Packaging > Package.appxmanifest > Packaging > PackageVersion
                var packageVersion = Package.Current.Id.Version;
                return new Version(packageVersion.Major, packageVersion.Minor, packageVersion.Build, packageVersion.Revision);
            }

            // Set the app version in HamburgerMenuApp > Properties > Package > PackageVersion
            string assemblyLocation = Assembly.GetExecutingAssembly().Location;
            var version = FileVersionInfo.GetVersionInfo(assemblyLocation).FileVersion;
            return new Version(version);
        }
    }
}
