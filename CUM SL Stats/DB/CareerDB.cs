using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class CareerDB
    {
        public static SQLiteDatabase DB;
        public static List<Career> Careers => DB.GetTables<Career>();

        public static void Initialize(SQLiteDatabase dB)
        {
            DB = dB;

            DB.CreateTable<Career>();
            DB.DBConnection.CreateIndex("Career", "ID");
            DB.DBConnection.CreateIndex("Career", "Name");
            DB.DBConnection.CreateIndex("Career", "CourceID");
        }

        public static bool RegisterCareer(Career source)
        {
            Career target = Careers.Find(s => s.Name == source.Name);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            Common.Show($"La carrera {source.Name} existe.");
            return false;
        }

        public static Career GetCareer(uint ID)
        {
            return Careers.Find(s => s.ID == ID);
        }

        public static Career GetCareer(Group group)
        {
            return Careers.Find(c => c.ID == group.CareerID);
        }

        public static Career GetCareer(string Name)
        {
            return Careers.Find(s => s.Name == Name);
        }

        public static bool GetCareer(string Name, out Career career)
        {
            career = GetCareer(Name);
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
                    var Career = GetCareer(group.CareerID);
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

        public static uint CreateCareerId()
        {
            Careers.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return Careers.Count == 0 ? 1 : Careers[Careers.Count - 1].ID + 1;
        }
    }
}
