using System.ComponentModel;

namespace Online_Platform.Models
{
    class Teacher
    {
        private int teacher_id;
        public int Teacher_id
        {
            get
            {
                return teacher_id;
            }
            set
            {
                teacher_id = value;
                OnPropertyChanged("Teacher_id");
            }
        }

        private int user_id;
        public int User_Id
        {
            get
            {
                return user_id;
            }
            set
            {
                user_id = value;
                OnPropertyChanged("User_Id");
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
