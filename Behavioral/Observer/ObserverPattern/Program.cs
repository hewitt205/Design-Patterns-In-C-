using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace ObserverPattern
{
    class Program
    {

        public interface IObserver
        {
            void Update(ISubject subject);
        }

        public interface ISubject
        {
            void Attach(IObserver observer);
            void Detach(IObserver observer);
            void Notify();
        }

        public class ConcreteSubject : ISubject
        {
            public int State { get; set; }
            private List<IObserver> observers = new List<IObserver>();

            public void Attach(IObserver observer)
            {
                Debug.WriteLine("Concrete Subject - Attached observer.");
            }
            public void Detach(IObserver observer)
            {
                observers.Remove(observer);
                Debug.WriteLine("Concrete Subject - Detatched observer.");
            }
            public void Notify()
            {
                Debug.WriteLine("Concrete Subject - Notifying observers");
                foreach(var observer in observers)
                {
                    observer.Update(this);
                }
            }
            public void BusinessLogic()
            {
                Debug.WriteLine("Concrete Subject - Generating Random Number");
                State = new Random().Next(0, 100);
                Thread.Sleep(1000);
                Debug.WriteLine("Subject - state changed to: " + State);
                Notify();
            }
        }

        class ConcreteObserver1 : IObserver
        {
            public void Update(ISubject subject)
            {
                if((subject as ConcreteSubject).State < 50)
                {
                    Debug.WriteLine("Concrete Observer 1 : Reacted to the event.");
                }
            }
        }
        class ConcreteObserver2 : IObserver
        {
            public void Update(ISubject subject)
            {
                if(subject as ConcreteSubject).State >= 50)
                {
                    Debug.WriteLine("Concrete Observer 2 : Reacted to the event.");
                }
            }
        }
        static void Main(string[] args)
        {
            ConcreteSubject subject = new ConcreteSubject();
            ConcreteObserver1 observer1 = new ConcreteObserver1();
            subject.Attach(observer1);

            ConcreteObserver2 observer2 = new ConcreteObserver2();
            subject.Attach(observer2);

            subject.BusinessLogic();
            subject.BusinessLogic();
            subject.BusinessLogic();

            subject.Detach(observer2);
            subject.BusinessLogic();
        }
    }
}
