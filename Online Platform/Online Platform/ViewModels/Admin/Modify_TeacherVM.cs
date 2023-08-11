using Online_Platform.Commands;
using Online_Platform.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Online_Platform.ViewModels
{
    class Modify_TeacherVM
    {
        AdminBusinessLogic adminBL;

        public Modify_TeacherVM()
        {
            adminBL = new AdminBusinessLogic();
            modify_teacher = new RelayCommand<Link_AdminVM>(ModifyTeacher);
        }

        private string teacher_name;
        public string Teacher_Name
        {
            get
            {
                return teacher_name;
            }
            set
            {
                teacher_name = value;
                OnPropertyChanged("Teacher_Name");

            }
        }


        private string class_name;
        public string Class_Name
        {
            get
            {
                return class_name;
            }
            set
            {
                class_name = value;
                OnPropertyChanged("Class_Name");

            }
        }


        private int class_number;
        public int Class_Number
        {
            get
            {
                return class_number;
            }
            set
            {
                class_number = value;
                OnPropertyChanged("Class_Number");

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

        private ICommand modify_teacher;
        public ICommand Modify_Teacher
        {
            get
            {
                return modify_teacher;
            }
        }

        public void ModifyTeacher(Link_AdminVM obj)
        {
            adminBL.ModifyTeacher(teacher_name, class_name, class_number, subject_name);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

