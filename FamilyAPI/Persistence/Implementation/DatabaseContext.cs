using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyAPI.Data;
using FamilyAPI.DataAccess;
using Microsoft.EntityFrameworkCore;
using Models;

namespace FileData
{
    public class DatabaseContext : IFileContext
    {

        public async Task AddAdultAsync(Adult adult)
    {
        using (FamilyDbContext dbContext = new FamilyDbContext())
        {
            await dbContext.Persons.AddAsync(adult.Persona);
            await dbContext.SaveChangesAsync();
            await dbContext.Jobs.AddAsync(adult.AdultJob);
            await dbContext.SaveChangesAsync();
            await dbContext.Adults.AddAsync(adult);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IList<Adult>> GetAdultsAsync()
    {
        using (FamilyDbContext dbContext = new FamilyDbContext())
        {
            IList<Adult> adultResult = dbContext.Adults.Include(p => p.Persona)
                .Include(p => p.AdultJob).ToList();
            return adultResult;
        }
    }

    public async Task DeleteAdultAsync(IList<Adult> adults)
    {
        using (FamilyDbContext dbContext = new FamilyDbContext())
        {
            foreach (var element in adults)
            {
                dbContext.Remove(element);
                await dbContext.SaveChangesAsync();
                dbContext.Remove(element.Persona);
                await dbContext.SaveChangesAsync();
                dbContext.Remove(element.AdultJob);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    public async Task<IList<Adult>> GetAdultsByCriteriaAsync(string name)
    {
        using (FamilyDbContext dbContext = new FamilyDbContext())
        {
            IList<Adult> adultResult = dbContext.Adults.Include(a => a.Persona)
                .Include(a => a.AdultJob).Where(a => a.Persona.FirstName.Equals(name)).ToList();
            return adultResult;
        }
    }
    }
}