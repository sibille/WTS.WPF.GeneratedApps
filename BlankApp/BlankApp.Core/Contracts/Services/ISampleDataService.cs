using System.Collections.Generic;
using System.Threading.Tasks;

using BlankApp.Core.Models;

namespace BlankApp.Core.Contracts.Services
{
    public interface ISampleDataService
    {
        Task<IEnumerable<SampleOrder>> GetMasterDetailDataAsync();
    }
}
