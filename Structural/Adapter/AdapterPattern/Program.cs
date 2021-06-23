using System;

namespace AdapterPattern
{
    class Program
    {

        class Adaptee
        {
            public string GetRequest()
            {
                return "Request from the client";
            }
        }

        public interface ITarget
        {
            string Request();
        }

        class Adapter : ITarget
        {
            private readonly Adaptee adaptee;

            public Adapter(Adaptee adaptee)
            {
                this.adaptee = adaptee;
            }

            public string Request()
            {
                return $"This is '{this.adaptee.GetRequest()}'";
            }
        }
        static void Main(string[] args)
        {
            Adaptee adaptee = new Adaptee();
            ITarget target = new Adapter(adaptee);
            System.Diagnostics.Debug.WriteLine(target.Request()); 
        }
    }
}
