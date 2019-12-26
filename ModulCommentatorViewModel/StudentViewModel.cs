using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using ModulCommentatorModel;
using RavenDB;

namespace ModulCommentatorViewModel
{
    public class StudentViewModel : INotifyPropertyChanged
    {
        Student currentStudent;
        StudentModel studentModel;
        private ICommand createStudentCmd;
        private ICommand clearFieldsCmd;

        public StudentViewModel(StudentModel studentModel)
        {
            this.studentModel = studentModel;

            this.currentStudent = new Student("-", "iastudent", "muster@stud.hslu.ch", "Student","Muster");

            // Add command buttons
            this.createStudentCmd = new RelayCommand(CreateStudentFunc, param => true);
            this.clearFieldsCmd = new RelayCommand(ClearFieldsFunc, param => true);
        }

        public string Key { get { return currentStudent.Id; } set { currentStudent.Id = value; } }

        public string Vorname { get { return currentStudent.vorname; } set { currentStudent.vorname = value; } }

        public string Nachname { get { return currentStudent.nachname; } set { currentStudent.nachname = value; } }

        public string Mail { get { return currentStudent.email; } set { currentStudent.email = value; } }

        public string Username { get { return currentStudent.username; } set { currentStudent.username = value; } }

        public List<Student> StudentenListe { get { return this.studentModel.GetStudentenListe(); } }

        public ICommand CreateStudent
        {
            get
            {
                return createStudentCmd;
            }
            set
            {
                createStudentCmd = value;
            }
        }

        public ICommand ClearFields
        {
            get
            {
                return clearFieldsCmd;
            }
            set
            {
                clearFieldsCmd = value;
            }
        }

        public void CreateStudentFunc(object obj)
        {
            if (this.currentStudent != null)
            {
                this.studentModel.CreateStudent(this.currentStudent);
                this.OnPropertyChanged("StudentenListe");
            }
        }

        public void ClearFieldsFunc(object obj)
        {
            this.currentStudent = new Student("-", "", "", "", "");
            this.OnPropertyChanged("");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
