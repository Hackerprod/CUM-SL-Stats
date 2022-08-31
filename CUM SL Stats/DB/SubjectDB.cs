using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static List<Subject> GetSubjects(SchoolCource Cource)
        {
            if (Cource == null)
            {
                return new List<Subject>();
            }
            return Subjects.FindAll(c => c.CourceID == Cource.ID);
        }

        public static bool GetSubject(string Name, uint courceID, uint careerID, Semester Semester, out Subject subject)
        {
            subject = Subjects.Find(c => c.Name == Name && c.CourceID == courceID && c.CareerID == careerID && c.Semester == Semester);
            return subject != null;
        }

        public static Subject GetSubject(uint subjectID, uint courceID, uint careerID, Semester Semester)
        {
            return Subjects.Find(c => c.ID == subjectID && c.CourceID == courceID && c.CareerID == careerID && c.Semester == Semester);
        }

        public static bool GetSubject(uint courceID, uint careerID, Semester Semester, out Subject subject)
        {
            subject = Subjects.Find(c => c.CourceID == courceID && c.CareerID == careerID && c.Semester == Semester);
            return subject != null;
        }

        public static bool GetSubject(string Name, uint courceID, uint careerID, out Subject subject)
        {
            subject = Subjects.Find(c => c.Name == Name && c.CourceID == courceID && c.CareerID == careerID);
            return subject != null;
        }

        public static List<Subject> GetSubjects(SchoolCource Cource, Career Career)
        {
            return Subjects.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID);
        }

        public static List<Subject> GetSubjects(SchoolCource Cource, Semester Semester)
        {
            return Subjects.FindAll(c => c.CourceID == Cource.ID && c.Semester == Semester);
        }

        public static List<Subject> GetSubjects(SchoolCource Cource, Career Career, Semester Semester)
        {
            if (Semester == Semester.Both)
            {
                return Subjects.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID);
            }
            return Subjects.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID && c.Semester == Semester);
        }

        public static uint CreateSubjectId()
        {
            Subjects.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return Subjects.Count == 0 ? 1 : Subjects[Subjects.Count - 1].ID + 1;
        }
    }
}
