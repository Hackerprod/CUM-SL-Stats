using MongoDB.Driver;
using SKYNET.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SKYNET.DB
{
    public static class StudentDB
    {
        private static MongoDbCollection<Student> DB;

        public static void Initialize()
        {
            DB = new MongoDbCollection<Student>("SIGPU_Student");

            DB.CreateIndex(Builders<Student>.IndexKeys.Ascending((Student i) => i.CI));
            DB.CreateIndex(Builders<Student>.IndexKeys.Ascending((Student i) => i.Names));
            DB.CreateIndex(Builders<Student>.IndexKeys.Ascending((Student i) => i.GroupID));
            DB.CreateIndex(Builders<Student>.IndexKeys.Ascending((Student i) => i.Status));
        }

        public static bool Register(Student source)
        {
            var target = Get(source.CI);
            if (target == null)
            {
                DB.Collection.InsertOne(source);
                return true;
            }
            return false;
        }

        public static void Update(Student source)
        {
            DB.Collection.FindOneAndUpdate((Student user) => user.CI == source.CI, DB.Ub
            .Set((Student a) => a.Names, source.Names)
            .Set((Student a) => a.Sex, source.Sex)
            .Set((Student a) => a.Status, source.Status)
            .Set((Student a) => a.GroupID, source.GroupID));
        }

        public static bool Remove(Student student)
        {
            return DB.Collection.DeleteOne(s => s.CI == student.CI).DeletedCount != 0;
        }

        public static void Remove(Group group)
        {
            foreach (var student in GetStudents(group))
            {
                Remove(student);
            }
        }

        public static void Remove(SchoolCource Cource)
        {
            foreach (var student in Get(Cource))
            {
                Remove(student);
            }
        }

        public static List<Student> Get(SchoolCource Cource)
        {
            var group = GroupDB.Get(Cource);
            return GetStudents(group);
        }

        public static Student Get(ulong CI)
        {
            return DB.Collection.Find(user => user.CI == CI, null).FirstOrDefault();
        }

        public static List<Student> GetStudents(Group group)
        {
            return DB.Collection.Find(user => user.GroupID == group.ID, null).ToList();
        }

        public static List<Student> GetStudents(SchoolCource Cource)
        {
            var students = new List<Student>();
            var Groups = GroupDB.GetGroups(Cource);

            foreach (var group in Groups)
            {
                students.AddRange(GetStudents(group));
            }

            return students;
        }

        public static List<Student> GetStudents(SchoolCource Cource, Career Career)
        {
            var students = new List<Student>();
            var Groups = GroupDB.GetGroups(Cource, Career);

            foreach (var group in Groups)
            {
                students.AddRange(GetStudents(group));
            }

            return students;
        }

        public static void GetActiveStudents(SchoolCource cource, out int students)
        {
            students = 0;

            var Groups = GroupDB.GetGroups(cource);
            foreach (var group in Groups)
            {
                students += (int)DB.Collection.CountDocuments(s => s.GroupID == group.ID && s.Status == Status.Active);
            }
        }

        public static void GetEnrolledAndGraduates(SchoolCource Cource, out int Enrolleds, out int Graduates)
        {
            Enrolleds = 0;
            Graduates = 0;

            var students = GetStudents(Cource);
            Enrolleds = students.Count;
            Graduates += students.FindAll(s => s.Status == Status.Graduated).Count;

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
                var Current = SchoolCourceDB.Get(currentCource);
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
