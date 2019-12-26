using RavenDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace ModulCommentatorModel
{
    public class StudentModel
    {
        DB_Operation db_operation;

        public StudentModel(DB_Operation db_operation)
        {
            this.db_operation = db_operation;
        }

        public List<Student> GetStudentenListe()
        {
            return db_operation.getAllStudents();
        }

        public void CreateStudent(Student stud)
        {
            db_operation.addStudent(stud);
        }

        public Student CreateStudentFromKey(string key)
        {
            Student stud = db_operation.getStudent(key);
            return stud;
        }
    }
}
