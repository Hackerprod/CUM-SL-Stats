using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class CareerDB
    {
        private static SQLiteAsyncConnection DB;
        private static AsyncTableQuery<Career> Table;

        public async static Task Initialize(SQLiteAsyncConnection dB)
        {
            DB = dB;

            await DB.CreateTableAsync<Career>();
            Table = DB.Table<Career>();
        }

        public static async Task<bool> Register(Career source)
        {
            Career target = await Table.Where(s => s.Name == source.Name).FirstOrDefaultAsync();
            if (target == null)
            {
                await DB.InsertOrReplaceAsync(source);
                return true;
            }
            Common.Show($"La carrera {source.Name} existe.");
            return false;
        }

        public static async Task<List<Career>> Get()
        {
            return await Table.ToListAsync();
        }

        public static async Task<Career> Get(uint ID)
        {
            return await Table.Where(s => s.ID == ID).FirstOrDefaultAsync();
        }

        public static async Task<Career> Get(Group group)
        {
            return await Table.Where(c => c.ID == group.CareerID).FirstOrDefaultAsync();
        }

        public static async Task<Career> Get(string Name)
        {
            return await Table.Where(s => s.Name == Name).FirstOrDefaultAsync();
        }

        public static async Task<List<Career>> Get(SchoolCource cource)
        {
            var careers = new List<Career>();
            try
            {
                var allgroups = await GroupDB.GetActiveGroups(cource.ID);
                var groups = new List<Group>();

                foreach (var group in allgroups)
                {
                    var current = groups.Find(g => g.CourceID == group.CourceID && g.CareerID == group.CareerID);
                    if (current == null)
                    {
                        groups.Add(group);
                    }
                }

                foreach (var group in groups)
                {
                    var Career = await Get(group.CareerID);
                    if (Career != null && careers.Find(c => c.ID == Career.ID || c.Name == Career.Name) == null)
                    {
                        careers.Add(Career);
                    }
                }
            }
            catch
            {
            }
            return careers;
        }
    }
}