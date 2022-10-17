using MongoDB.Driver;
using SKYNET.Models;
using System.Collections.Generic;
using System.Threading;

namespace SKYNET.DB
{
    public static class SubjectDB
    {
        private static MongoDbCollection<Subject> DB;

        public static List<Subject> Subjects
        {
            get
            {
                try
                {
                    return DB.Collection.Find(s => s != null).ToList();
                }
                catch (System.Exception)
                {
                    return new List<Subject>();
                }
            }
        }

        public static void Initialize()
        {
            DB = new MongoDbCollection<Subject>("SIGPU_Subject");

            DB.CreateIndex(Builders<Subject>.IndexKeys.Ascending((Subject i) => i.ID));
            DB.CreateIndex(Builders<Subject>.IndexKeys.Ascending((Subject i) => i.Name));
        }

        public static bool Register(Subject source)
        {
            var subject = Get(source.ID);
            if (subject == null)
            {
                source.ID = CreateID();
                DB.Collection.InsertOne(source);
                return true;
            }
            Common.Show($"El Plan {source.Name} existe.");
            return false;
        }

        public static bool Exists(string Name)
        {
            return Get(Name) != null;
        }

        public static Subject Get(string Name)
        {
            return DB.Collection.Find((Subject usr) => usr.Name == Name, null).FirstOrDefault();
        }

        public static bool Get(uint ID, out Subject Subject)
        {
            Subject = DB.Collection.Find((Subject usr) => usr.ID == ID, null).FirstOrDefault();
            return Subject != null;
        }

        public static bool Exists(uint SubjectID)
        {
            return Get(SubjectID) != null;
        }

        public static Subject Get(uint SubjectID)
        {
            return DB.Collection.Find((Subject usr) => usr.ID == SubjectID, null).FirstOrDefault(default(CancellationToken));
        }

        public static uint CreateID()
        {
            uint ID = DB.Collection.Find(FilterDefinition<Subject>.Empty, null).SortByDescending((Subject u) => (object)u.ID).Project((Subject u) => u.ID).FirstOrDefault(default(CancellationToken));
            return ID <= 0U ? 1 : ID + 1;
        }
    }
}
