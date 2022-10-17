using MongoDB.Driver;
using SKYNET.Models;
using System;
using System.Collections.Generic;
using System.Threading;

namespace SKYNET.DB
{
    public static class StudyPlansDB
    {
        private static MongoDbCollection<StudyPlan> DB;
        private static MongoDbCollection<Plan> PlanDB;

        public static List<StudyPlan> StudyPlans
        {
            get
            {
                try
                {
                    return DB.Collection.Find(s => s != null).ToList();
                }
                catch (System.Exception)
                {
                    return new List<StudyPlan>();
                }
            }
        }

        public static void Initialize()
        {
            DB = new MongoDbCollection<StudyPlan>("SIGPU_StudyPlan");

            DB.CreateIndex(Builders<StudyPlan>.IndexKeys.Ascending((StudyPlan i) => i.ID));
            DB.CreateIndex(Builders<StudyPlan>.IndexKeys.Ascending((StudyPlan i) => i.Name));
        }

        public static bool Register(StudyPlan source)
        {
            var target = Get(source.ID);
            if (target == null)
            {
                source.ID = CreateID();
                DB.Collection.InsertOne(source);
                return true;
            }
            Common.Show($"El Plan {source.Name} existe.");
            return false;
        }

        public static void Update(StudyPlan source)
        {
            DB.Collection.FindOneAndUpdate((StudyPlan plan) => plan.ID == source.ID, DB.Ub
                .Set((StudyPlan a) => a.Name, source.Name)
                .Set((StudyPlan a) => a.Plans, source.Plans));
        }

        public static bool Exists(string Name)
        {
            return Get(Name) != null;
        }

        public static List<StudyPlan> Get(Career career)
        {
            var Plans = new List<StudyPlan>();
            var Groups = GroupDB.GetGroups(career);
            foreach (var group in Groups)
            {
                var plan = Plans.Find(p => p.ID == group.StudyPlanID);
                if (plan == null)
                {
                    if (Get(group.StudyPlanID, out var targetPlan))
                    {
                        Plans.Add(targetPlan);
                    }
                }
            }
            return Plans;
        }

        public static List<Plan> GetPlans(uint StudyPlanID)
        {
            var StudyPlan = Get(StudyPlanID);
            if (StudyPlan != null)
            {
                return StudyPlan.Plans;
            }
            return new List<Plan>();
        }

        public static StudyPlan Get(string Name)
        {
            return DB.Collection.Find((StudyPlan s) => s.Name == Name, null).FirstOrDefault();
        }

        public static Plan GetPlan(uint ID)
        {
            return PlanDB.Collection.Find((Plan s) => s.ID == ID, null).FirstOrDefault();
        }

        public static bool Exists(uint ID)
        {
            return Get(ID) != null;
        }

        public static StudyPlan Get(uint ID)
        {
            return DB.Collection.Find((StudyPlan s) => s.ID == ID, null).FirstOrDefault();
        }

        public static bool Get(uint ID, out StudyPlan Plan)
        {
            Plan = Get(ID);
            return Plan != null;
        }

        public static uint CreateID()
        {
            uint ID = DB.Collection.Find(FilterDefinition<StudyPlan>.Empty, null).SortByDescending((StudyPlan u) => (object)u.ID).Project((StudyPlan u) => u.ID).FirstOrDefault(default(CancellationToken));
            return ID <= 0U ? 1 : ID + 1;
        }
    }
}
