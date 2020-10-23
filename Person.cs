using System.ComponentModel;

namespace Abschnitt_10
{
    public class Person : INotifyPropertyChanged
    {
        private int _id;
        private string _nachname;
        private string _vorname;
        private string _vollerName;
        private int _alter;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string Nachname
        {
            get { return _nachname; }
            set
            {
                _nachname = value;
                OnPropertyChanged("Nachname");
                OnPropertyChanged("VollerName");
            }

        }
        public string Vorname
        {
            get { return _vorname; }
            set
            {
                _vorname = value;
                OnPropertyChanged("Vorname");
                OnPropertyChanged("VollerName");
            }

        }
        public string VollerName
        {
            get
            {
                _vollerName = $"{_vorname} {_nachname}";
                return _vollerName;
            }

            set
            {
                if (_vollerName != value)
                {
                    _vollerName = value;

                    var tokens = _vollerName.Split();
                    _vorname = tokens[0];
                    _nachname = tokens[1];

                    OnPropertyChanged("Vorname");
                    OnPropertyChanged("Nachname");
                }
            }
        }
        public int Alter
        {
            get { return _alter; }
            set { _alter = value; }
        }

        public Person()
        {

        }

        public Person(int ID, string Nachname, string Vorname, int Alter)
        {
            _id = ID;
            _nachname = Nachname;
            _vorname = Vorname;
            _alter = Alter;
        }

        // Events
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
    }
}
