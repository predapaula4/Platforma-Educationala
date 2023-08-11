using Online_Platform.Commands;
using Online_Platform.Models.BusinessLogic;
using System.ComponentModel;
using System.Windows.Input;

namespace Online_Platform.ViewModels
{
    class Link_AdminVM: INotifyPropertyChanged
    {
        AdminBusinessLogic adminBL;

        public Link_AdminVM()
        {
            adminBL = new AdminBusinessLogic();
            add_link = new RelayCommand<Link_AdminVM>(AddLink);
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
        private bool have_thesis;
        public bool Have_Thesis
        {
            get
            {
                return have_thesis;
            }
            set
            {
                have_thesis = value;
                OnPropertyChanged("Have_Thesis");
            }
        }

        private ICommand add_link;
        public ICommand Add_Link
        {
            get
            {
                return add_link;
            }
        }

        public void AddLink(Link_AdminVM obj)
        {
            adminBL.AddLink(teacher_name, class_name, class_number, subject_name, have_thesis);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
