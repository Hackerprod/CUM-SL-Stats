using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using SKYNET.Models;

namespace SKYNET.GUI.W_Controls
{
    public partial class Import_Control : UserControl
    {
        private Dictionary<int, Student> Students;
        private int Count;
        public Import_Control()
        {
            InitializeComponent();
            Students = new Dictionary<int, Student>();
            Count = 0;
        }

        public void ProcessPdfFile(string pdfFile)
        {
            LV_Students.Items.Clear();
            CH_SchoolCource.Items.Clear();
            Students.Clear();

            PdfReader reader = new PdfReader(pdfFile);
            List<string> pdfLines = new List<string>();

            string pdfContent = "";
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                pdfContent = PdfTextExtractor.GetTextFromPage(reader, page, new SimpleTextExtractionStrategy());
            }
            reader.Close();
            pdfLines = SplitLines(pdfContent);
            File.WriteAllText("d:/reporte.txt", pdfContent);
            Sex sex = Sex.Unknown;

            // Get SchoolCource ///////////////////////////////////////////////////////////

            string CourceName = "";
            var stringCources = pdfLines.FindAll(s => s.Contains("-"));
            foreach (var stringCource in stringCources)
            {
                if (frmMain.Manager.IsValidCourceName(stringCource, out string _courceName))
                {
                    CourceName = _courceName;
                }
            }

            for (int i = 0; i < frmMain.Manager.SchoolCources.Count; i++)
            {
                SchoolCource cource = frmMain.Manager.SchoolCources[i];
                CH_SchoolCource.Items.Add(cource.Name);
                CH_SchoolCource.SelectedIndex = i;
            }

            for (int i = 0; i < CH_SchoolCource.Items.Count; i++)
            {
                object item = CH_SchoolCource.Items[i];
                if (item.ToString() == CourceName)
                {
                    CH_SchoolCource.SelectedIndex = i;
                }
            }

            if (CH_SchoolCource.Text != CourceName)
            {
                CH_SchoolCource.Text = CourceName;
            }

            ///////////////////////////////////////////////////////////////////////////////

            // Get Career /////////////////////////////////////////////////////////////////

            string stringCareer = pdfLines.Find(s => s.Contains("Carrera:"));
            if (!string.IsNullOrEmpty(stringCareer))
            {
                string[] parts = stringCareer.Split(':');
                string career = parts[1].Contains(" Grupo") ? parts[1].Replace(" Grupo", "") : parts[1];

                CH_Career.Text = career;

            }

            ///////////////////////////////////////////////////////////////////////////////

            // Get Group name /////////////////////////////////////////////////////////////

            string stringGroup = pdfLines.Find(s => s.Contains("Tipo de Curso:"));
            if (!string.IsNullOrEmpty(stringGroup))
            {
                string[] parts = stringGroup.Split(new string[] { "Tipo de Curso:" }, StringSplitOptions.None);
                string Name = parts[0];
                while (Name.EndsWith(" "))
                {
                    string name = "";
                    for (int i = 0; i < Name.Length; i++)
                    {
                        if (i != Name.Length - 1)
                        {
                            name += Name[i];
                        }
                    }
                    Name = name;
                }
                CH_Group.Text = Name;
            }

            ///////////////////////////////////////////////////////////////////////////////

            //Students Count //////////////////////////////////////////////////////////////

            string studentsCount = pdfLines.Find(s => s.Contains(" Total de estudiantes:"));
            if (!string.IsNullOrEmpty(studentsCount))
            {
                string[] parts = studentsCount.Split(new string[] { " Total de estudiantes:" }, StringSplitOptions.None);
                string count = parts[0];
                int.TryParse(count, out Count);
            }
            if (Count > 0)
            {
                for (int i = 1; i < Count + 1; i++)
                {
                    string student = pdfLines.Find(s => s.EndsWith(i.ToString()));
                    if (!string.IsNullOrEmpty(student) && student.Contains(" " + i.ToString()))
                    {
                        Student Student = GetStudent(student, i);
                        if (Student == null)
                        {
                            string ProcessedLine = ProcessWrongLine(pdfLines, student);
                            Student = GetStudent(ProcessedLine, i);
                        }
                        Students.Add(i, Student);
                    }
                    else
                    {
                        string wrongStudent = pdfLines.Find(s => s == i.ToString() && s.Length == i.ToString().Length);
                        if (!string.IsNullOrEmpty(wrongStudent))
                        {
                            string ProcessedLine = ProcessWrongLine(pdfLines, wrongStudent);
                            Student Student = GetStudent(ProcessedLine, i);
                            Students.Add(i, Student);
                        }
                    }
                }
            }

            ///////////////////////////////////////////////////////////////////////////////

            int goodStudents = 0;
            foreach (var KV in Students)
            {
                Student Student = KV.Value;

                var lvItem = new ListViewItem();
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem());

