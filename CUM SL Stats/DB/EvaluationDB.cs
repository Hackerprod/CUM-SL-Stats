using MongoDB.Driver;
using SKYNET.Models;
using System.Collections.Generic;
using System.Linq;

namespace SKYNET.DB
{
    public static class EvaluationDB
    {
        private static MongoDbCollection<Evaluation> DB;

        public static void Initialize()
        {
            DB = new MongoDbCollection<Evaluation>("SIGPU_Evaluation");

            DB.CreateIndex(Builders<Evaluation>.IndexKeys.Ascending((Evaluation i) => i.StudentID));
            DB.CreateIndex(Builders<Evaluation>.IndexKeys.Ascending((Evaluation i) => i.CareerID));
        }

        public static bool Register(Evaluation source)
        {
            var target = DB.Collection.Find((Evaluation e) => e.StudentID == source.StudentID && e.CourceID == source.CourceID && e.CareerID == source.CareerID && e.GroupID == source.GroupID && e.Semester == source.Semester, null).FirstOrDefault();
            if (target == null)
            {

                source.ID = CreateID();
                DB.Collection.InsertOne(source);
                return true;
            }
            else
            {
                Common.Show("El estudiante ya se encuentra evaluado en el semestre seleccionado");
                return false;
            }
        }

        public static bool RegisterOrUpdate(Evaluation source)
        {
            var target = Get(source.ID);
            if (target == null)
            {
                return Register(source);
            }
            else
            { 
                return Update(source);
            }
        }

        public static bool Update(Evaluation source)
        {
            if (Exist(source))
            {
                DB.Collection.FindOneAndUpdate((Evaluation e) => e.ID == source.ID, DB.Ub
                .Set((Evaluation e) => e.GroupID, source.GroupID)
                .Set((Evaluation e) => e.CareerID, source.CareerID)
                .Set((Evaluation e) => e.CourceID, source.CourceID)
                .Set((Evaluation e) => e.Points, source.Points)
                .Set((Evaluation e) => e.Semester, source.Semester)
                .Set((Evaluation e) => e.StudentID, source.StudentID)
                .Set((Evaluation e) => e.SubjectID, source.SubjectID));
                return true;
            }
            return false;
        }

        public static bool Exist(Evaluation source)
        {
            return Get(source.ID) != null;
        }

        public static List<Evaluation> GetEvaluations(SchoolCource Cource)
        {
            return DB.Collection.Find(e => e.CourceID == Cource.ID).ToList();
        }

        public static List<Evaluation> GetEvaluations(Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return DB.Collection.Find(e => e.SubjectID == subject.ID).ToList();
            }
            return DB.Collection.Find(e => e.SubjectID == subject.ID && e.Semester == semester).ToList();
        }

        public static List<Evaluation> GetEvaluations(Group group, Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return DB.Collection.Find(e => e.GroupID == group.ID && e.SubjectID == subject.ID).ToList();
            }
            return DB.Collection.Find(e => e.GroupID == group.ID && e.SubjectID == subject.ID && e.Semester == semester).ToList();
        }

        public static List<Evaluation> GetEvaluations(Career career, Group group, Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return DB.Collection.Find(e => e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID).ToList();
            }
            return DB.Collection.Find(e => e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID && e.Semester == semester).ToList();
        }

        public static List<Evaluation> GetEvaluations(SchoolCource cource, Career career, Group group, Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return DB.Collection.Find(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID).ToList();
            }
            return DB.Collection.Find(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.Semester == semester && e.SubjectID == subject.ID).ToList();
        }

        public static List<Evaluation> GetEvaluations(SchoolCource cource, Career career, Group group, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return DB.Collection.Find(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID).ToList();
            }
            return DB.Collection.Find(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.Semester == semester).ToList();
        }

        public static Evaluation GetEvaluation(Student s, SchoolCource c, Career ca, Group g, Semester se, Subject su)
        {
            return DB.Collection.Find(e => e.StudentID == s.CI && e.CourceID == c.ID && e.CareerID == ca.ID && e.GroupID == g.ID && e.Semester == se && e.SubjectID == su.ID).FirstOrDefault();
        }

        public static Evaluation Get(uint ID)
        {
            return DB.Collection.Find((Evaluation e) => e.ID == ID, null).FirstOrDefault();
        }

        public static uint CreateID()
        {
            uint ID = DB.Collection.Find(FilterDefinition<Evaluation>.Empty, null).SortByDescending((Evaluation u) => (object)u.ID).Project((Evaluation u) => u.ID).FirstOrDefault();
            return ID <= 0U ? 1 : ID + 1;
        }
    }
}
