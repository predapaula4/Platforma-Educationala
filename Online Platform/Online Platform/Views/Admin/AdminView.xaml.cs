using Online_Platform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Online_Platform.Views
{
    /// <summary>
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
        }
        private void ADMView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new EditUsersVM();
        }
        private void LinkView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new Link_AdminVM();
        }

        private void Remove_Student_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new Remove_StudentVM();
        }

        private void Modify_Teacher_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new Modify_TeacherVM();
        }


    }
}
