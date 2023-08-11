using System.Windows.Input;
using Online_Platform.Commands;
using Online_Platform.Models;
using Online_Platform.Models.BusinessLogic;
using System.Windows;
using Online_Platform.Views;
using System.ComponentModel;
using System.Windows.Controls;

namespace Online_Platform.ViewModels
{
    class UserVM
    {
        public UserBusinessLogic userBl { get; set; }
        public static User current_user;
        private ICommand button_clicked;

        public UserVM()
        {
            userBl = new UserBusinessLogic();
            button_clicked = new RelayCommand<PasswordBox>(OnButtonClick);
            
        }       
       
        public ICommand Button_Clicked
        {
            get
            {
                return button_clicked;
            }
        }

        public User User_Class
        {
            get
            {
                return userBl.user;
            }
            set
            {
                userBl.user.CopyUser(value);
            }
        }

        private void OnButtonClick(PasswordBox password)
        {
            userBl.user.Password = password.Password;
            User user = userBl.GetUser();
            current_user = user;
            switch (int.Parse(user.User_Role))
            {
                case 0:
                    {
                        AdminView window = new AdminView();                       
                        window.Show();      
                        break;
                    }
                case 1:
                    {
                        TeacherView window = new TeacherView();
                        window.Show();
                        break;
                    }
                case 2:
                    {
                        TeacherView window = new TeacherView(Visibility.Visible);
                        window.Show();
                        break;
                    }
                case 3:
                    {
                        StudentView window = new StudentView();
                        window.DataContext = new StudentVM();
                        window.Show();
                        break;
                    }
                default:
                    {
                        MessageBox.Show("Numele de utilizator sau parola sunt incorecte");
                        break;
                    }
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
