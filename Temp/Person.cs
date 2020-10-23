namespace PersonClass
{
    public class Person
    {
        private string _fisrtname;
        public string FirstName
        {
            get
            {
                return _fisrtname;
            }
            set
            {
                _fisrtname = value;
            }
        }
        private string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
            }
        }
        private string _fullname;
        public string FullName
        {
            get
            {
                return _fisrtname + " " + _lastname; ;
            }
            set
            {
                _fullname = value;
            }
        }
        public Person()
        {
            _fisrtname = "Nirav";
            _lastname = "Daraniya";
        }
    }
}
