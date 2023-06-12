using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class SubjectDB
    {
        private static SQLiteAsyncConnection DB;
        private static AsyncTableQuery<Subject> Table;
        public static event EventHandler<Subject> OnSubjectRemoved;
        public static event EventHandler<Subject> OnSubjectAdded;

        public async static Task Initialize(SQLiteAsyncConnection dB)
        {
            DB = dB;
            await DB.CreateTableAsync<Subject>();
            Table = DB.Table<Subject>();
        }

        public static async Task<bool> Register(Subject source)
        {
            try
            {
                await DB.InsertAsync(source);
                OnSubjectAdded?.Invoke(null, source);
                return true;
            }
            catch (System.Exception)
            {
                Common.Show($"Error agregando la asignatura {source.Name}.");
                return false;
            }
        }

        public static async Task<List<Subject>> Get()
        {
            return await Table.ToListAsync();
        }

        public static async Task<Subject> Get(string Name)
        {
            return await Table.Where(c => c.Name == Name).FirstOrDefaultAsync();
        }

        public static async Task<Subject> Get(uint subjectID)
        {
            return await Table.Where(c => c.ID == subjectID).FirstOrDefaultAsync();
        }

        public static async Task<bool> Exists(uint subjectID)
        {
            return await Get(subjectID) != null;
        }

        public static async Task<bool> Exists(string Name)
        {
            return await Table.Where(c => c.Name == Name).FirstOrDefaultAsync() != null;
        }

        internal async static void Update(Subject subject)
        {
            try
            {
                await DB.UpdateAsync(subject);
            }
            catch (System.Exception)
            {
                Common.Show($"Error actualizando la asignatura {subject.Name}.");
            }
        }

        internal async static void Remove(Subject subject)
        {
            try
            {
                await DB.DeleteAsync(subject);
                OnSubjectRemoved?.Invoke(null, subject);
            }
            catch (System.Exception)
            {
                Common.Show($"Error eliminando la asignatura {subject.Name}.");
            }
        }

        //public static uint CreateID()
        //{
        //    Task<Subject>s.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
        //    return Task<Subject>s.Count == 0 ? 1 : Task<Subject>s[Task<Subject>s.Count - 1].ID + 1;
        //}
    }
}