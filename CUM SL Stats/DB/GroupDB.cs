using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class GroupDB
    {
        private static SQLiteAsyncConnection DB;
        private static AsyncTableQuery<Group> Table => DB.Table<Group>();

        public async static Task Initialize(SQLiteAsyncConnection dB)
        {
            DB = dB;
           await DB.CreateTableAsync<Group>();
        }

        public static async Task<bool> Register(Group source)
        {
            Group target = await Table.Where(s => s.Name == source.Name).FirstOrDefaultAsync();
            if (target == null)
            {
                await DB.InsertOrReplaceAsync(source);
                return true;
            }
            return false;
        }

        public static async Task<List<Group>> Get()
        {
            return await Table.ToListAsync();
        }

        public static async Task<Group> Get(string Name)
        {
            return await Table.Where(g => g.Name == Name).FirstOrDefaultAsync();
        }

        public static async Task<Group> Get(uint ID)
        {
            return await Table.Where(g => g.ID == ID).FirstOrDefaultAsync();
        }

        public static async Task<Group> Get(string Name, SchoolCource cource, Career career)
        {
            return await Table.Where(g => g.Name == Name && g.CourceID == cource.ID && g.CareerID == career.ID).FirstOrDefaultAsync();
        }

        public static async Task<Group> Get(SchoolCource cource, Career career, string Name)
        {
            return await Table.Where(g => g.CourceID == cource.ID && g.CareerID == career.ID && g.Name == Name).FirstOrDefaultAsync();
        }

        public static async Task<List<Group>> Get(SchoolCource cource, Career career)
        {
            return await Table.Where(g => g.CourceID == cource.ID && g.CareerID == career.ID).ToListAsync();
        }

        public static async Task<List<Group>> Get(Career career)
        {
            return await Table.Where(g => g.CareerID == career.ID).ToListAsync();
        }

        public static async Task<List<Group>> Get(SchoolCource cource)
        {
            return await Table.Where(g => g.CourceID == cource.ID).ToListAsync();
        }

        public static async Task<List<Group>> GetActiveGroups(uint ID)
        {
            var groups = new List<Group>();
            var cources = await SchoolCourceDB.GetActiveCources(ID);
            foreach (var cource in cources)
            {
                var tempGroups = await Table.Where(g => g.CourceID == cource.ID).ToListAsync();
                foreach (var group in tempGroups)
                {
                    if (!groups.Contains(group))
                    {
                        groups.Add(group);
                    }
                }
            }
            return groups;
        }

        public static async Task<bool> Exist(SchoolCource cource)
        {
            return await Table.Where(g => g.CourceID == cource.ID).FirstOrDefaultAsync() != null;
        }

        public static async Task<bool> Exist(SchoolCource cource, Career career)
        {
            return (await Table.Where(g => g.CourceID == cource.ID && g.CareerID == career.ID).FirstOrDefaultAsync()) != null;
        }

        public static async Task Update(Group group)
        {
            await DB.InsertOrReplaceAsync(group);
        }

        public static async Task Remove(Group group)
        {
            await DB.DeleteAsync(group);
        }
    }
}
