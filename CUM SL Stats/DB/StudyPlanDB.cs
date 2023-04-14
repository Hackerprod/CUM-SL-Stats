using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class StudyPlanDB
    {
        private static SQLiteAsyncConnection DB;
        private static AsyncTableQuery<StudyPlan> Table;

        public async static Task Initialize(SQLiteAsyncConnection dB)
        {
            DB = dB;

            await DB.CreateTableAsync<StudyPlan>();

            Table = DB.Table<StudyPlan>();
        }

        public static async Task<bool> Register(StudyPlan source)
        {
            StudyPlan target = await Get(source.ID); 
            if (target == null)
            {
                await DB.InsertOrReplaceAsync(source);
                return true;
            }
            Common.Show($"El Plan {source.Name} existe.");
            return false;
        }

        public static async Task<List<StudyPlan>> Get()
        {
            return await Table.ToListAsync();
        }

        public static async Task Update(StudyPlan source)
        {
            await DB.InsertOrReplaceAsync(source);
        }

        public static async Task<bool> Exists(string Name)
        {
            return (await Table.Where(c => c.Name == Name).FirstOrDefaultAsync()) != null;
        }

        public static async Task<List<StudyPlan>> Get(Career career)
        {
            var Plans = new List<StudyPlan>();
            var Groups = await GroupDB.Get(career);
            foreach (var group in Groups)
            {
                var plan = Plans.Find(p => p.ID == group.StudyPlanID);
                if (plan == null)
                {
                    var targetPlan = await Get(group.StudyPlanID);
                    if (targetPlan != null)
                    {
                        Plans.Add(targetPlan);
                    }
                }
            }
            return Plans;
        }

        public static async Task<List<Plan>> GetPlans(uint StudyPlanID)
        {
            var plans = new List<Plan>();
            var StudyPlan = await Get(StudyPlanID);
            if (StudyPlan != null)
            {
                return await GetPlans(StudyPlan);
            }
            return new List<Plan>();
        }

        public static async Task<List<Plan>> GetPlans(StudyPlan StudyPlan)
        {
            return await PlanDB.Get(StudyPlan);
        }

        public static async Task<StudyPlan> Get(string Name)
        {
            return await Table.Where(c => c.Name == Name).FirstOrDefaultAsync();
        }

        public static async Task<StudyPlan> Get(uint ID)
        {
            return await Table.Where(c => c.ID == ID).FirstOrDefaultAsync();
        }
    }
}