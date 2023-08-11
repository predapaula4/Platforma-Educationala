using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Platform.Models
{
    class Mark: INotifyPropertyChanged
    {
        private int mark_id;
        public int Mark_Id
        {
            get
            {
                return mark_id;
            }

            set
            {
                mark_id = value;
                OnPropertyChanged("Mark_Id");
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
        private float grade;
        public float Grade
        {
            get
            {
                return grade;
            }
            set
            {
                grade = value;
                OnPropertyChanged("Grade");
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
