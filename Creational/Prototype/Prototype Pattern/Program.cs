using System;

namespace Prototype_Pattern
{
    public class Person : ICloneable //ICloneable is how we make something cloneable in C#
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public object Clone() //clone method from the ICloneable interface that must be implemented
        {
            return this.MemberwiseClone();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person
            {
                FirstName = "John",
                LastName = "Smith"
            };

            Person p2 = p1.Clone() as Person;
        }
    }
}
