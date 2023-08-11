using Online_Platform.Commands;
using Online_Platform.Models;
using Online_Platform.Models.BusinessLogic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Online_Platform.ViewModels
{
    class EditUsersVM : INotifyPropertyChanged
    {
        AdminBusinessLogic adminBL;

        public EditUsersVM()
        {
            adminBL = new AdminBusinessLogic();
            ADM_Subject = Visibility.Hidden;
            ADM_User_Teacher = Visibility.Hidden;
            ADM_User_Student = Visibility.Hidden;
            show_teacher = new RelayCommand<EditUsersVM>(Show_Teacher_Click);
            show_student = new RelayCommand<EditUsersVM>(Show_Student_Click);
            show_material = new RelayCommand<EditUsersVM>(Show_Material_Click);

            add_material = new RelayCommand<EditUsersVM>(Add_Material_Click);
            add_student = new RelayCommand<EditUsersVM>(AddStudent);
            add_teacher = new RelayCommand<EditUsersVM>(AddTeacher);

            delete_teacher = new RelayCommand<ListBox>(DeleteTeacher);
            delete_student = new RelayCommand<ListBox>(DeleteStudent);
            delete_subject = new RelayCommand<ListBox>(DeleteSubject);

            Teachers_List = new ObservableCollection<Teacher>();
            Students_List = new ObservableCollection<Student>();
            Subjects_List = new ObservableCollection<Subject>();
        }

        public ObservableCollection<Teacher> Teachers_List { get; set; }
        public ObservableCollection<Student> Students_List { get; set; }
        public ObservableCollection<Subject> Subjects_List { get; set; }

        private Visibility adm_ut;
        public Visibility ADM_User_Teacher
        {
            get
            {
                return adm_ut;
            }
            set
            {
                adm_ut = value;
                OnPropertyChanged("ADM_User_Teacher");
            }
        }
        private Visibility adm_us;
        public Visibility ADM_User_Student
        {
            get
            {
                return adm_us;
            }
            set
            {
                adm_us = value;
                OnPropertyChanged("ADM_User_Student");
            }
        }
        private Visibility adm_s;
        public Visibility ADM_Subject
        {
            get
            {
                return adm_s;
            }
            set
            {
                adm_s = value;
                OnPropertyChanged("ADM_Subject");
            }
        }

        private ICommand show_student;
        public ICommand Show_Student
        {
            get
            {
                return show_student;
            }
        }

        public void Show_Student_Click(EditUsersVM amdus)
        {
            ADM_Subject = Visibility.Hidden;
            ADM_User_Teacher = Visibility.Hidden;
            ADM_User_Student = Visibility.Visible;
            Students_List.Clear();
            var list = adminBL.GetStudents();
            foreach (var elem in list)
            {
                Students_List.Add(elem);
            }

        }

        private ICommand show_teacher;
        public ICommand Show_Teacher
        {
            get
            {
                return show_teacher;
            }
        }


        public void Show_Teacher_Click(EditUsersVM amdus)
        {
            ADM_Subject = Visibility.Hidden;
            ADM_User_Teacher = Visibility.Visible;
            ADM_User_Student = Visibility.Hidden;

            Teachers_List.Clear();
            var list = adminBL.GetTeachers();
            foreach (var elem in list)
            {
                Teachers_List.Add(elem);
            }

        }

        private ICommand show_material;
        public ICommand Show_Material
        {
            get
            {
                return show_material;
            }
        }


        public void Show_Material_Click(EditUsersVM amdus)
        {
            ADM_Subject = Visibility.Visible;
            ADM_User_Teacher = Visibility.Hidden;
            ADM_User_Student = Visibility.Hidden;

            Subjects_List.Clear();
            var list = adminBL.GetSubjects();
            foreach (var elem in list)
            {
                Subjects_List.Add(elem);
            }
        }



        private string teacher_name;
        public string Teacher_Name
        {
            get
            {
                return teacher_name;
            }
            set
            {
                teacher_name = value;
                OnPropertyChanged("Teacher_Name");
            }
        }


        private string teacher_username;
        public string Teacher_Username
        {
            get
            {
                return teacher_username;
            }
            set
            {
                teacher_username = value;
                OnPropertyChanged("Teacher_Username");
            }
        }


        private string teacher_User_Password;
        public string Teacher_User_Password
        {
            get
            {
                return teacher_User_Password;
            }
            set
            {
                teacher_User_Password = value;
                OnPropertyChanged("Teacher_User_Password");
            }
        }


        private string student_Name;
        public string Student_Name
        {
            get
            {
                return student_Name;
            }
            set
            {
                student_Name = value;
                OnPropertyChanged("Student_Name");
            }
        }


        private string student_Username;
        public string Student_Username
        {
            get
            {
                return student_Username;
            }
            set
            {
                student_Username = value;
                OnPropertyChanged("Student_Username");
            }
        }


        private string student_User_Password;
        public string Student_User_Password
        {
            get
            {
                return student_User_Password;
            }
            set
            {
                student_User_Password = value;
                OnPropertyChanged("Student_User_Password");
            }
        }

        private string student_class_name;
        public string Student_Class_Name
        {
            get
            {
                return student_class_name;
            }
            set
            {
                student_class_name = value;
                OnPropertyChanged("Student_Class_Name");
            }
        }

        private int student_class_number;
        public int Student_Class_Number
        {
            get
            {
                return student_class_number;
            }
            set
            {
                student_class_number = value;
                OnPropertyChanged("Student_Class_Number");
            }
        }

        private int subject_Id;
        public int Subject_Id
        {
            get
            {
                return subject_Id;
            }
            set
            {
                subject_Id = value;
                OnPropertyChanged("Subject_Id");
            }
        }

        private string subject_Name;
        public string Subject_Name
        {
            get
            {
                return subject_Name;
            }
            set
            {
                subject_Name = value;
                OnPropertyChanged("Subject_Name");
            }
        }



        private string subject_Materials;
        public string Subject_Materials
        {
            get
            {
                return subject_Materials;
            }
            set
            {
                subject_Materials = value;
                OnPropertyChanged("Subject_Materials");
            }
        }

        private ICommand add_student;
        public ICommand Add_Student
        {
            get
            {
                return add_student;
            }
        }

        public void AddStudent(EditUsersVM obj)
        {
            adminBL.AddStudent(student_Username, student_User_Password, 3, student_class_name, student_class_number, student_Name);
            Students_List.Clear();
            var list = adminBL.GetStudents();
            foreach (var elem in list)
            {
                Students_List.Add(elem);
            }

        }

        private ICommand add_teacher;
        public ICommand Add_Teacher
        {
            get
            {
                return add_teacher;
            }
        }

        public void AddTeacher(EditUsersVM obj)
        {
            adminBL.AddTeacher(teacher_username, teacher_User_Password, 1, teacher_name);
            Teachers_List.Clear();
            var list = adminBL.GetTeachers();
            foreach (var elem in list)
            {
                Teachers_List.Add(elem);
            }

        }

        private ICommand add_material;
        public ICommand Add_Material
        {
            get
            {
                return add_material;
            }
        }

        public void Add_Material_Click(EditUsersVM amdus)
        {
            var aux = new Subject();
            aux.Materials = subject_Materials;
            aux.Name = subject_Name;
            aux.Subject_id = Subjects_List.Count + 1;
            Subjects_List.Add(aux);
            adminBL.AddSubject(aux.Name, aux.Materials);
        }

        private ICommand delete_subject;
        public ICommand Delete_Subject
        {
            get
            {
                return delete_subject;
            }
        }

        public void DeleteSubject(ListBox listbox)
        {
            adminBL.DeleteSubject((listbox.SelectedItem as Subject).Subject_id);
            Subjects_List.RemoveAt(listbox.SelectedIndex);
        }

        private ICommand delete_teacher;
        public ICommand Delete_Teacher
        {
            get
            {
                return delete_teacher;
            }
        }

        public void DeleteTeacher(ListBox listbox)
        {
            adminBL.DeleteTeacher((listbox.SelectedItem as Teacher).Teacher_id);
            Teachers_List.RemoveAt(listbox.SelectedIndex);
        }

        private ICommand delete_student;
        public ICommand Delete_Student
        {
            get
            {
                return delete_student;
            }
        }

        public void DeleteStudent(ListBox listbox)
        {
            adminBL.DeleteStudent((listbox.SelectedItem as Student).Student_id);
            Students_List.RemoveAt(listbox.SelectedIndex);
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
