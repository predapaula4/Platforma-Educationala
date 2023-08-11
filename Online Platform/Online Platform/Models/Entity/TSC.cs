using System.ComponentModel;

namespace Online_Platform.Models.Entity
{
    class TSC: INotifyPropertyChanged
    {
        private int tsc_id;
        public int TSC_Id
        {
            get
            {
                return tsc_id;
            }
            set
            {
                tsc_id = value;
                OnPropertyChanged("TSC_Id");
            }
        }

        private int teacher_id;
        public int Teacher_Id
        {
            get
            {
                return teacher_id;
            }
            set
            {
                teacher_id = value;
                OnPropertyChanged("Teacher_Id");
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

        private int class_id;
        public int Class_Id
        {
            get
            {
                return class_id;
            }
            set
            {
                class_id = value;
                OnPropertyChanged("Class_Id");
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


        private bool is_head_teahcer;
        public bool Is_Head_Teacher
        {
            get
            {
                return is_head_teahcer;
            }

            set
            {
                is_head_teahcer = value;
                OnPropertyChanged("Is_Head_Teacher ");
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
