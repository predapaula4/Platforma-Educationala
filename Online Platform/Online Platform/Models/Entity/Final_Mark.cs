using System.ComponentModel;

namespace Online_Platform.Models
{
    class Final_Mark: INotifyPropertyChanged
    {

        private int final_mark_id;
        public int Final_Mark_Id
        {
            get
            {
                return final_mark_id;
            }

            set
            {
                final_mark_id = value;
                OnPropertyChanged("Final_Mark_Id");
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

        private float finalGrade;

        public float FinalGrade
        {
            get { return finalGrade; }
            set { finalGrade = value; OnPropertyChanged("FinalGrade"); }
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



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
