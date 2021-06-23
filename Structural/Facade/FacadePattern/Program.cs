using System;
using System.Diagnostics;

namespace FacadePattern
{
    class Facade
    {
        protected Subsystem1 subsystem1;
        protected Subsystem2 subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem)
        {
            this.subsystem1 = subsystem1;
            this.subsystem2 = subsystem2;
        }

        public string Operation()
        {
            string result = "Facade intitializes subsystems: \n";
            result += subsystem1.Operation1();
            result += subsystem2.Operation1();
            result += "Facade orders subsystems to perform the actions \n";
            result += subsystem1.Operation2();
            result += subsystem2.Operation2();
            return result;
        }

        public class Subsystem1
        {
            public string Operation1()
            {
                return "\t Subsystem1 - Operation 1 \n";
            }
            public string Operation2()
            {
                return "\t Subsystem1 - Operation 2 \n";
            }
        }

        public class Subsystem2
        {
            public string Operation1()
            {
                return "\t Subsystem 2 - Operation 1 \n";
            }
            public string Operation2()
            {
                return "\t Subsystem 2 - Operation 2 \n";
            }
        }
        class Client
        {
            public static void ClientCode(Facade facade)
            {
                Debug.WriteLine(facade.Operation());
            }
        }
        static void Main(string[] args)
        {
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);
            Client.ClientCode(facade);
        }
    }
}
