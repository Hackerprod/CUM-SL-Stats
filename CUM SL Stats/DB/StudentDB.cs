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
        private static SQLiteDatabase DB;
        public static List<Student> Students => DB.GetTables<Student>();

        public static void Initialize(SQLiteDatabase dB)
        {
            DB = dB;

            DB.CreateTable<Student>();
            DB.DBConnection.CreateIndex("Student", "Names");
            DB.DBConnection.CreateIndex("Student", "CI");
            DB.DBConnection.CreateIndex("Student", "CareerID");
        }

        public static bool RegisterStudent(Student source)
        {
            Student target = Students.Find(s => s.CI == source.CI);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            return false;
        }

        public static void UpdateStudent(Student source)
        {
            var target = Students.Find(s => s.CI == source.CI);
            target = source;
            DB.InsertOrUpdate(source);
        }

        public static bool RemoveStudent(Student student)
        {
            return DB.Delete(student) == 1;
        }

        public static List<Student> GetStudents(SchoolCource Cource, Career Career)
        {
            return Students.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID);
        }

        public static List<Student> GetStudents(SchoolCource Cource, Career Career, Group Group)
        {
            return Students.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID && c.GroupID == Group.ID);
        }

        public static void GetActiveStudents(SchoolCource cource, out int students)
        {
            students = 0;
            var cources = SchoolCourceDB.GetActiveCources(cource.ID);
            foreach (var _cource in cources)
            {
                students += Students.FindAll(s => s.CourceID == _cource.ID && s.Status == Status.Active).Count;
            }
        }

        public static List<Student> GetStudents(Group group)
        {
            return Students.FindAll(c => c.GroupID == group.ID);
        }

        public static Student GetStudent(string studentID)
        {
            return Students.Find(c => c.CI == studentID);
        }

        public static void GetEnrolledAndGraduates(SchoolCource Cource, out int Enrolleds, out int Graduates)
        {
            Enrolleds = 0;
            Graduates = 0;

            var careers = CareerDB.Careers;

            if (careers.Any())
            {
                foreach (var career in careers)
                {
                    List<Student> students = Students.FindAll(s => s.CourceID == Cource.ID && s.CareerID == career.ID && s.Status == Status.Active);
                    Enrolleds += students.Count;
                    if (students.Any())
                    {
                        Graduates += students.FindAll(s => s.Status == Status.Graduated).Count;
                    }
                }
            }
        }

        public static string GetCourceYear(SchoolCource Cource, uint currentCource)
        {
            GetCourceYear(Cource, currentCource, out int Year, out string stringYear);
            return stringYear;
        }

        public static void GetCourceYear(SchoolCource Cource, uint currentCource, out int Year, out string stringYear)
        {
            Year = 0;
            stringYear = "-";
            int currentYear = DateTime.Now.Year;

            if (currentCource != 0)
            {
                var Current = SchoolCourceDB.GetCource(currentCource);
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
        }

        public static void GetCourceEvaluations(SchoolCource cource, out uint _5Points, out uint _4Points, out uint _3Points)
        {
            _5Points = 0;
            _4Points = 0;
            _3Points = 0;

            var evaluations = EvaluationDB.GetEvaluations(cource);
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
        }
    }
}
