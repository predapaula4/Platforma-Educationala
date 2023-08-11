using Online_Platform.Models;
using Online_Platform.Models.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Online_Platform.ViewModels
{
    class GradesVisualisationVM : INotifyPropertyChanged
    {
        private HeadTeacherBusinessLogic headTeacherBL;
        private List<Student> Students;
        private List<Subject> Subjects;
        public ObservableCollection<Tuple<Student, string, float>> final_grades { get; set; }
        public ObservableCollection<Tuple<Student, float>> student_mean { get; set; }
        public ObservableCollection<Tuple<Student, float>> first_students { get; set; }
        public ObservableCollection<Tuple<Student,string, float>> corrective_students { get; set; }
        public ObservableCollection<Tuple<Student, float>> repeater_students { get; set; }


        public GradesVisualisationVM()
        {
            headTeacherBL = new HeadTeacherBusinessLogic();
            final_grades = new ObservableCollection<Tuple<Student, string, float>>();
            student_mean = new ObservableCollection<Tuple<Student, float>>();
            first_students = new ObservableCollection<Tuple<Student, float>>();
            corrective_students = new ObservableCollection<Tuple<Student, string, float>>();
            repeater_students = new ObservableCollection<Tuple<Student, float>>();
            GetStudentsFromClass();
            GetSubjectsFromClass();
            GetMarks();
            StudentsMean();
        }


        public void GetStudentsFromClass()
        {
            Students = headTeacherBL.GetStudents();
        }

        public void GetSubjectsFromClass()
        {
            Subjects = headTeacherBL.GetSubjects();
        }

        public void GetMarks()
        {
           
            foreach(var student in Students)
            {
                var final = headTeacherBL.GetFinalMarks(student.Student_id, Subjects);
                foreach(var elem in final)
                {
                    final_grades.Add(new Tuple<Student, string, float>(student, elem.Key, elem.Value));
                }
            }
        }

        public void StudentsMean()
        {
            var student_mean_list = new List<Tuple<Student, float>>();
            foreach (var student in Students)
            {
                float sum = 0;
                int count = 0;
                foreach (var final_grade in final_grades)
                {
                    if(student.Student_id == final_grade.Item1.Student_id)
                    {
                        sum += final_grade.Item3;
                        count++;
                        if(final_grade.Item3<5)
                        {
                            corrective_students.Add(final_grade);
                        }
                    }
                }
                student_mean_list.Add(new Tuple<Student, float>(student, sum / count));
               
            }
            student_mean_list = student_mean_list.OrderBy(elem => elem.Item2).ToList();
            foreach(var elem in student_mean_list)
            {
                student_mean.Add(elem);
                if(elem.Item2<5)
                {
                    repeater_students.Add(elem);
                }
            }

            for(int index=0;index<2;index++)
            {
                first_students.Add(student_mean_list[index]);
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
