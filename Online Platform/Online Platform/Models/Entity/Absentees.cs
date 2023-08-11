using System;
using System.ComponentModel;

namespace Online_Platform.Models
{
    class Absentees: INotifyPropertyChanged
    {
        private int absentee_id;
        public int Absentee_Id
        {
            get
            {
                return absentee_id;
            }

            set
            {
                absentee_id = value;
                OnPropertyChanged("Absentee_Id");
            }
        }

        private int subject_id;
        public int Subject_Id
        {
            get
            {
                return subject_id;
            }

            set
            {
                subject_id = value;
                OnPropertyChanged("Subject_Id");
            }
        }

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


        private DateTime absentee_date;
        public DateTime Absentee_Date
        {
            get
            {
                return absentee_date;
            }

            set
            {
                absentee_date = value;
                OnPropertyChanged("Absentee_Date");
            }
        }

        private bool is_motivated;
        public bool Is_Motivated
        {
            get
            {
                return is_motivated;
            }

            set
            {
                is_motivated = value;
                OnPropertyChanged("Is_Motivated");
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

        private string absentee_date_str;
        public string Absentee_Date_Str
        {
            set
            {
                absentee_date_str = value;
                OnPropertyChanged("Absentee_Date_Str");
            }
            get
            {
                return absentee_date_str;
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
