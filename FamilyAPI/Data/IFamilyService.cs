using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyAPI.Data
{
    public interface IFamilyService
    {
        Task<IList<Adult>> GetAdultByCriteriaAsync(string name);
        Task DeleteAdultsAsync(IList<Adult> adults);
        Task<IList<Adult>> GetAdultsAsync();
        Task AddAdultAsync(Adult adult);
    }
}