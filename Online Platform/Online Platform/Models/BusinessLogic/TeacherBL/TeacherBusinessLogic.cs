using Online_Platform.Models.DataAccess;
using Online_Platform.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Online_Platform.Models.BusinessLogic
{
    class TeacherBusinessLogic
    {
        Teacher teacher;
        StudentDA studentDA;
        TeacherDA teacherDA;
        AbsenteesDA absenteesDA;
        MarksDA marksDA;
        FinalMarkDA finalMarkDA;
        SubjectDA subjectDA;
        Student student;
        Subject subject;

        public TeacherBusinessLogic()
        {
            teacherDA = new TeacherDA();
            studentDA = new StudentDA();
            subjectDA = new SubjectDA();
            absenteesDA = new AbsenteesDA();
            marksDA = new MarksDA();
            finalMarkDA = new FinalMarkDA();
            teacher = teacherDA.GetTeacher(UserVM.current_user);
        }

        public  List<Absentees> GetAbsences(string student_name, string subject_name, int semester)
        {

            if (GetFromDB(student_name, subject_name, semester))
            {
                List<Subject> subjects = new List<Subject>();
                subjects.Add(subject);
                var absentees = absenteesDA.GetAbsentees(student.Student_id, subjects);
                return absentees[subject_name];
            }
            return null;

        }

        public List<Mark> GetGrades(string student_name, string subject_name, int semester)
        {
            if (GetFromDB(student_name, subject_name, semester)) 
            {
                List<Subject> subjects = new List<Subject>();
                subjects.Add(subject);
                var grades = marksDA.GetMarks(student.Student_id, subjects);
                return grades[subject_name];
            }
            return null;
        }

        public void AddAbsence(string student_name, string subject_name, int semester, DateTime date)
        {
            if (GetFromDB(student_name, subject_name, semester))
            {
                absenteesDA.AddAbsentee(student.Student_id, subject.Subject_id, semester, date);
            }
        }

        public void AddFinalMark(string subject_name, string student_name,float final_grade, int semester)
        {
            if (GetFromDB(student_name, subject_name, semester))
            {
                finalMarkDA.AddFinalMark(subject.Subject_id, student.Student_id, final_grade, semester);
            }
        }

        public void AddMark(string student_name, string subject_name, int semester, int grade)
        {
            if (GetFromDB(student_name, subject_name, semester))
            {
                marksDA.AddGrade(student.Student_id, subject.Subject_id, semester, grade);
            }
        }

        internal void DeleteSubject(int subject_id)
        {
            subjectDA.ModifySubject(subject_id, "");
        }

        internal void ModifySubject(int subject_id, string material)
        {
            subjectDA.ModifySubject(subject_id, material);
        }

        public void CheckAbsence(int absentee_id)
        {
            absenteesDA.ModifyAbsentee(absentee_id);
        }

        public void DeleteMark(int mark_id)
        {
            marksDA.DeleteMark(mark_id);
        }

        public Subject GetSubject(string subject_name)
        {
            subject = subjectDA.GetSubjectByName(subject_name);
            if (subject == null)
            {
                MessageBox.Show("Subiectul nu exista");
                return null;
            }
            if (!teacherDA.CheckTeacherSubject(subject.Subject_id, teacher.Teacher_id))
             {
                MessageBox.Show("Profesorul nu preda aceasta materie");
                return null;
            }
            return subject;
        }


        private bool GetFromDB(string student_name, string subject_name, int semester)
        {
            subject = subjectDA.GetSubjectByName(subject_name);
            if (subject == null)
            {
                MessageBox.Show("Subiectul nu exista");
                return false; ;
            }
           student = studentDA.GetStudentByName(student_name);
            if (student == null)
            {
                MessageBox.Show("Studentul nu exista");
                return false; ;
            }

            if (!teacherDA.CheckTeacherClass(student.Class_id, subject.Subject_id, teacher.Teacher_id))
            {
                MessageBox.Show("Profesorul nu corespunde clasei sau materiei");
                return false;
            }
            return true;
        }
    }
}
