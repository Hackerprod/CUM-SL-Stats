using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class SchoolCourceDB
    {
        private static SQLiteAsyncConnection DB;
        private static AsyncTableQuery<SchoolCource> Table;

        public async static Task Initialize(SQLiteAsyncConnection dB)
        {
            DB = dB;
            await DB.CreateTableAsync<SchoolCource>();

            Table = DB.Table<SchoolCource>();
        }

        public static async Task<bool> Register(SchoolCource source)
        {
            SchoolCource target = await Table.Where(s => s.Name == source.Name).FirstOrDefaultAsync();
            if (target == null)
            {
                await DB.InsertAsync(source);
                return true;
            }
            Common.Show($"El curso {source.Name} existe.");
            return false;
        }

        public static async Task<List<SchoolCource>> Get()
        {
            return await Table.ToListAsync();
        }

        public static async Task<SchoolCource> Get(uint ID)
        {
            return await Table.Where(s => s.ID == ID).FirstOrDefaultAsync();
        }

        public static async Task<SchoolCource> Get(Group group)
        {
            return await Table.Where(s => s.ID == group.CourceID).FirstOrDefaultAsync();
        }

        public static async Task<SchoolCource> Get(string Name)
        {
            return await Table.Where(s => s.Name == Name).FirstOrDefaultAsync();
        }

        public static async Task<List<SchoolCource>> GetActiveCources(uint iD)
        {
            var cources = new List<SchoolCource>();
            var cource = await Get(iD);

            int minYear = 0;
            int maxYear = 0;

            cources.Add(cource);

            if (string.IsNullOrEmpty(cource.Name) && !cource.Name.Contains("-"))
            {
                return cources;
            }

            var years = cource.Name.Split('-');
            if (!int.TryParse(years[0], out minYear) && !int.TryParse(years[1], out maxYear))
            {
                return cources;
            }

            for (int i = 1; i < 5; i++)
            {
                var tempName = $"{(minYear - i)}-{((minYear - i) + 1)}";
                var tempCource = await Get(tempName);
                if (tempCource != null)
                {
                    cources.Add(tempCource);
                }
            }
            return cources;
        }

        public static async Task<bool> Remove(SchoolCource cource)
        {
            if (await DB.DeleteAsync(cource) == 1)
            {
                var groups = await GroupDB.Get(cource);
                foreach (var group in groups)
                {
                    var students = await StudentDB.Get(group);
                    foreach (var student in students)
                    {
                        await DB.DeleteAsync(student);
                    }

                    await DB.DeleteAsync(group);
                }

                return true;
            }
            return false;
        }

        public static async Task<string> IsValidCourceName(string stringCource)
        {
            var CourceName = "";
            if (!string.IsNullOrEmpty(stringCource) && stringCource.Contains("-"))
            {
                var years = stringCource.Split('-');
                if (int.TryParse(years[0], out int Year1) && int.TryParse(years[1], out int Year2))
                {
                    CourceName = years[0] + "-" + years[1];
                    if (Year1 + 1 != Year2)
                    return null;
                }
            }
            return CourceName;
        }

        public static async Task<List<string>> GetYears(SchoolCource cource, Career career)
        {
            List<string> Years = new List<string>();
            var Cources = await GetActiveCources(cource.ID);

            foreach (var Cource in Cources)
            {
                if (await GroupDB.Exist(Cource, career))
                {
                    var name = await StudentDB.GetCourceYear(Cource, (uint)frmMain.Settings.CurrentCource);
                    Years.Add(name);
                }
            }
            return Years;
        }

        public static async Task<SchoolCource> GetCourceByName(string name)
        {
            return await Table.Where(g => g.Name == name).FirstOrDefaultAsync();
        }
    }
}