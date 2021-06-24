using System;
using System.Threading;


namespace ChainOfResponsibilityPattern
{
    public abstract class Hndlerbase
    {
        public Hndlerbase NextContestant { get; private set; }
        public ContextObject Question { get; private set; }

        public Handlerbase(Handlerbase nextHandler, ContextObject question)
        {
            NextContestant = nextHandler;
            Question = question;
        }

        public abstract void HandleRequest();
    }

    public class ContestantOne : Handlerbase
    {//constructor colon base is the base constructor - this specifies the base class's constructor that should be called when this constructor is invoked
        public ContestantOne(Handlerbase nextHandler, ContextBoundObject quest) : base(nextHandler, question) { }

        public override void HandleRequest()
        {
            Console.WriteLine("Question : {0}", Question.Question.ToString());
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Waiting for contestant one to respond");
            Thread.Sleep(3000);
            Console.Write("\t no response from contestant one.....");
            NextContestant.HandleRequest();
        }
    }
    public class ContestantTwo : Handlerbase
    {//constructor colon base is the base constructor - this specifies the base class's constructor that should be called when this constructor is invoked
        public ContestantTwo(Handlerbase nextHandler, ContextBoundObject quest) : base(nextHandler, question) { }

        public override void HandleRequest()
        {
            Console.WriteLine("Question : {0}", Question.Question.ToString());
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Waiting for contestant two to respond");
            Thread.Sleep(3000);
            Console.Write("\t no response from contestant two.....");
            NextContestant.HandleRequest();
        }
    }
    public class ContestantThree : Handlerbase
    {//constructor colon base is the base constructor - this specifies the base class's constructor that should be called when this constructor is invoked
        public ContestantThree(Handlerbase nextHandler, ContextBoundObject quest) : base(nextHandler, question) { }

        public override void HandleRequest()
        {
            Console.WriteLine("Question : {0}", Question.Question.ToString());
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Waiting for contestant three to respond");
            Thread.Sleep(3000);
            Console.Write("\t no response from contestant three.....");
        }
    }

    public class ContextObject
    {
        public string Question { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ContextObject question = new ContextObject()
            {
                Question = "Who was the first president of the United States?"
            };

            ContestantThree contestantThree = new ContestantThree(null, question);
            ContestantTwo contestantTwo = new ContestantTwo(contestantThree, question);
            ContestantOne contestantOne = new ContestantOne(contestantTwo, question);

            contestantOne.HandleRequest();
        }
    }
}
