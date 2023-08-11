using Online_Platform.Commands;
using Online_Platform.Models;
using Online_Platform.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Online_Platform.ViewModels
{
    class HDAbsenteesVM : INotifyPropertyChanged
    {
        private HeadTeacherBusinessLogic headTeacherBL;
        private TeacherBusinessLogic teacherBL;
        public List<Student> Students;
        public List<Absentees> Absentees;
        public ObservableCollection<Tuple<Student, Absentees>> SA_List { get; set; }
        private int abs_count;
        public int Abs_Count
        {
            get
            {
                return abs_count;
            }
            set
            {
                abs_count = value;
                OnPropertyChanged("Abs_Count");
            }
        }

        private int n_abs_count;
        public int N_Abs_Count
        {
            get
            {
                return n_abs_count;
            }
            set
            {
                n_abs_count = value;
                OnPropertyChanged("N_Abs_Count");
            }
        }
        public HDAbsenteesVM()
        {
            headTeacherBL = new HeadTeacherBusinessLogic();
            teacherBL = new TeacherBusinessLogic();
            Students = new List<Student>();
            Absentees = new List<Absentees>();
            SA_List = new ObservableCollection<Tuple<Student, Absentees>>();
            delete_absence = new RelayCommand<System.Windows.Controls.ListBox>(Delete_Absence_Click);
            n_Absentees = new RelayCommand<HDAbsenteesVM>(Show_N_Absentes);
            all_Absentees = new RelayCommand<HDAbsenteesVM>(Show_Absentes);
            absence_Student = new RelayCommand<HDAbsenteesVM>(Absences_Student_Click);
            nAbsence_Student = new RelayCommand<HDAbsenteesVM>(NAbsences_Student_Click);
            GetStudentsFromClass();
            GetAbsenteesFromClass();
            GenerateList(Students,Absentees);

        }

        public void GetStudentsFromClass()
        {
            Students = headTeacherBL.GetStudents();
        }

        public void GetAbsenteesFromClass()
        {
            Absentees = headTeacherBL.GetAbsentees();
            Abs_Count = Absentees.Count;
            var elem = from absentee in Absentees where absentee.Is_Motivated == false select absentee;
            N_Abs_Count = elem.ToList().Count;
        }

        public void GenerateList(List<Student> std, List<Absentees> abs)
        {
            SA_List.Clear();
            foreach (var student in std)
                foreach (var absentee in abs)
                    if (student.Student_id == absentee.Student_id)
                    {
                        absentee.Absentee_Date_Str = absentee.Absentee_Date.ToString().Split(' ')[0];
                        SA_List.Add(new Tuple<Student, Absentees>(student, absentee));
                    }
        }

        private ICommand delete_absence;
        public ICommand Delete_Absence
        {
            get
            {
                return delete_absence;
            }
        }

        private void Delete_Absence_Click(System.Windows.Controls.ListBox listBox)
        {
            var elem = (listBox.SelectedItem as Tuple<Student, Absentees>).Item2;
            teacherBL.CheckAbsence(elem.Absentee_Id);
            Absentees[listBox.SelectedIndex].Is_Motivated = true;
            var elem2 = from absentee in Absentees where absentee.Is_Motivated == false select absentee;
            N_Abs_Count = elem2.ToList().Count;
            GenerateList(Students, Absentees);
        }

        private string student_name;
        public string Student_Name
        {
            get
            {
                return student_name;
            }
            set
            {
                student_name = value;
                OnPropertyChanged("Student_Name");
            }
        }

        private ICommand n_Absentees;
        public ICommand N_Absentees
        {
            get
            {
                return n_Absentees;
            }
        }

        public void Show_N_Absentes(HDAbsenteesVM obj)
        {
            var list = from elem in Absentees where elem.Is_Motivated == false select elem;
            Abs_Count = Absentees.Count;
            var elem2 = from absentee in Absentees where absentee.Is_Motivated == false select absentee;
            N_Abs_Count = elem2.ToList().Count;
            GenerateList(Students, list.ToList());
        }

        private ICommand all_Absentees;
        public ICommand All_Absentees
        {
            get
            {
                return all_Absentees;
            }
        }

        public void Show_Absentes(HDAbsenteesVM obj)
        {
            Abs_Count = Absentees.Count;
            var elem = from absentee in Absentees where absentee.Is_Motivated == false select absentee;
            N_Abs_Count = elem.ToList().Count;
            GenerateList(Students, Absentees);
        }

        private ICommand absence_Student;
        public ICommand Absence_Student
        {
            get
            {
                return absence_Student;
            }
        }

        public void Absences_Student_Click(HDAbsenteesVM obj)
        {
            var list = (from elem in Students where elem.Name.TrimEnd(' ') == Student_Name select elem).ToList();
            var absentees_list = (from elem in Absentees where (elem.Student_id == list[0].Student_id && elem.Is_Motivated == true) select elem);
            N_Abs_Count = (from elem in Absentees where (elem.Student_id == list[0].Student_id && elem.Is_Motivated == false) select elem).ToList().Count;
            Abs_Count = absentees_list.ToList().Count + n_abs_count;
            GenerateList(list, absentees_list.ToList());

        }

        private ICommand nAbsence_Student;
        public ICommand NAbsence_Student
        {
            get
            {
                return nAbsence_Student;
            }
        }

        public void NAbsences_Student_Click(HDAbsenteesVM obj)
        {
            var list = (from elem in Students where elem.Name.TrimEnd(' ') == Student_Name select elem).ToList();
            var absentees_list = (from elem in Absentees where (elem.Student_id == list[0].Student_id && elem.Is_Motivated == false) select elem);
            N_Abs_Count = absentees_list.ToList().Count;
            Abs_Count = (from elem in Absentees where elem.Student_id == list[0].Student_id select elem).ToList().Count;
            GenerateList(list, absentees_list.ToList());

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
