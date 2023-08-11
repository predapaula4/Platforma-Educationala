using Online_Platform.Commands;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;

namespace Online_Platform.Models
{
    public class User: INotifyPropertyChanged
    {

        public User()
        {
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
            }
        }

        private string username;
        public string UserName
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
                OnPropertyChanged("UserName");
            }
        }

        private string password;

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }


        private string user_role;

        public string User_Role
        {
            get
            {
                return user_role;
            }

            set
            {
                user_role = value;
                OnPropertyChanged("User_Role");
            }
        }   
        
        public void CopyUser(User user)
        {
            this.username = user.username;
            this.password = user.password;
            this.user_role = user.user_role;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
