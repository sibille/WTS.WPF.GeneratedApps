using System.Collections.Generic;
using System.Threading.Tasks;

using MenuBarApp.Core.Models;

namespace MenuBarApp.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetMasterDetailDataAsync();
    }
}
