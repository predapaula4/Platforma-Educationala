using Online_Platform.Models.DataAccess;
using Online_Platform.ViewModels;
using System;
using System.Collections.Generic;

namespace Online_Platform.Models.BusinessLogic
{
    class HeadTeacherBusinessLogic
    {
        private AbsenteesDA absenteesDA;
        private StudentDA studentDA;
        private TeacherDA teacherDA;
        private SubjectDA subjectDA;
        private TSCDA tscDA;
        private FinalMarkDA finalMarkDA;
        private int class_id;
        Teacher teacher;
        List<Student> students;


        public HeadTeacherBusinessLogic()
        {
            absenteesDA = new AbsenteesDA();
            studentDA = new StudentDA();
            subjectDA = new SubjectDA();
            tscDA = new TSCDA();
            teacherDA = new TeacherDA();
            finalMarkDA = new FinalMarkDA();
            teacher = teacherDA.GetTeacher(UserVM.current_user);
            class_id = tscDA.GetClassIDHead(teacher.Teacher_id);
        }

        public List<Student> GetStudents()
        {
           students= studentDA.GetStudentFromClass(class_id);
            return students;
        }

        public List<Absentees> GetAbsentees()
        {
            return absenteesDA.GetAbsenteesForStudents(students);
        }

        public List<Subject> GetSubjects()
        {
            return subjectDA.GetSubjects(class_id);
        }

        public Dictionary<string, float> GetFinalMarks(int student_id, List<Subject> subjects)
        {
            return finalMarkDA.GetMarks(student_id, subjects);
        }

        public int GetClassId()
        {
            return class_id;
        }
    }
}
