using Online_Platform.Models.DataAccess;
using System.Collections.Generic;

namespace Online_Platform.Models.BusinessLogic
{
    class AdminBusinessLogic
    {
        private StudentDA studentDA;
        private SubjectDA subjectDA;
        private TeacherDA teacherDA;
        private UserDA userDA;
        private ClassDA classDA;
        private TSCDA tscDA;

        public AdminBusinessLogic()
        {
            studentDA = new StudentDA();
            subjectDA = new SubjectDA();
            teacherDA = new TeacherDA();
            userDA = new UserDA();
            classDA = new ClassDA();
            tscDA = new TSCDA();
        }

        public List<Student> GetStudents()
        {
            return studentDA.GetAllStudents();
        }

        public List<Teacher> GetTeachers()
        {
            return teacherDA.GetAllTeachers();
        }

        public List<Subject> GetSubjects()
        {
            return subjectDA.GetAllSubjects();
        }

        internal void ModifyStudent(string student_name)
        {
            studentDA.ModifyStudent(student_name);
        }

        public void AddSubject(string name, string material)
        {
            subjectDA.AddSubject(name, material);
        }

        public void ModifySubject(int subject_id, string material)
        {
            subjectDA.ModifySubject(subject_id, material);
        }

        public void AddStudent(string username, string user_password, int user_role, string class_name, int class_number, string student_name)
        {
            userDA.AddUser(username, user_password, user_role);
            int class_id = classDA.GetClassByName(class_name, class_number);
            int user_id = userDA.GetUser(new User() { UserName = username, Password = user_password, User_Role = user_role.ToString() }).User_Id;
            studentDA.AddStudent(class_id, user_id, student_name);
        }

        public void AddTeacher(string username, string user_password, int user_role, string name)
        {
            userDA.AddUser(username, user_password, user_role);
            int user_id = userDA.GetUser(new User() { UserName = username, Password = user_password, User_Role = user_role.ToString() }).User_Id;
            teacherDA.AddTeacher(user_id, name);
        }

        internal void ModifyTeacher(string teacher_name, string class_name, int class_number, string subject_name)
        {
            Teacher teacher = teacherDA.GetTeacherByName(teacher_name);
            int teacher_id = teacher.Teacher_id;
            int class_id = classDA.GetClassByName(class_name, class_number);
            int subject_id = subjectDA.GetSubjectByName(subject_name).Subject_id;
            tscDA.ModifyTSC(teacher_id, class_id, subject_id);
            if (subject_name == "Dirigentie")
            {
                userDA.Modify_User(teacher.User_Id);
            }
        }

        public void DeleteStudent(int student_id)
        {
            studentDA.DeleteStudent(student_id);
        }

        public void DeleteTeacher(int teacher_id)
        {
            teacherDA.DeleteTeacher(teacher_id);
        }

        public void DeleteSubject(int subject_id)
        {
            subjectDA.DeleteSubject(subject_id);
        }


        public void AddLink(string teacher_name, string class_name, int class_number, string subject_name, bool have_thesis)
        {
            int teacher_id = teacherDA.GetTeacherByName(teacher_name).Teacher_id;
            int class_id = classDA.GetClassByName(class_name, class_number);
            int subject_id = subjectDA.GetSubjectByName(subject_name).Subject_id;
            bool isHeadTeacher = subject_name == "Dirigentie" ? true : false;
            tscDA.ADDTsc(teacher_id, class_id, subject_id, isHeadTeacher, have_thesis);
            if (subject_name == "Dirigentie")
            {
                userDA.Modify_User(teacherDA.GetTeacherByName(teacher_name).User_Id);
            }
        }

    }
}
