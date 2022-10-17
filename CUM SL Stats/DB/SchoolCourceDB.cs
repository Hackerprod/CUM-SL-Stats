using MongoDB.Driver;
using SKYNET.Models;
using System.Collections.Generic;
using System.Linq;

namespace SKYNET.DB
{
    public static class SchoolCourceDB
    {
        private static MongoDbCollection<SchoolCource> DB;

        public static List<SchoolCource> SchoolCources
        {
            get
            {
                try
                {
                    return DB.Collection.Find(s => s != null).ToList();
                }
                catch (System.Exception)
                {
                    return new List<SchoolCource>();
                }
            }
        }

        public static void Initialize()
        {
            DB = new MongoDbCollection<SchoolCource>("SIGPU_SchoolCource");

            DB.CreateIndex(Builders<SchoolCource>.IndexKeys.Ascending((SchoolCource i) => i.ID));
            DB.CreateIndex(Builders<SchoolCource>.IndexKeys.Ascending((SchoolCource i) => i.Name));
        }

        public static bool Register(SchoolCource source)
        {
            var target = Get(source.ID);
            if (target == null)
            {
                source.ID = CreateID();
                DB.Collection.InsertOne(source);
                return true;
            }
            Common.Show($"El curso {source.Name} existe.");
            return false;
        }

        public static SchoolCource Get(uint ID)
        {
            return DB.Collection.Find((SchoolCource usr) => usr.ID == ID, null).FirstOrDefault();
        }

        public static SchoolCource Get(Group group)
        {
            return Get(group.CourceID);
        }

        public static SchoolCource Get(string Name)
        {
            return DB.Collection.Find((SchoolCource usr) => usr.Name == Name, null).FirstOrDefault();
        }

        public static bool Get(string Name, out SchoolCource cource)
        {
            cource = Get(Name);
            return cource != null; ;
        }

        public static List<SchoolCource> GetActiveCources(uint iD)
        {
            var cources = new List<SchoolCource>();
            var cource = Get(iD);

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
                var tempCource = Get(tempName);
                if (tempCource != null)
                {
                    cources.Add(tempCource);
                }
            }
            return cources;
        }

        public static bool Remove(SchoolCource cource)
        {
            var Result = DB.Collection.DeleteOne(c => c.ID == cource.ID);
            if (Result.DeletedCount == 1)
            {
                //var groups = GroupDB.GetGroups(cource);
                //foreach (var group in groups)
                //{
                //    var students = StudentDB.Students.FindAll(g => g.GroupID == group.ID);
                //    foreach (var student in students)
                //    {
                //        DB.Delete(student);
                //    }

                //    DB.Delete(group);
                //}

                return true;
            }
            return false;
        }

        public static bool IsValidCourceName(string stringCource, out string CourceName)
        {
            CourceName = "";
            if (!string.IsNullOrEmpty(stringCource) && stringCource.Contains("-"))
            {
                var years = stringCource.Split('-');
                if (int.TryParse(years[0], out int Year1) && int.TryParse(years[1], out int Year2))
                {
                    CourceName = years[0] + "-" + years[1];
                    return Year1 + 1 == Year2;
                }
            }
            return false;
        }

        public static List<string> GetYears(SchoolCource cource, Career career)
        {
            List<string> Years = new List<string>();
            var Cources = GetActiveCources(cource.ID);

            foreach (var Cource in Cources)
            {
                if (GroupDB.Exist(Cource, career))
                {
                    var name = StudentDB.GetCourceYear(Cource, (uint)frmMain.Settings.CurrentCource);
                    Years.Add(name);
                }
            }
            return Years;
        }

        public static uint CreateID()
        {
            uint ID = DB.Collection.Find(FilterDefinition<SchoolCource>.Empty, null).SortByDescending((SchoolCource u) => (object)u.ID).Project((SchoolCource u) => u.ID).FirstOrDefault();
            return ID <= 0U ? 1 : ID + 1;
        }
    }
}
