using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;


namespace IteratorPattern
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public Person(int age, string name)
        {
            Age = age;
            Name = name;
        }
    }

    //class that is our own version of collection(list, array, etc) for this special collection type of Person
    public class PersonCollection : IEnumerator
    {
        private int position;
        private List<Person> peopleList = new List<Person>();

        public PersonCollection()
        {
            position = -1;
            peopleList.Add(new Person(25, "Rob"));
            peopleList.Add(new Person(23, "Sarah"));
            peopleList.Add(new Person(30, "John"));
            peopleList.Add(new Person(41, "Peter"));
        }

        public object Current { get { return peopleList[position]; } }

        public bool MoveNext()
        {
            ++position;
            return position < peopleList.Count;
        }

        public void Reset()
        {
            position = -1;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            PersonCollection collectionOfPeople = new PersonCollection();

            while(collectionOfPeople.MoveNext())
            {
                Person person (Person)collectionOfPeople.Current;
                Debug.WriteLine(person.Name);
                Debug.WriteLine(person.Age);
            }
        }
    }
}
