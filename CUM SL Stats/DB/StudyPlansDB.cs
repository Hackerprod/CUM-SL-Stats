using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace SKYNET.DB
{
    public static class StudyPlansDB
    {
        private static SQLiteDatabase DB;
        public static List<StudyPlan> StudyPlans => DB.GetTables<StudyPlan>();
        public static List<Plan> Plans => DB.GetTables<Plan>();

        public static void Initialize(SQLiteDatabase dB)
        {
            DB = dB;

            DB.CreateTable<StudyPlan>();
            DB.DBConnection.CreateIndex("StudyPlan", "ID");
            DB.DBConnection.CreateIndex("StudyPlan", "Name");

            DB.CreateTable<Plan>();
            DB.DBConnection.CreateIndex("Plan", "ID");
            DB.DBConnection.CreateIndex("Plan", "SubjectID");
        }

        public static bool Register(StudyPlan source)
        {
            StudyPlan target = StudyPlans.Find(s => s.ID == source.ID);
            if (target == null)
            {
                source.ID = CreateID();
                DB.InsertOrUpdate(source);
                return true;
            }
            Common.Show($"El Plan {source.Name} existe.");
            return false;
        }

        public static bool Register(Plan source)
        {
            if (Plans.Find(s => s.ID == source.ID) == null)
            {
                source.ID = CreatePlansID();
                DB.InsertOrReplace(source);
                return true;
            }
            return false;
        }

        public static void Update(StudyPlan source)
        {
            DB.InsertOrUpdate(source);
        }

        public static void Update(Plan source)
        {
            DB.InsertOrUpdate(source);
        }

        public static bool Exists(string Name)
        {
            return StudyPlans.Find(c => c.Name == Name) != null;
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
            var plans = new List<Plan>();
            var StudyPlan = Get(StudyPlanID);
            if (StudyPlan != null)
            {
                return GetPlans(StudyPlan);
            }
            return new List<Plan>();
        }

        public static List<Plan> GetPlans(StudyPlan StudyPlan)
        {
            var plans = new List<Plan>();
            foreach (var plan in StudyPlan.Plans)
            {
                var targetPlan = Plans.Find(p => p.ID == plan);
                if (targetPlan != null)
                {
                    plans.Add(targetPlan);
                }
            }
            return plans;
        }

        public static StudyPlan Get(string Name)
        {
            return StudyPlans.Find(c => c.Name == Name);
        }

        public static bool Exists(uint SubjectID)
        {
            return StudyPlans.Find(c => c.ID == SubjectID) != null;
        }

        public static StudyPlan Get(uint SubjectID)
        {
            return StudyPlans.Find(c => c.ID == SubjectID);
        }

        public static bool Get(uint SubjectID, out StudyPlan Plan)
        {
            Plan = Get(SubjectID);
            return Plan != null;
        }

        public static uint CreateID()
        {
            StudyPlans.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return StudyPlans.Count == 0 ? 1 : StudyPlans[StudyPlans.Count - 1].ID + 1;
        }

        public static uint CreatePlansID()
        {
            Plans.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return Plans.Count == 0 ? 1 : Plans[Plans.Count - 1].ID + 1;
        }
    }
}
