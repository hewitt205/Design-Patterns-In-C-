using System;
using System.Diagnostics;

namespace MediatorPattern
{
    class Program
    {
        public abstract class Friend
        {
            protected IMediator mediator;
            public Friend(IMediator mediator)
            {
                this.mediator = mediator;
            }
        }

        public class AngryFriend1 : Friend
        {
            public AngryFriend1(IMediator mediator) : base(mediator) { }

            public void Send(string msg)
            {
                Debug.WriteLine("Friend 1 send message: " + msg);
                mediator.SendMessage(this, msg);
            }
            public void Receive(string msg)
            {
                Debug.WriteLine("Friend 1 receive message: " + msg);
            }

        }
        public class AngryFriend2 : Friend
        {
            public AngryFriend2(IMediator mediator) : base(mediator) { }

            public void Send(string msg)
            {
                Debug.WriteLine("Friend 2 send message: " + msg);
                mediator.SendMessage(this, msg);
            }
            public void Receive(string msg)
            {
                Debug.WriteLine("Friend 2 receive message: " + msg);
            }

        }
        public interface IMediator
        {
            void SendMessage(Friend caller, string msg);
        }

        public class ConcreteMediator : IMediator
        {
            public AngryFriend1 AngryFriend1 { get; set; }
            public AngryFriend2 AngryFriend2 { get; set; }

            public void SendMessage(Friend caller, string msg)
            {
                if(caller == AngryFriend1)
                {
                    AngryFriend2.Receive(msg);
                }else
                {
                    AngryFriend1.Receive(msg);
                }
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
