using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class GroupDB
    {
        private static SQLiteDatabase DB;
        public static List<Group> Groups => DB.GetTables<Group>();

        public static void Initialize(SQLiteDatabase dB)
        {
            DB = dB;

            DB.CreateTable<Group>();
            DB.DBConnection.CreateIndex("Group", "Name");
            DB.DBConnection.CreateIndex("Group", "CourceID");
            DB.DBConnection.CreateIndex("Group", "CareerID");
        }

        public static bool RegisterGroup(Group source)
        {
            Group target = Groups.Find(s => s.Name == source.Name);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            return false;
        }

        public static Group GetGroup(string Name)
        {
            return Groups.Find(g => g.Name == Name);
        }

        public static Group GetGroup(uint ID)
        {
            return Groups.Find(g => g.ID == ID);
        }

        public static Group GetGroup(string Name, SchoolCource cource, Career career)
        {
            return Groups.Find(g => g.Name == Name && g.CourceID == cource.ID && g.CareerID == career.ID);
        }

        public static List<Group> GetGroups(SchoolCource cource, Career career)
        {
            return Groups.FindAll(g => g.CourceID == cource.ID && g.CareerID == career.ID);
        }

        public static bool GetGroup(SchoolCource cource, Career career, string Name, out Group group)
        {
            group = Groups.Find(g => g.CourceID == cource.ID && g.CareerID == career.ID && g.Name == Name);
            return group != null;
        }

        public static List<Group> GetActiveGroups(uint ID)
        {
            var groups = new List<Group>();
            var cources = SchoolCourceDB.GetActiveCources(ID);
            foreach (var cource in cources)
            {
                var tempGroups = Groups.FindAll(g => g.CourceID == cource.ID);
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

        public static bool ExistGroup(SchoolCource cource)
        {
            return Groups.Find(g => g.CourceID == cource.ID) != null;
        }

        public static bool ExistGroup(SchoolCource cource, Career career)
        {
            return Groups.Find(g => g.CourceID == cource.ID && g.CareerID == career.ID) != null;
        }

        public static uint CreateGroupId()
        {
            Groups.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return Groups.Count == 0 ? 1 : Groups[Groups.Count - 1].ID + 1;
        }

        internal static void UpdateGroup(Group group)
        {
            DB.InsertOrUpdate(group);
        }
    }
}
