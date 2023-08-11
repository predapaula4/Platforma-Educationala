using Online_Platform.Commands;
using Online_Platform.Models;
using Online_Platform.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Online_Platform.ViewModels
{
    class TeacherAbsenteesVM : INotifyPropertyChanged
    {
        TeacherBusinessLogic teacherBL;
        public ObservableCollection<Absentees> Absentees_List { get; set; }
        public TeacherAbsenteesVM()
        {
            teacherBL = new TeacherBusinessLogic();
            button_clicked = new RelayCommand<TeacherVM>(OnButtonClick);
            add_absence = new RelayCommand<TeacherVM>(Add_Absence_Click);
            delete_absence = new RelayCommand<System.Windows.Controls.ListBox>(Delete_Absence_Click);
            Absentees_List = new ObservableCollection<Absentees>();
            visibility = Visibility.Hidden;
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

        private string subject_name;
        public string Subject_Name
        {
            get
            {
                return subject_name;
            }
            set
            {
                subject_name = value;
                OnPropertyChanged("Subject_Name");
            }
        }

        private int semester;
        public int Semester
        {
            get
            {
                return semester;
            }
            set
            {
                semester = value;
                OnPropertyChanged("Semester");
            }
        }


        private Visibility visibility;
        public Visibility Visibility
        {
            get
            {
                return visibility;
            }
            set
            {
                visibility = value;
                OnPropertyChanged("Visibility");
            }
        }

        private DateTime absence_date;
        public DateTime Absence_Date
        {
            get
            {
                return absence_date;
            }
            set
            {
                absence_date = value;
                OnPropertyChanged("Absence_Date");
            }
        }

        private int absence_semester;
        public int Absence_Semester
        {
            get
            {
                return absence_semester;
            }
            set
            {
                absence_semester = value;
                OnPropertyChanged("Absence_Semester");
            }
        }


        private ICommand button_clicked;
        public ICommand Button_Clicked
        {
            get
            {
                return button_clicked;
            }
        }

        private void OnButtonClick(TeacherVM teacherVM)
        {
            if (!Check_Inputs())
                return;
            var result = teacherBL.GetAbsences(student_name, subject_name, semester);
            Visibility = Visibility.Visible;
            Absentees_List.Clear();
            foreach (var absentee in result)
            {
                absentee.Absentee_Date_Str = absentee.Absentee_Date.ToString().Split(' ')[0];
                if (absentee.Semester == Semester)
                    Absentees_List.Add(absentee);

            }
        }


        private ICommand add_absence;
        public ICommand Add_Absence
        {
            get
            {
                return add_absence;
            }
        }

        private void Add_Absence_Click(TeacherVM teacherVM)
        {
            teacherBL.AddAbsence(Student_Name, Subject_Name, Absence_Semester, Absence_Date);
            OnButtonClick(teacherVM);
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
            var elem = listBox.SelectedItem as Absentees;
            teacherBL.CheckAbsence(elem.Absentee_Id);
            Absentees_List[listBox.SelectedIndex].Is_Motivated = true;
        }

        private bool Check_Inputs()
        {
            if (student_name == null)
            {
                MessageBox.Show("Numele studentului trebuie completat");
                return false;
            }
            if (subject_name == null)
            {
                MessageBox.Show("Numele subiectului trebuie completat");
                return false;
            }
            if (semester == 0)
            {
                MessageBox.Show("Semestrul trebuie completat");
                return false;
            }
            return true;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
