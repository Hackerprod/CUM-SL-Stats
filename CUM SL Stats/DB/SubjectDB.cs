﻿using SKYNET.Models;
using SQLite;
using System.Collections.Generic;

namespace SKYNET.DB
{
    public static class SubjectDB
    {
        private static SQLiteDatabase DB;
        public static List<Subject> Subjects => DB.GetTables<Subject>();

        public static void Initialize(SQLiteDatabase dB)
        {
            DB = dB;

            DB.CreateTable<Subject>();
            DB.DBConnection.CreateIndex("Subject", "CourceID");
            DB.DBConnection.CreateIndex("Career", "CareerID");
        }

        public static bool RegisterSubject(Subject source)
        {
            Subject target = Subjects.Find(s => s.ID == source.ID);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            Common.Show($"La asignatura {source.Name} existe.");
            return false;
        }

        public static bool Exists(string Name)
        {
            return Subjects.Find(c => c.Name == Name) != null;
        }

        public static Subject GetSubject(string Name)
        {
            return Subjects.Find(c => c.Name == Name);
        }

        public static bool Exists(uint SubjectID)
        {
            return Subjects.Find(c => c.ID == SubjectID) != null;
        }

        public static Subject GetSubject(uint SubjectID)
        {
            return Subjects.Find(c => c.ID == SubjectID);
        }

        public static uint CreateSubjectId()
        {
            Subjects.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return Subjects.Count == 0 ? 1 : Subjects[Subjects.Count - 1].ID + 1;
        }
    }
}