                if (Student == null)
                {
                    lvItem.SubItems[0].BackColor = Color.FromArgb(255, 232, 233);
                    lvItem.SubItems[1].Text = KV.Key.ToString();
                }
                else
                {
                    lvItem.SubItems[0].Tag = Student;
                    lvItem.SubItems[0].Text = "";
                    lvItem.SubItems[1].Text = KV.Key.ToString();
                    lvItem.SubItems[2].Text = Student.CI;
                    lvItem.SubItems[3].Text = Student.Names;
                    lvItem.SubItems[4].Text = Student.Sex.ToString();
                    goodStudents++;
                }

                LV_Students.Items.Add(lvItem);
            }
            LB_Info.Text = $"Mostrando {goodStudents} de {Count} estudiantes en el archivo";
        }

        private Student GetStudent(string student, int i)
        {
            string Names = "";
            bool wrong = false;
            Sex sex = Sex.Unknown;

            if (student.Contains(" F "))
            {
                Names = student.Split(new string[] { " F " }, StringSplitOptions.None)[1];
                sex = Sex.F;
            }
            else if (student.Contains(" M "))
            {
                Names = student.Split(new string[] { " M " }, StringSplitOptions.None)[1];
                sex = Sex.M;
            }
            else
            {
                wrong = true;
            }
            string CI = student.Split(' ')[0];
            if (!long.TryParse(CI, out _))
            {
                wrong = true;
            }

            Names = Names.Replace(" " + i.ToString(), "");

            if (Names.Contains("  "))
            {
                var names = Names.Split(new string[] { "  " }, StringSplitOptions.None);
                Names = names[2] + " " + names[0] + " " + names[1];
            }
            else
            {
                wrong = true;
            }

            if (!wrong)
            {
                Student Student = new Student()
                {
                    CI = CI,
                    Names = Names.Replace("  ", " "),
                    Status = Status.Active,
                    Sex = sex
                };
                return Student;
            }
            return null;
        }

        private string ProcessWrongLine(List<string> pdfLines, string pattern)
        {
            string result = pattern;
            for (int i = 0; i < pdfLines.Count; i++)
            {
                string line = pdfLines[i];
                if (line == pattern)
                {
                    result = $"{pdfLines[i - 1]} {result}";
                    result = $"{pdfLines[i - 2]} {result}";
                    result = $"{pdfLines[i - 3]} {result}";
                }
            }
            return result;
        }

        private void BT_Import_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(CH_SchoolCource.Text))
            {
                MessageBox.Show($"Introduzca el nombre del Curso");
                return;
            }
            if (!frmMain.Manager.IsValidCourceName(CH_SchoolCource.Text, out _))
            {
                MessageBox.Show($"En nombre del Curso no es válido, el nombre tiene que seguir el siguiente formato: 2020-2021");
                return;
            }
            SchoolCource Cource = frmMain.Manager.GetCource(CH_SchoolCource.Text);
            if (Cource == null)
            {
                var Dialog = MessageBox.Show($"El Curso {CH_SchoolCource.Text} no existe" + Environment.NewLine + "Desea agregarlo?", "", MessageBoxButtons.YesNo);
                if (Dialog == DialogResult.Yes)
                {
                    Cource = new SchoolCource()
                    {
                        ID = frmMain.Manager.CreateCourceId(),
                        Name = CH_SchoolCource.Text
                    };
                    frmMain.Manager.RegisterSchoolCource(Cource);
                }
                else
                {
                    return;
                }
            }

            if (!frmMain.Manager.GetCareer(CH_Career.Text, out Career Career))
            {
                Career = new Career()
                {
                    ID = frmMain.Manager.CreateCareerId(),
                    Name = CH_Career.Text
                };
                frmMain.Manager.RegisterCareer(Career);
            }

            if (!frmMain.Manager.GetGroup(Cource, Career, CH_Group.Text, out Group Group))
            {
                Group = new Group()
                {
                    ID = frmMain.Manager.CreateGroupId(),
                    CourceID = Cource.ID,
                    CareerID = Career.ID,
                    Name = CH_Group.Text
                };
                frmMain.Manager.RegisterGroup(Group);
            }

            int registered = 0;
            bool done = false;
            foreach (var KV in Students)
            {
                Student Student = KV.Value;
                if (Student != null)
                {
                    Student.CourceID = Cource.ID;
                    Student.CareerID = Career.ID;
                    Student.GroupID = Group.ID;

                    done = frmMain.Manager.RegisterStudent(Student);
                    registered += done ? 1 : 0;
                }
            }

            modCommon.Show($"Se han importado {registered} estudiantes de {Count} en el archivo");

            if (done)
            {
                frmMain.frm.SelectTab();
            }
        }
        public static List<string> SplitLines(string content)
        {
            List<string> result = new List<string>();
            string[] lines = content.TrimEnd('\r', '\n').Split(new[] { "\\n", "\n", "\r\n" }, StringSplitOptions.None);
            foreach (var line in lines)
            {
                string _Line = line;
                while (_Line.StartsWith(" "))
                {
                    _Line = _Line.Remove(0, 1);
                }
                result.Add(_Line);
            }
            return result;
        }
    }
}
