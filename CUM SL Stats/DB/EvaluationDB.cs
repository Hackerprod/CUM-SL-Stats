using SKYNET.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class EvaluationDB
    {
        private static SQLiteAsyncConnection DB;
        private static AsyncTableQuery<Evaluation> Table;

        public async static Task Initialize(SQLiteAsyncConnection dB)
        {
            DB = dB;

            await DB.CreateTableAsync<Evaluation>();
            Table = DB.Table<Evaluation>();
        }

        public static async Task<bool> Register(Evaluation ev)
        {
            var eval = await Table.Where(e => e.StudentID == ev.StudentID && e.CourceID == ev.CourceID && e.CareerID == ev.CareerID && e.GroupID == ev.GroupID && e.Semester == ev.Semester).FirstOrDefaultAsync();
            if (eval == null)
            {
                return await DB.InsertOrReplaceAsync(ev) == 1;
            }
            else
            {
                Common.Show("El estudiante ya se encuentra evaluado en el semestre seleccionado");
                return false;
            }
        }

        public static async Task<bool> RegisterOrUpdate(Evaluation ev)
        {
            return await DB.InsertOrReplaceAsync(ev) == 1;
        }

        public static async Task<bool> Update(Evaluation ev)
        {
            return await DB.InsertOrReplaceAsync(ev) == 1;
        }

        public static async Task<List<Evaluation>> Get()
        {
            return await Table.ToListAsync();
        }

        public static async Task<List<Evaluation>> Get(SchoolCource Cource)
        {
            return await Table.Where(e => e.CourceID == Cource.ID).ToListAsync();
        }

        public static async Task<List<Evaluation>> Get(Subject subject, Semester semester)
        {
            return await Table.Where(e => e.SubjectID == subject.ID && e.Semester == semester).ToListAsync();
        }

        public static async Task<List<Evaluation>> Get(Group group, Subject subject, Semester semester)
        {
            return await Table.Where(e => e.GroupID == group.ID && e.SubjectID == subject.ID && e.Semester == semester).ToListAsync();
        }

        public static async Task<List<Evaluation>> Get(Career career, Group group, Subject subject, Semester semester)
        {
            return await Table.Where(e => e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID && e.Semester == semester).ToListAsync();
        }

        public static async Task<List<Evaluation>> Get(SchoolCource cource, Career career, Group group, Subject subject, Semester semester)
        {
            return await Table.Where(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.Semester == semester && e.SubjectID == subject.ID).ToListAsync();
        }

        public static async Task<List<Evaluation>> Get(SchoolCource cource, Career career, Group group, Semester semester)
        {
            return await Table.Where(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.Semester == semester).ToListAsync();
        }

        public static async Task<Evaluation> Get(Student s, SchoolCource c, Career ca, Group g, Semester se, Subject su)
        {
            return await Table.Where(e => e.StudentID == s.CI && e.CourceID == c.ID && e.CareerID == ca.ID && e.GroupID == g.ID && e.Semester == se && e.SubjectID == su.ID).FirstOrDefaultAsync();
        }
    }
}