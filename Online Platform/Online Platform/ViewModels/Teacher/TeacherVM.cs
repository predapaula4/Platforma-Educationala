using Online_Platform.Commands;
using Online_Platform.Models.BusinessLogic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace Online_Platform.ViewModels
{
    class TeacherVM : INotifyPropertyChanged
    {
        TeacherBusinessLogic teacherBL;
        public TeacherVM()
        {
            teacherBL = new TeacherBusinessLogic();
            button_clicked = new RelayCommand<TeacherVM>(OnButtonClick);
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

        private string action;
        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                action = value;
                OnPropertyChanged("Action");
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
            switch(action)
            {
                case "Absente":
                    {
                        if (!Check_Inputs())
                            return;
                        teacherBL.GetAbsences(student_name, subject_name, semester);
                        break;
                    }
                case "Note":
                    {
                        if (!Check_Inputs())
                            return;
                        teacherBL.GetGrades(student_name, subject_name, semester);
                        break;
                    }
                case "Material Didactic":
                    {
                        if (subject_name == null)
                        {
                            MessageBox.Show("Numele subiectului trebuie completat");
                            return;
                        }
                        if (semester == 0)
                        {
                            MessageBox.Show("Semestrul trebuie completat");
                            return;
                        }
                        break;
                    }
                case "Calcul Medie":
                    {
                        if (!Check_Inputs())
                            return;
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Pentru a efectua o operatie numele acesteia trebuie scris in ultima casuta");
                        break;
                    }

            }
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
