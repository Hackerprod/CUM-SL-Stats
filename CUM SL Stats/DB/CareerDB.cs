using MongoDB.Driver;
using SKYNET.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SKYNET.DB
{
    public static class CareerDB
    {
        private static MongoDbCollection<Career> DB;

        public static List<Career> Careers
        {
            get
            {
                try
                {
                    return DB.Collection.Find(c => c != null).ToList();
                }
                catch (System.Exception)
                {
                    return new List<Career>();
                }
            }
        }

        public static void Initialize()
        {
            DB = new MongoDbCollection<Career>("SIGPU_Career");

            DB.CreateIndex(Builders<Career>.IndexKeys.Ascending((Career i) => i.ID));
            DB.CreateIndex(Builders<Career>.IndexKeys.Ascending((Career i) => i.Name));
            DB.CreateIndex(Builders<Career>.IndexKeys.Ascending((Career i) => i.StudyPlanID));
        }

        public static bool Register(Career source)
        {
            var target = Get(source.ID);
            if (target == null)
            {
                source.ID = CreateID();
                DB.Collection.InsertOne(source);
                return true;
            }
            Common.Show($"La Carrera {source.Name} existe.");
            return false;
        }

        public static Career Get(uint ID)
        {
            return DB.Collection.Find((Career c) => c.ID == ID, null).FirstOrDefault();
        }

        public static Career Get(Group group)
        {
            return DB.Collection.Find((Career c) => c.ID == group.CareerID, null).FirstOrDefault();
        }

        public static Career Get(string Name)
        {
            return DB.Collection.Find((Career c) => c.Name == Name, null).FirstOrDefault();
        }

        public static bool Get(string Name, out Career career)
        {
            career = Get(Name);
            return career != null;
        }

        public static List<Career> GetCareers(SchoolCource cource)
        {
            var careers = new List<Career>();
            try
            {
                var allgroups = GroupDB.GetActiveGroups(cource.ID);
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
                    var Career = Get(group.CareerID);
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

        public static uint CreateID()
        {
            uint ID = DB.Collection.Find(FilterDefinition<Career>.Empty, null).SortByDescending((Career u) => (object)u.ID).Project((Career u) => u.ID).FirstOrDefault(default(CancellationToken));
            return ID <= 0U ? 1 : ID + 1;
        }
    }
}
