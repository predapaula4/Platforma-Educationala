using Online_Platform.Commands;
using Online_Platform.Models;
using Online_Platform.Models.BusinessLogic;
using System.ComponentModel;
using System.Windows.Input;

namespace Online_Platform.ViewModels
{
    class TeacherSubjectVM: INotifyPropertyChanged
    {
        TeacherBusinessLogic teacherBL;
        public TeacherSubjectVM()
        {
            teacherBL = new TeacherBusinessLogic();
            get_material = new RelayCommand<TeacherSubjectVM>(Get_Material_Click);
            modify_material = new RelayCommand<TeacherSubjectVM>(Modify_Material_Click);
            delete_material = new RelayCommand<TeacherSubjectVM>(Delete_Material_Click);
        }

        private string subject_name;
        public string Subject_Name
        {
            get
            {
                return subject_name;
            }
            set
            {
                subject_name = value;
                OnPropertyChanged("Subject_Name");
            }
        }

        private string material;
        public string Material
        {
            get
            {
                return material;
            }
            set
            {
                material = value;
                OnPropertyChanged("Material");
            }
        }

        private ICommand get_material;
        public ICommand Get_Material
        {
            get
            {
                return get_material;
            }
        }

        private ICommand modify_material;
        public ICommand Modify_Material
        {
            get
            {
                return modify_material;
            }
        }

        private ICommand delete_material;
        public ICommand Delete_Material
        {
            get
            {
                return delete_material;
            }
        }

        private Subject subject;

        public void Get_Material_Click(TeacherSubjectVM teachersubjectVM)
        {
            if (subject_name != null)
            {
                subject = teacherBL.GetSubject(Subject_Name);
                if (subject != null)
                    Material = subject.Materials;
            }
        }

        public void Modify_Material_Click(TeacherSubjectVM teachersubjectVM)
        {
            if (subject_name != null)
                teacherBL.ModifySubject(subject.Subject_id, material);
        }

        public void Delete_Material_Click(TeacherSubjectVM teachersubjectVM)
        {
            if (subject_name != null)
                teacherBL.DeleteSubject(subject.Subject_id);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
