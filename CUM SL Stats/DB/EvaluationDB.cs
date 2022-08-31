using SKYNET.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace SKYNET.DB
{
    public static class EvaluationDB
    {
        private static SQLiteDatabase DB;
        public static List<Evaluation> Evaluations => DB.GetTables<Evaluation>();

        public static void Initialize(SQLiteDatabase dB)
        {
            DB = dB;

            DB.CreateTable<Evaluation>();
            DB.DBConnection.CreateIndex("Evaluation", "StudentID");
            DB.DBConnection.CreateIndex("Evaluation", "CareerID");
        }

        public static bool RegisterEvaluation(Evaluation ev)
        {
            var eval = Evaluations.Find(e => e.StudentID == ev.StudentID && e.CourceID == ev.CourceID && e.CareerID == ev.CareerID && e.GroupID == ev.GroupID && e.Semester == ev.Semester);
            if (eval == null)
            {
                return DB.InsertOrUpdate(ev) == 1;
            }
            else
            {
                modCommon.Show("El estudiante ya se encuentra evaluado en el semestre seleccionado");
                return false;
            }
        }

        public static bool RegisterOrUpdateEvaluation(Evaluation ev)
        {
            return DB.InsertOrUpdate(ev) == 1;
        }

        public static bool UpdateEvaluation(Evaluation ev)
        {
            return DB.InsertOrUpdate(ev) == 1;
        }

        public static List<Evaluation> GetEvaluations(SchoolCource Cource)
        {
            return Evaluations.FindAll(e => e.CourceID == Cource.ID);
        }

        public static List<Evaluation> GetEvaluations(Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.SubjectID == subject.ID);
            }
            return Evaluations.FindAll(e => e.SubjectID == subject.ID && e.Semester == semester);
        }

        public static List<Evaluation> GetEvaluations(Group group, Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.GroupID == group.ID && e.SubjectID == subject.ID);
            }
            return Evaluations.FindAll(e => e.GroupID == group.ID && e.SubjectID == subject.ID && e.Semester == semester);
        }

        public static List<Evaluation> GetEvaluations(Career career, Group group, Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID);
            }
            return Evaluations.FindAll(e => e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID && e.Semester == semester);
        }

        public static List<Evaluation> GetEvaluations(SchoolCource cource, Career career, Group group, Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID);
            }
            return Evaluations.FindAll(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.Semester == semester && e.SubjectID == subject.ID);
        }

        public static List<Evaluation> GetEvaluations(SchoolCource cource, Career career, Group group, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID);
            }
            return Evaluations.FindAll(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.Semester == semester);
        }

        public static Evaluation GetEvaluation(Student s, SchoolCource c, Career ca, Group g, Semester se, Subject su)
        {
            return Evaluations.Find(e => e.StudentID == s.CI && e.CourceID == c.ID && e.CareerID == ca.ID && e.GroupID == g.ID && e.Semester == se && e.SubjectID == su.ID);
        }

        public static uint CreateEvaluationId()
        {
            Evaluations.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return Evaluations.Count == 0 ? 1 : Evaluations[Evaluations.Count - 1].ID + 1;
        }
    }
}
