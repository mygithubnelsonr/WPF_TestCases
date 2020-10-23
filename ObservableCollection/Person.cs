namespace ObservableCollection
{
    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public int Alter { get; set; }

        public Person(int _id, string _name, string _vorname, int _alter)
        {
            ID = _id;
            Name = _name;
            Vorname = _vorname;
            Alter = _alter;
        }
    }
}
