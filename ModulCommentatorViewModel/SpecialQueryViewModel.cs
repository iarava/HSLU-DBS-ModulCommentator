using ModulCommentatorModel;
using RavenDB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace ModulCommentatorViewModel
{
    public class SpecialQueryViewModel : INotifyPropertyChanged
    {
        private SpecialQueryModel queryModel;
        private List<Professor> _dozenten;
        private List<ModulCount> _dozentModulCountList;
        private Professor _selectedDozent;

        private ICommand executeCountQuery;

        public SpecialQueryViewModel(SpecialQueryModel queryModel)
        {
            this.queryModel = queryModel;
            this.OnPropertyChanged("DozentenList");

            this.executeCountQuery = new RelayCommand(GetQueryList, param => true);
        }

        public void GetQueryList(object obj)
        {
            if (this._selectedDozent != null)
            {
                _dozentModulCountList = this.queryModel.GetModulCountList(_selectedDozent);
                this.OnPropertyChanged("ModulCountListe");
            }
        }

        public List<Professor> DozentenList
        {
            get { return queryModel.GetAllDozents(); }
            set
            {
                if (_dozenten != value)
                {
                    _dozenten = value;
                }
            }
        }

        public Professor SelectedDozent
        {
            get
            {
                return _selectedDozent;
            }
            set
            {
                _selectedDozent = value;
            }
        }

        public List<ModulCount> ModulCountListe
        {
            get
            {
                return this._dozentModulCountList;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ExecuteCountQuery
        {
            get
            {
                return executeCountQuery;
            }
            set
            {
                executeCountQuery = value;
            }
        }

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
