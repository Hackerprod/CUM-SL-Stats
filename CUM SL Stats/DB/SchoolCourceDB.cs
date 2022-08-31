using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class SchoolCourceDB
    {
        private static SQLiteDatabase DB;
        public static List<SchoolCource> SchoolCources => DB.GetTables<SchoolCource>();

        public static void Initialize(SQLiteDatabase dB)
        {
            DB = dB;

            DB.CreateTable<SchoolCource>();
            DB.DBConnection.CreateIndex("SchoolCource", "ID");
            DB.DBConnection.CreateIndex("SchoolCource", "Name");
        }

        public static bool RegisterSchoolCource(SchoolCource source)
        {
            SchoolCource target = SchoolCources.Find(s => s.Name == source.Name);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            Common.Show($"El curso {source.Name} existe.");
            return false;
        }

        public static SchoolCource GetCource(uint ID)
        {
            return SchoolCources.Find(s => s.ID == ID);
        }

        public static SchoolCource GetCource(string Name)
        {
            return SchoolCources.Find(s => s.Name == Name);
        }

        public static bool GetCource(string Name, out SchoolCource cource)
        {
            cource = SchoolCources.Find(s => s.Name == Name);
            return cource != null; ;
        }

        public static List<SchoolCource> GetActiveCources(uint iD)
        {
            var cources = new List<SchoolCource>();
            var cource = GetCource(iD);

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
                var tempCource = GetCource(tempName);
                if (tempCource != null)
                {
                    cources.Add(tempCource);
                }
            }
            return cources;
        }

        public static bool RemoveCource(SchoolCource cource)
        {
            if (DB.Delete(cource) == 1)
            {
                var groups = GroupDB.Groups.FindAll(g => g.CourceID == cource.ID);
                foreach (var group in groups)
                {
                    DB.Delete(group);
                }

                var students = StudentDB.Students.FindAll(g => g.CourceID == cource.ID);
                foreach (var student in students)
                {
                    DB.Delete(student);
                }

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
                if (GroupDB.ExistGroup(Cource, career))
                {
                    var name = StudentDB.GetCourceYear(Cource, (uint)frmMain.Settings.CurrentCource);
                    Years.Add(name);
                }
            }
            return Years;
        }

        public static SchoolCource GetCourceByName(string name)
        {
            return SchoolCources.Find(g => g.Name == name);
        }

        public static uint CreateCourceId()
        {
            SchoolCources.Sort((s1, s2) => s1.ID.CompareTo(s2.ID));
            return SchoolCources.Count == 0 ? 1 : SchoolCources[SchoolCources.Count - 1].ID + 1;
        }
    }
}
