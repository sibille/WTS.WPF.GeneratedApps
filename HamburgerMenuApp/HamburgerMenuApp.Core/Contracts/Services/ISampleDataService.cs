using System.Collections.Generic;
using System.Threading.Tasks;

using HamburgerMenuApp.Core.Models;

namespace HamburgerMenuApp.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetMasterDetailDataAsync();
    }
}
