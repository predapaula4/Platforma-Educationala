using System.ComponentModel;


namespace Online_Platform.Models
{
    class Subject: INotifyPropertyChanged
    {
        private int subject_id;
        public int Subject_id
        {
            get
            {
                return subject_id;
            }

            set
            {
                subject_id = value;
                OnPropertyChanged("Subject_id");
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



        private string materials;
        public string Materials
        {
            get
            {
                return materials;
            }
            set
            {
                materials = value;
                OnPropertyChanged("Materials");
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
