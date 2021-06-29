using System;
using System.Diagnostics;

namespace StatePattern
{
    class Program
    {
        public class Context
        {
            public IState State { get; set; }
            public Context(Istate newstate)
            {
                State = newstate;
            }

            public void Request()
            {
                State.Handle(this);
            }
        }

        public interface IState
        {
            void Handle(Context context);
        }
        public class ConcreteState1 : IState
        {
            public void Handle(Context context)
            {
                Debug.WriteLine("Handle called from Concrete state 1");
                context.State = new ConcreteState2();
            }
        }
        public class ConcreteState2 : IState
        {
            public void Handle(Context context)
            {
                Debug.WriteLine("Handle called from Concrete state 2");
                context.State = new ConcreteState1();
            }
        }
        static void Main(string[] args)
        {
            Context client = new Context(new ConcreteState1);
            client.Request();
            client.Request();
            client.Request();
        }
    }
}
