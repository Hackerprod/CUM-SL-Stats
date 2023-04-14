using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class PlanDB
    {
        private static SQLiteAsyncConnection DB;
        private static AsyncTableQuery<Plan> Table => DB.Table<Plan>();

        public async static Task Initialize(SQLiteAsyncConnection dB)
        {
            DB = dB;

            await DB.CreateTableAsync<Plan>();
        }

        public static async Task<bool> Register(Plan source)
        {
            if (await Table.Where(s => s.ID == source.ID).FirstOrDefaultAsync() == null)
            {
                await DB.InsertOrReplaceAsync(source);
                return true;
            }
            return false;
        }

        public static async Task<List<Plan>> Get()
        {
            return await Table.ToListAsync();
        }

        public static async Task<List<Plan>> Get(StudyPlan studyPlan)
        {
            var plans = new List<Plan>();
            foreach (var planID in studyPlan.Plans)
            {
                var plan = await Get(planID);
                if (plan != null)
                {
                    plans.Add(plan);
                }
            }
            return plans;
        }

        public static async Task<Plan> Get(uint ID)
        {
            return await Table.Where(p => p.ID == ID).FirstOrDefaultAsync();
        }

        public static async Task Update(Plan source)
        {
            await DB.InsertOrReplaceAsync(source);
        }

        public static async Task<bool> Exists(uint ID)
        {
            return (await Table.Where(c => c.ID == ID).FirstOrDefaultAsync()) != null;
        }
    }
}