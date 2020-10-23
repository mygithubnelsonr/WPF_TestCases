using System.Collections.Generic;

namespace Entity
{
    public class PersonList : List<Person>
    {
        public PersonList()
        {

        }

        public PersonList Load()
        {

            PersonList personList = new PersonList();

            personList.Add(new Person() { ID = 0, Name = "", Vorname = "", Alter = 0 });
            personList.Add(new Person() { ID = 1, Name = "Nelson", Vorname = "Bob", Alter = 65 });
            personList.Add(new Person() { ID = 2, Name = "Meier", Vorname = "Sepp", Alter = 23 });
            personList.Add(new Person() { ID = 3, Name = "Huber", Vorname = "Anna", Alter = 21 });
            personList.Add(new Person() { ID = 4, Name = "Sauber", Vorname = "Tony", Alter = 31 });
            personList.Add(new Person() { ID = 5, Name = "Watt", Vorname = "Susy", Alter = 41 });
            personList.Add(new Person() { ID = 6, Name = "Karl", Vorname = "Xaver", Alter = 36 });

            return personList;
        }
    }
}
