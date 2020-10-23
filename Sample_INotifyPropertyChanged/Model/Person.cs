using System.ComponentModel;

namespace PersonClass
{
    public class Person : INotifyPropertyChanged
    {
        private string _firstname;
        private string _lastname;
        private string _fullname;

        public event PropertyChangedEventHandler PropertyChanged;

        public Person()
        {
            _firstname = "Nirav";
            _lastname = "Daraniya";
        }

        public string FirstName
        {
            get
            {
                return _firstname;
            }
            set
            {
                _firstname = value;
                OnPropertyRaised("Firstname");
                OnPropertyRaised("Fullname");
            }
        }

        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyRaised("LastName");
                OnPropertyRaised("Fullname");
            }
        }

        public string FullName
        {
            get
            {
                return _firstname + " " + _lastname; ;
            }
            set
            {
                _fullname = value;
                OnPropertyRaised("Fullname");
            }
        }

        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
