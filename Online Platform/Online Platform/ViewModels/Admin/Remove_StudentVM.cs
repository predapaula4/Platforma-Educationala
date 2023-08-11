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
    class Remove_StudentVM: INotifyPropertyChanged
    {
        private AdminBusinessLogic adminBL;

        public Remove_StudentVM()
        {
            adminBL = new AdminBusinessLogic();
            modify_student = new RelayCommand<Remove_StudentVM>(ModifyStudent);
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

        private ICommand modify_student;
        public ICommand Modify_Student
        {
            get
            {
                return modify_student;
            }
        }

        public void ModifyStudent(Remove_StudentVM obj)
        {
            adminBL.ModifyStudent(student_name);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
