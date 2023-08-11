using System.Windows;
using Online_Platform.ViewModels;
namespace Online_Platform.Views
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Window
    {
        public Visibility IsHeadTeacher { get; set; }
        public TeacherView(Visibility isVisible = Visibility.Hidden)
        {           
            InitializeComponent();
            checkabsHT.Visibility = isVisible;
            v2.Visibility = isVisible;
        }

        private void TeacherAbsenteesView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new TeacherAbsenteesVM();
        }

        private void TeacherGradesView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new TeacherGradesVM();
        }

        private void TeacherSubjectView_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new TeacherSubjectVM();
        }
        private void HDAbsentees_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new HDAbsenteesVM();
        }

        private void GradesVisualisation_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new GradesVisualisationVM();
        }
    }
}
