using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileData;
using Models;

namespace FamilyAPI.Data.Implementation
{
    public class FamilyService : IFamilyService
    {
        private readonly IFileContext fileContext;

        public FamilyService(IFileContext fileContext)
        {
            this.fileContext = fileContext;
        }
        public async Task<IList<Adult>> GetAdultByCriteriaAsync(string name)
        {
            Console.WriteLine(name);
            var adults = await fileContext.GetAdultsByCriteriaAsync(name);
            Console.WriteLine(adults);
            return adults;
        }

        public async Task DeleteAdultsAsync(IList<Adult> adults)
        {
            await fileContext.DeleteAdultAsync(adults);
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            var adults = await fileContext.GetAdultsAsync();
            return adults;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            await fileContext.AddAdultAsync(adult);
        }
    }
}