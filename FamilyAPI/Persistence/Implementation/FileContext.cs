using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using FamilyAPI.Data;
using Models;

namespace FileData
{
    public class FileContext : IFileContext
    {
      
        private IList<Adult> Adults { get;  set; }
        private readonly string adultsFile = "adults.json";

        public FileContext()
        {
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }
        
        public async Task AddAdultAsync(Adult adult)
        {
            Boolean flag = true;
            foreach (Adult element in Adults)
            {
                if (element.Id == adult.Id)
                {
                    flag = false;
                }
            }

            if (flag)
            {
                Adults.Add(adult);
                SaveChanges();
            }
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            return Adults;
        }


        public async Task DeleteAdultAsync(IList<Adult> adult)
        {
            for (int i = 0; i < adult.Count; i++)
            {
                Adults.Remove(adult[i]);
                Console.WriteLine(adult[i]);
            }
            SaveChanges();
        }

        public async Task<IList<Adult>> GetAdultsByCriteriaAsync(string Name)
        {
            IList<Adult> helper = new List<Adult>();

            foreach (Adult adult in Adults)
            {
                if (adult.FirstName.Equals(Name))
                {
                    helper.Add(adult);
                    return helper;
                }
            }
            return null;
        }
        
        private void SaveChanges()
        {
            
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }
    }
}