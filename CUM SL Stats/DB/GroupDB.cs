using MongoDB.Driver;
using SKYNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SKYNET.DB
{
    public static class GroupDB
    {
        private static MongoDbCollection<Group> DB;

        public static List<Group> Groups
    {
            get
            {
                try
                {
                    return DB.Collection.Find(s => s != null).ToList();
                }
                catch (System.Exception)
                {
                    return new List<Group>();
                }
            }
        }

        public static void Initialize()
        {
            DB = new MongoDbCollection<Group>("SIGPU_Group");

            DB.CreateIndex(Builders<Group>.IndexKeys.Ascending((Group i) => i.ID));
            DB.CreateIndex(Builders<Group>.IndexKeys.Ascending((Group i) => i.Name));
            DB.CreateIndex(Builders<Group>.IndexKeys.Ascending((Group i) => i.StudyPlanID));
        }

        public static bool Register(Group source)
        {
            var target = Get(source.ID);
            if (target == null)
            {
                source.ID = CreateID();
                DB.Collection.InsertOne(source);
                return true;
            }
            return false;
        }

        public static Group Get(string Name)
        {
            return DB.Collection.Find(g => g.Name == Name, null).FirstOrDefault();
        }

        public static Group Get(uint ID)
        {
            return DB.Collection.Find(g => g.ID == ID, null).FirstOrDefault();
        }

        public static Group Get(SchoolCource cource)
        {
            return DB.Collection.Find(g => g.CourceID == cource.ID, null).FirstOrDefault();
        }

        public static Group GetGroup(string Name, SchoolCource cource, Career career)
        {
            return DB.Collection.Find(g => g.Name == Name && g.CourceID == cource.ID && g.CareerID == career.ID).FirstOrDefault();
        }

        public static bool GetGroup(SchoolCource cource, Career career, string Name, out Group group)
        {
            group = DB.Collection.Find(g => g.CourceID == cource.ID && g.CareerID == career.ID && g.Name == Name).FirstOrDefault();
            return group != null;
        }

        public static List<Group> GetGroups(SchoolCource cource, Career career)
        {
            return DB.Collection.Find(g => g.CourceID == cource.ID && g.CareerID == career.ID).ToList();
        }

        public static List<Group> GetGroups(Career career)
        {
            return DB.Collection.Find(g => g.CareerID == career.ID).ToList(); 
        }

        public static List<Group> GetGroups(SchoolCource cource)
        {
            return DB.Collection.Find(g => g.CourceID == cource.ID, null).ToList();  
        }

        public static List<Group> GetActiveGroups(uint ID)
        {
            var groups = new List<Group>();
            var cources = SchoolCourceDB.GetActiveCources(ID);
            foreach (var cource in cources)
            {
                var tempGroups = GetGroups(cource);
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

        public static bool Exist(SchoolCource cource)
        {
            return Get(cource) != null;
        }

        public static bool Exist(SchoolCource cource, Career career)
        {
            return DB.Collection.Find(g => g.CourceID == cource.ID && g.CareerID == career.ID).FirstOrDefault() != null;
        }

        public static uint CreateID()
        {
            uint ID = DB.Collection.Find(FilterDefinition<Group>.Empty, null).SortByDescending((Group u) => (object)u.ID).Project((Group u) => u.ID).FirstOrDefault();
            return ID <= 0U ? 1 : ID + 1;
        }

        public static void Update(Group group)
        {
            DB.Collection.FindOneAndUpdate((Group g) => g.ID == group.ID, DB.Ub
            .Set((Group a) => a.Name, group.Name)
            .Set((Group a) => a.CourceID, group.CourceID)
            .Set((Group a) => a.StudyPlanID, group.StudyPlanID)
            .Set((Group a) => a.CareerID, group.CareerID));
        }

        public static void Remove(Group group)
        {
            DB.Collection.DeleteOne(g => g.ID == group.ID);
        }
    }
}
