using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Platform.Models
{
    class Student: INotifyPropertyChanged
    {
        private int student_id;
        public int Student_id
        {
            get
            {
                return student_id;
            }

            set
            {
                student_id = value;
                OnPropertyChanged("Student_id");
            }
        }

        private int class_id;
        public int Class_id
        {
            get
            {
                return class_id;
            }

            set
            {
                class_id = value;
                OnPropertyChanged("Class_id");
            }
        }

        private int user_id;
        public int User_id
        {
            get
            {
                return user_id;
            }

            set
            {
                user_id = value;
                OnPropertyChanged("User_id");
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
