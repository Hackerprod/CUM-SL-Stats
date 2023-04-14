using SKYNET.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKYNET.DB
{
    public static class StudentDB
    {
        private static SQLiteAsyncConnection DB;
        private static AsyncTableQuery<Student> Table;

        public async static Task Initialize(SQLiteAsyncConnection dB)
        {
            DB = dB;

            await DB.CreateTableAsync<Student>();
            Table = DB.Table<Student>();
        }

        public static async Task<bool> Register(Student source)
        {
            Student target = await Get(source.CI);
            if (target == null)
            {
                await DB.InsertOrReplaceAsync(source);
                return true;
            }
            return false;
        }

        public static async void Update(Student source)
        {
            var target = await Get(source.CI);
            target = source;
            await DB.InsertOrReplaceAsync(source);
        }

        public static async Task<List<Student>> Get()
        {
            return await Table.ToListAsync();
        }

        public static async Task<bool> Remove(Student student)
        {
            return await DB.DeleteAsync(student) == 1;
        }

        public static async Task Remove(Group group)
        {
            var students = await Get(group);
            foreach (var student in students)
            {
                await DB.DeleteAsync(student);
            }
        }

        public static async void Remove(SchoolCource Cource)
        {
            foreach (var group in await GroupDB.Get(Cource))
            {
                foreach (var student in await Table.Where(s => s.GroupID == group.ID).ToListAsync())
                {
                    await DB.DeleteAsync(student);
                }
            }
        }

        public static async Task<List<Student>> Get(SchoolCource Cource)
        {
            var students = new List<Student>();
            var Groups = await GroupDB.Get(Cource);

            foreach (var group in Groups)
            {
                students.AddRange(await Get(group));
            }

            return students;
        }

        public static async Task<List<Student>> Get(SchoolCource Cource, Career Career)
        {
            var students = new List<Student>();
            var Groups = await GroupDB.Get(Cource, Career);

            foreach (var group in Groups)
            {
                students.AddRange(await Get(group));
            }

            return students;
        }

        public static async Task<int> GetActiveStudents(SchoolCource cource)
        {
            var students = 0;

            var Groups = await GroupDB.Get(cource);
            for (int i = 0; i < Groups.Count; i++)
            {
                Group group = Groups[i];
                students += (await Table.Where(s => s.GroupID == group.ID && s.Status == Status.Active).ToListAsync()).Count;
            }
            return students;
        }

        public static async Task<List<Student>> Get(Group group)
        {
            return await Table.Where(c => c.GroupID == group.ID).ToListAsync();
        }

        public static async Task<Student> Get(string studentID)
        {
            return await Table.Where(c => c.CI == studentID).FirstOrDefaultAsync();
        }

        public static async Task<Tuple<int, int>> GetEnrolledAndGraduates(SchoolCource Cource)
        {
            var Enrolleds = 0;
            var Graduates = 0;

            var students = await Get(Cource);
            Enrolleds = students.Count;
            Graduates += (await Table.Where(s => s.Status == Status.Graduated).ToListAsync()).Count;

            return Tuple.Create<int, int>(Enrolleds,Graduates);
        }

        public static async Task<string> GetCourceYear(SchoolCource Cource, uint currentCource)
        {
            var format = await GetCourceYearFormats(Cource, currentCource);
            return format.Item2;
        }

        public static async Task<Tuple<int, string>> GetCourceYearFormats(SchoolCource Cource, uint currentCource)
        {
            var Year = 0;
            var stringYear = "-";
            int currentYear = DateTime.Now.Year;

            if (currentCource != 0)
            {
                var Current = await SchoolCourceDB.Get(currentCource);
                if (Current != null && Current.Name.Contains("-"))
                {
                    var parts = Current.Name.Split('-');
                    int.TryParse(parts[0], out int firstYear);
                    int.TryParse(parts[1], out int secondYear);
                    currentYear = secondYear;
                }
            }

            if (Cource != null && Cource.Name.Contains("-"))
            {
                var parts = Cource.Name.Split('-');
                int.TryParse(parts[0], out int firstYear);
                int.TryParse(parts[1], out int secondYear);
                if (currentYear > firstYear)
                {
                    Year = currentYear - firstYear;
                    switch (Year)
                    {
                        case 1: stringYear = "1ro"; break;
                        case 2: stringYear = "2do"; break;
                        case 3: stringYear = "3ro"; break;
                        case 4: stringYear = "4to"; break;
                        case 5: stringYear = "5to"; break;
                        default:
                            Year = 0;
                            stringYear = "-";
                            break;
                    }
                }
            }

            return Tuple.Create<int, string>(Year, stringYear);
        }

        public static async Task<Tuple<int, int, int>> GetCourceEvaluations(SchoolCource cource)
        {
            var _5Points = 0;
            var _4Points = 0;
            var _3Points = 0;

            var evaluations = await EvaluationDB.Get(cource);
            foreach (var evaluation in evaluations)
            {
                if (float.TryParse(evaluation.Points, out float Points))
                {
                    if (Points >= 3 && Points < 4)
                    {
                        _3Points++;
                    }
                    else if (Points >= 4 && Points < 5)
                    {
                        _4Points++;
                    }
                    else if (Points == 5)
                    {
                        _5Points++;
                    }
                }
            }
            return Tuple.Create<int, int, int>(_5Points, _4Points, _3Points); 
        }
    }
}