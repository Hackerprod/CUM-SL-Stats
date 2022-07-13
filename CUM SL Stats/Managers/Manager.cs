using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKYNET.Models;
using SQLite;

namespace SKYNET.Managers
{
    public class DBManager
    {
        private SQLiteDatabase DB;

        public List<Career> Careers => DB.GetTables<Career>();
        public List<SchoolCource> SchoolCources => DB.GetTables<SchoolCource>();
        public List<Evaluation> Evaluations => DB.GetTables<Evaluation>();
        public List<Student> Students => DB.GetTables<Student>();
        public List<Subject> Subjects => DB.GetTables<Subject>();
        public List<Group> Groups => DB.GetTables<Group>();

        public DBManager(SQLiteDatabase dB)
        {
            this.DB = dB;
        }

        public void Initialize()
        {
            DB.CreateTable<Career>();
            DB.CreateTable<SchoolCource>();
            DB.CreateTable<Evaluation>();
            DB.CreateTable<Student>();
            DB.CreateTable<Subject>();
            DB.CreateTable<Group>();

            DB.DBConnection.CreateIndex("Career", "ID");
            DB.DBConnection.CreateIndex("Career", "Name");
            DB.DBConnection.CreateIndex("Career", "CourceID");

            DB.DBConnection.CreateIndex("SchoolCource", "ID");
            DB.DBConnection.CreateIndex("SchoolCource", "Name");

            DB.DBConnection.CreateIndex("Evaluation", "StudentID");
            DB.DBConnection.CreateIndex("Evaluation", "CareerID");

            DB.DBConnection.CreateIndex("Student", "Names");
            DB.DBConnection.CreateIndex("Student", "CI");
            DB.DBConnection.CreateIndex("Student", "CareerID");

            DB.DBConnection.CreateIndex("Subject", "CourceID");
            DB.DBConnection.CreateIndex("Career", "CareerID");

            DB.DBConnection.CreateIndex("Group", "Name");
            DB.DBConnection.CreateIndex("Group", "CourceID");
            DB.DBConnection.CreateIndex("Group", "CareerID");
        }

        #region SchoolCource
        /// SchoolCource //////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RegisterSchoolCource(SchoolCource source)
        {
            SchoolCource target = SchoolCources.Find(s => s.Name == source.Name);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            modCommon.Show($"El curso {source.Name} existe.");
            return false;
        }

        

        public SchoolCource GetCource(uint ID)
        {
            return SchoolCources.Find(s => s.ID == ID);
        }
        public SchoolCource GetCource(string Name)
        {
            return SchoolCources.Find(s => s.Name == Name);
        }
        public bool GetCource(string Name, out SchoolCource cource)
        {
            cource = SchoolCources.Find(s => s.Name == Name);
            return cource != null; ;
        }
        public List<SchoolCource> GetActiveCources(uint iD)
        {
            var cources = new List<SchoolCource>();
            var cource = GetCource(iD);

            int minYear = 0;
            int maxYear = 0;

            cources.Add(cource);

            if (string.IsNullOrEmpty(cource.Name) && !cource.Name.Contains("-"))
            {
                return cources;
            }

            var years = cource.Name.Split('-');
            if (!int.TryParse(years[0], out minYear) && !int.TryParse(years[1], out maxYear))
            {
                return cources;
            }

            for (int i = 1; i < 5; i++)
            {
                var tempName = $"{(minYear - i)}-{((minYear - i) + 1)}";
                var tempCource = GetCource(tempName);
                if (tempCource != null)
                {
                    cources.Add(tempCource);
                }
            }
            return cources;
        }

        public bool RemoveCource(SchoolCource cource)
        {
            if (DB.Delete(cource) == 1)
            {
                var groups = Groups.FindAll(g => g.CourceID == cource.ID);
                foreach (var group in groups)
                {
                    DB.Delete(group);
                }

                var students = Students.FindAll(g => g.CourceID == cource.ID);
                foreach (var student in students)
                {
                    DB.Delete(student);
                }

                return true;
            }
            return false;
        }

