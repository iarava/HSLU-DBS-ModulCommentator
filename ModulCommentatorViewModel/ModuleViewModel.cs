using ModulCommentatorModel;
using RavenDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace ModulCommentatorViewModel
{
    public class ModuleViewModel
    {
        Modul currentModul;
        ModulModel modulModel;
        private ICommand createStudentCmd;
        private ICommand clearFieldsCmd;

        public ModuleViewModel(ModulModel modulModel)
        {
            this.modulModel = modulModel;

            this.currentModul = new Modul("", "Testmdoul", "Test", "");

            // Add command buttons
           // this.createStudentCmd = new RelayCommand(CreateStudentFunc, param => true);
            this.clearFieldsCmd = new RelayCommand(ClearFieldsFunc, param => true);
        }

        public string Key { get { return currentModul.Id; } set { currentModul.Id = value; } }
        /*
        public string Vorname { get { return currentStudent.vorname; } set { currentStudent.vorname = value; } }

        public string Nachname { get { return currentStudent.nachname; } set { currentStudent.nachname = value; } }

        public string Mail { get { return currentStudent.email; } set { currentStudent.email = value; } }

        public string Username { get { return currentStudent.username; } set { currentStudent.username = value; } }

        public List<Modul> StudentenListe { get { return this.studentModel.GetStudentenListe(); } }
        */
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
        /*
        public void CreateStudentFunc(object obj)
        {
            if (this.currentStudent != null)
            {
                this.studentModel.CreateStudent(this.currentStudent);
                this.OnPropertyChanged("StudentenListe");
            }
        }
        */
        public void ClearFieldsFunc(object obj)
        {
            this.currentModul = new Modul("","","","");
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
