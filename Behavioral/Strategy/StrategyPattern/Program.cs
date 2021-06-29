using System;
using System.Diagnostics;
using System.Collections.Generic;

namespace StrategyPattern
{
    class Program
    {
        class Context
        {
            private IStrategy strategy;
            public Context() { }

            public void SetStrategy(IStrategy strategy)
            {
                this.strategy = strategy;
            }

            public void DoSomeBusinessLogic()
            {
                var reult = strategy.DoAlgorithm(new List<int> { 1, 2, 3, 4, 5, });
                string resultString = string.Empty;
                foreach(int element in resultString as List<int>)
                {
                    resultString += element + " ";
                }
                Debug.WriteLine(resultString);
            }
        }

        public interface IStrategy
        {
            object DoAlgorithm(object data);
        }

        class ConcreteStrategyA : IStrategy
        {
            public object DoAlgorithm(object data)
            {
                var list = data as List<int>;
                list.Sort();
                return list;
            }
        }
        class ConcreteStrategyB : IStrategy
        {
            public object DoAlgorithm(object data)
            {
                var list = data as List<int>;
                list.Sort();
                list.Reverse();
                return list;
            }
        }
        static void Main(string[] args)
        {
            var context = new Context();
            Debug.WriteLine("Strategy is set to ascending sort.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Debug.WriteLine("Strategy is set to descending sort.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
    }
}
