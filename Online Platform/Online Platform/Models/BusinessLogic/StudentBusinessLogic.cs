using Online_Platform.Models.DataAccess;
using Online_Platform.ViewModels;
using System;
using System.Collections.Generic;

namespace Online_Platform.Models.BusinessLogic
{
    class StudentBusinessLogic
    {
        private Student student;
        private StudentDA studentDA;
        private SubjectDA subjectDA;
        private MarksDA markDA;
        private AbsenteesDA absenteesDA;
        private FinalMarkDA finalMarkDA;
        public List<Subject> subjects { get; set; }
        public Dictionary<string, List<Mark>> subject_marks { get; set; }
        public Dictionary<string, List<Absentees>> subject_absentees;
        public Dictionary<string, float> subject_final_mark;
        public double general_mark { get; set; }

        public StudentBusinessLogic()
        {
            studentDA = new StudentDA();
            subjectDA = new SubjectDA();
            markDA = new MarksDA();
            absenteesDA = new AbsenteesDA();
            finalMarkDA = new FinalMarkDA();
            student = studentDA.GetStudent(UserVM.current_user);
            subjects = subjectDA.GetSubjects(student.Class_id);
            subject_marks = markDA.GetMarks(student.Student_id, subjects);
            subject_absentees = absenteesDA.GetAbsentees(student.Student_id, subjects);
            subject_final_mark = finalMarkDA.GetMarks(student.Student_id, subjects);
            general_mark = 10;
        }

    }
}
