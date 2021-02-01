using System;

namespace Databinding
{
    public class Person
    {
        public int ID { get; set; }
        public string Nachame { get; set; }
        public string Vorname { get; set; }
        public int Alter { get; set; }
        public DateTime Geburtstag { get; set; }

        public Person()
        {

        }

        public Person(int _id, string _nachname, string _vorname, int _alter, DateTime _birthday)
        {
            ID = _id;
            Nachame = _nachname;
            Vorname = _vorname;
            Alter = _alter;
            Geburtstag = _birthday;
        }

        public override string ToString()
        {
            return $"{ID},{Nachame},{Vorname},{Alter},{Geburtstag}";
        }
    }
}
