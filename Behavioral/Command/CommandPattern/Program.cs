using System;
using System.Diagnostics;

namespace CommandPattern
{
    class Program
    {
        public interface ICommand
        {
            string Name { get; set; }
            void Execute();
        }

        public class HelloCommand : ICommand
        {
            public string Name
            {
                get { return "Hello"; }
            }

            public void Execute()
            {
                Debug.WriteLine("I am executing HelloCommand.");
            }
        }

        public class GoodbyeCommand : ICommand
        {
            public string Name
            {
                get
                {
                    return "Goodbye";
                }
            }

            public void Execute()
            {
                Debug.WriteLine("I am executing the GoodbyeCommand.");
            }
        }

        public class Invoker
        {
            ICommand command = null;
            public ICommand GetCommand(string action)
            {
                switch(action)
                {
                    case "Hello":
                        command = new HelloCommand();
                        break;
                    case "Goodbye":
                        command = new GoodbyeCommand();
                        break;
                    default:
                        break;
                }

                return command;
            }
        }
        static void Main(string[] args)
        {
            Invoker invoker = new Invoker();
            ICommand command = invoker.GetCommand("Hello");
            command.Execute();
            command = invoker.GetCommand("Goodbye");
            command.Execute();
        }
    }
}
