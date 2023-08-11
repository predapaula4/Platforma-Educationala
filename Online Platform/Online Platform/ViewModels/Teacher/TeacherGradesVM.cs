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
    class TeacherGradesVM: INotifyPropertyChanged
    {
        TeacherBusinessLogic teacherBL;
        public ObservableCollection<Mark> Marks_List { get; set; }
        public TeacherGradesVM()
        {
            teacherBL = new TeacherBusinessLogic();
            button_clicked = new RelayCommand<TeacherVM>(OnButtonClick);
            add_grade = new RelayCommand<TeacherVM>(Add_Grade_Click);
            delete_grade = new RelayCommand<System.Windows.Controls.ListBox>(Delete_Grade_Click);
            final_grade = new RelayCommand<TeacherGradesVM>(Final_Grade_Click);
            Marks_List = new ObservableCollection<Mark>();
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

        private int grade_value;
        public int Grade_Value
        {
            get
            {
                return grade_value;
            }
            set
            {
                grade_value = value;
                OnPropertyChanged("Grade_Value");
            }
        }

        private int grade_semester;
        public int Grade_Semester
        {
            get
            {
                return grade_semester;
            }
            set
            {
                grade_semester = value;
                OnPropertyChanged("Grade_Semester");
            }
        }

        private bool isThesisMark;
        public bool IsThesisMark
        {
            get
            {
                return isThesisMark;
            }
            set
            {
                isThesisMark = value;
                OnPropertyChanged("IsThesisMark");
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
            var result = teacherBL.GetGrades(student_name, subject_name, semester);
            Visibility = Visibility.Visible;
            Marks_List.Clear();
            foreach (var mark in result)
            {   
                if(mark.Semester == semester)
                Marks_List.Add(mark);
            }
        }


        private ICommand add_grade;
        public ICommand Add_Grade
        {
            get
            {
                return add_grade;
            }
        }

        private void Add_Grade_Click(TeacherVM teacherVM)
        {
            teacherBL.AddMark(Student_Name, Subject_Name, grade_semester, grade_value);
            OnButtonClick(teacherVM);
        }

        private void Final_Grade_Click(TeacherGradesVM teacherGradesVM)
        {
            if(Marks_List.Count<3)
            {
                MessageBox.Show("Sunt necesare minim 3 note");
                return;
            }
            bool ok = false;
            float gradeSum = 0;
            float gradeThesis = 0;
            float finalGrade = 0;
            foreach(Mark var in Marks_List)
            {
                if(var.IsThesisMark == true)
                {
                    //nota de teză este înregistrată în variabila
                    gradeThesis = var.Grade;
                    ok = true;
                }
                else
                {
                    //se adaugă nota curentă la suma totală a notelor
                    gradeSum += var.Grade; 
                }
            }
            switch(ok)
            {
                case true:
                    finalGrade = ((gradeSum / (Marks_List.Count-1))*3 + gradeThesis) / 4;
                    break;
                case false:
                    finalGrade = gradeSum / Marks_List.Count;
                    break;
            }
            MessageBox.Show(finalGrade.ToString());
            teacherBL.AddFinalMark(subject_name, student_name,finalGrade, semester);
        }

        private ICommand delete_grade;
        public ICommand Delete_Grade
        {
            get
            {
                return delete_grade;
            }
        }

        private ICommand final_grade;
        public ICommand Final_Grade
        {
            get
            {
                return final_grade;
            }
        }

        private void Delete_Grade_Click(System.Windows.Controls.ListBox listBox)
        {
            var elem = listBox.SelectedItem as Mark;
            teacherBL.DeleteMark(elem.Mark_Id);
            Marks_List.RemoveAt(listBox.SelectedIndex);
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
