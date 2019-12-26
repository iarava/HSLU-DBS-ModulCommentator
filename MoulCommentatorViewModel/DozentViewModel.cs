using ModulCommentatorModel;
using System;
using System.ComponentModel;

namespace MoulCommentatorViewModel
{
    class DozentViewModel : INotifyPropertyChanged
    {
        Dozent currentDozent;

        public DozentViewModel()
        {
            currentDozent = new Dozent();
        }

        public string Key { get { return currentDozent.Key; } set { currentDozent.Key = value; } }

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