        public bool IsValidCourceName(string stringCource, out string CourceName)
        {
            CourceName = "";
            if (!string.IsNullOrEmpty(stringCource) && stringCource.Contains("-"))
            {
                var years = stringCource.Split('-');
                if (int.TryParse(years[0], out int Year1) && int.TryParse(years[1], out int Year2))
                {
                    CourceName = years[0] + "-" + years[1];
                    return Year1 + 1 == Year2;
                }
            }
            return false;
        }
        public List<string> GetYears(SchoolCource cource, Career career)
        {
            List<string> Years = new List<string>();
            var Cources = GetActiveCources(cource.ID); 

            foreach (var Cource in Cources)
            {
                if (ExistGroup(Cource, career))
                {
                    var name = GetCourceYear(Cource, (uint)frmMain.Settings.CurrentCource);
                    Years.Add(name);
                }
            }
            return Years;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Careers
        /// Careers ///////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RegisterCareer(Career source)
        {
            Career target = Careers.Find(s => s.Name == source.Name);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            modCommon.Show($"La carrera {source.Name} existe.");
            return false;
        }
        public Career GetCareer(uint ID)
        {
            return Careers.Find(s => s.ID == ID);
        }
        public Career GetCareer(string Name)
        {
            return Careers.Find(s => s.Name == Name);
        }
        public bool GetCareer(string Name, out Career career)
        {
            career = GetCareer(Name);
            return career != null;
        }

        public List<Career> GetCareers(SchoolCource cource)
        {
            var careers = new List<Career>();
            var allgroups = GetActiveGroups(cource.ID);
            var groups = new List<Group>();

            foreach (var group in allgroups)
            {
                var current = groups.Find(g => g.CourceID == group.CourceID && g.CareerID == group.CareerID);
                if (current == null)
                {
                    groups.Add(group);
                }
            }

            foreach (var group in groups)
            {
                var Career = GetCareer(group.CareerID);
                if (Career != null && careers.Find(c => c.ID == Career.ID || c.Name == Career.Name) == null)
                {
                    careers.Add(Career);
                }
            }
            return careers;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Groups
        /// Groups ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RegisterGroup(Group source)
        {
            Group target = Groups.Find(s => s.Name == source.Name);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            return false;
        }
        public Group GetGroup(string Name)
        {
            return Groups.Find(g => g.Name == Name);
        }
        public Group GetGroup(uint ID)
        {
            return Groups.Find(g => g.ID == ID);
        }
        public Group GetGroup(string Name, SchoolCource cource, Career career)
        {
            return Groups.Find(g => g.Name == Name && g.CourceID == cource.ID && g.CareerID == career.ID);
        }
        public List<Group> GetGroups(SchoolCource cource, Career career)
        {
            return Groups.FindAll(g => g.CourceID == cource.ID && g.CareerID == career.ID);
        }
        public bool GetGroup(SchoolCource cource, Career career, string Name, out Group group)
        {
            group = Groups.Find(g => g.CourceID == cource.ID && g.CareerID == career.ID && g.Name == Name);
            return group != null;
        }
        public List<Group> GetActiveGroups(uint ID)
        {
            var groups = new List<Group>();
            var cources = GetActiveCources(ID);
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
        private bool ExistGroup(SchoolCource cource)
        {
            return Groups.Find(g => g.CourceID == cource.ID) != null;
        }
        private bool ExistGroup(SchoolCource cource, Career career)
        {
            return Groups.Find(g => g.CourceID == cource.ID && g.CareerID == career.ID) != null;
        }
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Students
        /// Students //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RegisterStudent(Student source)
        {
            Student target = Students.Find(s => s.CI == source.CI);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            return false;
        }
        public void UpdateStudent(Student source)
        {
            var target = Students.Find(s => s.CI == source.CI);
            target = source;
            DB.InsertOrUpdate(source);
        }
        public bool RemoveStudent(Student student)
        {
            return DB.Delete(student) == 1;
        }
        public List<Student> GetStudents(SchoolCource Cource, Career Career)
        {
            return Students.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID);
        }
        public List<Student> GetStudents(SchoolCource Cource, Career Career, Group Group)
        {
            return Students.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID && c.GroupID == Group.ID);
        }

        public void GetActiveStudents(SchoolCource cource, out int students)
        {
            students = 0;
            var cources = GetActiveCources(cource.ID);
            foreach (var _cource in cources)
            {
                students += Students.FindAll(s => s.CourceID == _cource.ID && s.Status == Status.Active).Count;
            }
        }

        public List<Student> GetStudents(Group group)
        {
            return Students.FindAll(c => c.GroupID == group.ID);
        }
        public Student GetStudent(string studentID)
        {
            return Students.Find(c => c.CI == studentID);
        }
        public void GetEnrolledAndGraduates(SchoolCource Cource, out int Enrolleds, out int Graduates)
        {
            Enrolleds = 0;
            Graduates = 0;

            var careers = Careers;

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
        public string GetCourceYear(SchoolCource Cource, uint currentCource)
        {
            GetCourceYear(Cource, currentCource, out int Year, out string stringYear);
            return stringYear;
        }

        public void GetCourceYear(SchoolCource Cource, uint currentCource, out int Year, out string stringYear)
        {
            Year = 0;
            stringYear = "-";
            int currentYear = DateTime.Now.Year;

            if (currentCource != 0)
            {
                var Current = GetCource(currentCource);
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

        public void GetCourceEvaluations(SchoolCource cource, out uint _5Points, out uint _4Points, out uint _3Points)
        {
            _5Points = 0;
            _4Points = 0;
            _3Points = 0;

            var evaluations = GetEvaluations(cource);
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

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Subjects
        /// Subjects //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RegisterSubject(Subject source)
        {
            Subject target = Subjects.Find(s => s.ID == source.ID);
            if (target == null)
            {
                DB.InsertOrUpdate(source);
                return true;
            }
            modCommon.Show($"La asignatura {source.Name} existe.");
            return false;
        }
        public List<Subject> GetSubjects(SchoolCource Cource)
        {
            if (Cource == null)
            {
                return new List<Subject>();
            }
            return Subjects.FindAll(c => c.CourceID == Cource.ID);
        }
        public bool GetSubject(string Name, uint courceID, uint careerID, Semester Semester, out Subject subject)
        {
            subject = Subjects.Find(c => c.Name == Name && c.CourceID == courceID && c.CareerID == careerID && c.Semester == Semester);
            return subject != null;
        }
        public Subject GetSubject(uint subjectID, uint courceID, uint careerID, Semester Semester)
        {
            return Subjects.Find(c => c.ID == subjectID && c.CourceID == courceID && c.CareerID == careerID && c.Semester == Semester);
        }
        public bool GetSubject(uint courceID, uint careerID, Semester Semester, out Subject subject)
        {
            subject = Subjects.Find(c => c.CourceID == courceID && c.CareerID == careerID && c.Semester == Semester);
            return subject != null;
        }
        public bool GetSubject(string Name, uint courceID, uint careerID, out Subject subject)
        {
            subject = Subjects.Find(c => c.Name == Name && c.CourceID == courceID && c.CareerID == careerID);
            return subject != null;
        }

        public List<Subject> GetSubjects(SchoolCource Cource, Career Career)
        {
            return Subjects.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID);
        }
        public List<Subject> GetSubjects(SchoolCource Cource, Semester Semester)
        {
            return Subjects.FindAll(c => c.CourceID == Cource.ID && c.Semester == Semester);
        }
        public List<Subject> GetSubjects(SchoolCource Cource, Career Career, Semester Semester)
        {
            if (Semester == Semester.Both)
            {
                return Subjects.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID);
            }
            return Subjects.FindAll(c => c.CourceID == Cource.ID && c.CareerID == Career.ID && c.Semester == Semester);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Evaluations
        /// Evaluations ///////////////////////////////////////////////////////////////////////////////////////////////////////////

        public bool RegisterEvaluation(Evaluation ev)
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
        public bool RegisterOrUpdateEvaluation(Evaluation ev)
        {
            return DB.InsertOrUpdate(ev) == 1;
        }
        public bool UpdateEvaluation(Evaluation ev)
        {
            return DB.InsertOrUpdate(ev) == 1;
        }
        public List<Evaluation> GetEvaluations(SchoolCource Cource)
        {
            return Evaluations.FindAll(e => e.CourceID == Cource.ID);
        }
        public List<Evaluation> GetEvaluations(Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.SubjectID == subject.ID);
            }
            return Evaluations.FindAll(e => e.SubjectID == subject.ID && e.Semester == semester);
        }
        public List<Evaluation> GetEvaluations(Group group, Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.GroupID == group.ID && e.SubjectID == subject.ID);
            }
            return Evaluations.FindAll(e => e.GroupID == group.ID && e.SubjectID == subject.ID && e.Semester == semester);
        }
        public List<Evaluation> GetEvaluations(Career career, Group group, Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID);
            }
            return Evaluations.FindAll(e => e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID && e.Semester == semester);
        }
        public List<Evaluation> GetEvaluations(SchoolCource cource, Career career, Group group, Subject subject, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.SubjectID == subject.ID);
            }
            return Evaluations.FindAll(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.Semester == semester && e.SubjectID == subject.ID);
        }
        public List<Evaluation> GetEvaluations(SchoolCource cource, Career career, Group group, Semester semester)
        {
            if (semester == Semester.Both)
            {
                return Evaluations.FindAll(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID);
            }
            return Evaluations.FindAll(e => e.CourceID == cource.ID && e.CareerID == career.ID && e.GroupID == group.ID && e.Semester == semester);
        }
        public Evaluation GetEvaluation(Student s, SchoolCource c, Career ca, Group g, Semester se, Subject su)
        {
            return Evaluations.Find(e => e.StudentID == s.CI && e.CourceID == c.ID && e.CareerID == ca.ID && e.GroupID == g.ID && e.Semester == se && e.SubjectID == su.ID);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        #endregion

        #region Create IDs
        public uint CreateCourceId()
        {
            SchoolCources.Sort((s1, s2) => s1.ID.CompareTo(s2.ID));
            return (SchoolCources.Any() && SchoolCources[0].ID <= 0U) ? 1 : SchoolCources[SchoolCources.Count - 1].ID + 1;
        }
        public uint CreateEvaluationId()
        {
            Evaluations.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return (Evaluations.Any() && Evaluations[0].ID <= 0U) ? 1 : Evaluations[Evaluations.Count - 1].ID + 1;
        }
        internal uint CreateSubjectId()
        {
            Subjects.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return (Subjects.Any() && Subjects[0].ID <= 0U) ? 1 : Subjects[Subjects.Count - 1].ID + 1;
        }
        internal uint CreateGroupId()
        {
            Groups.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return (Groups.Any() && Groups[0].ID <= 0U) ? 1 : Groups[Groups.Count - 1].ID + 1;
        }
        internal uint CreateCareerId()
        {
            Careers.Sort((s1, s2) => s2.ID.CompareTo(s1.ID));
            return (Careers.Any() && Careers[0].ID <= 0U) ? 1 : Careers[Careers.Count - 1].ID + 1;
        }
        #endregion

    }
}
