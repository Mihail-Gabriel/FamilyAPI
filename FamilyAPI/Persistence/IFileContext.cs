using System.Collections.Generic;
using System.Threading.Tasks;
using Models;

namespace FamilyAPI.Data
{
    public interface IFileContext
    {
         Task AddAdultAsync(Adult adult);
         Task<IList<Adult>> GetAdultsAsync();
         Task DeleteAdultAsync(IList<Adult> adults);
         Task<IList<Adult>> GetAdultsByCriteriaAsync(string name);
    }
}