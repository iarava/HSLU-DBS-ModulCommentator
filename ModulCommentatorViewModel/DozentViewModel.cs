using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using ModulCommentatorModel;
using RavenDB;

namespace ModulCommentatorViewModel
{
    public class DozentViewModel : INotifyPropertyChanged
    {
        DozentModel dozentModel;

        Professor currentDozent;

        public DozentViewModel(DozentModel model)
        {
            this.dozentModel = model;

            this.currentDozent = new Professor("-", "MUDO", "muster.dozent@hslu.ch", "Dozent", "Muster" );
        }

        public string Key { get { return currentDozent.Id; } set { currentDozent.Id = value; } }

        public string Vorname { get { return currentDozent.vorname; } set { currentDozent.vorname = value; } }

        public string Nachname { get { return currentDozent.nachname; } set { currentDozent.nachname = value; } }

        public string Mail { get { return currentDozent.email; } set { currentDozent.email = value; } }

        public string Kuerzel { get { return currentDozent.kuerzel; } set { currentDozent.kuerzel = value; } }

        public List<Professor> DozentenListe { get { return dozentModel.GetDozentenListe(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyCahnged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if(handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }
    }
}
