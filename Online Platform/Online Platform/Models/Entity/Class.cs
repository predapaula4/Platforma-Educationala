using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Platform.Models
{
    class Class: INotifyPropertyChanged
    {
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

        private string specialization;
        public string Specialization
        {
            get
            {
                return specialization;
            }

            set
            {
                specialization = value;
                OnPropertyChanged("Specialization");
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

        private int number;
        public int Number
        {
            get
            {
                return number;
            }

            set
            {
                number = value;
                OnPropertyChanged("Number");
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
