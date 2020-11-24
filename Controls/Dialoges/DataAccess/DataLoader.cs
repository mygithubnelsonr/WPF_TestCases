using Dialoges.Entities;
using System;
using System.Collections.Generic;

namespace Dialoges.DataAccess
{
    public class DataLoader
    {
        //public List<Person> personList;

        //public DataLoader()
        //{

        //}

        public static List<Person> LoadPersons()
        {
            var personList = new List<Person>();

            personList.Add(new Person() { ID = 0, Vorname = "Gretchen", Nachame = "Wilson", Alter = 34, Geburtstag = DateTime.Parse("1965/4/9") });
            personList.Add(new Person() { ID = 1, Vorname = "Peter", Nachame = "Kula", Alter = 34 });
            personList.Add(new Person() { ID = 2, Vorname = "Hans", Nachame = "Schuller", Alter = 42 });
            personList.Add(new Person() { ID = 3, Vorname = "Maria", Nachame = "Wern", Alter = 19 });
            personList.Add(new Person() { ID = 4, Vorname = "Mario", Nachame = "Glauber", Alter = 58 });
            return personList;
        }
    }
}
