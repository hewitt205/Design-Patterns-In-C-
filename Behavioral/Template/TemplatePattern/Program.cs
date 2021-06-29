using System;

namespace TemplatePattern
{
    class Program
    {
        abstract class AbstractClass
        {
            public void TemplateMethod()
            {
                Operation1();
                RequiredOperation1();
                Operation2();
                Hook1();
                RequiredOperations2();
                Operation3();
                Hook2();
            }

            protected void Operation1()
            {
                Debug.WriteLine("Performing operation 1");
            }
            protected void Operation2()
            {
                Debug.WriteLine("Performing operation 2");
            }
            protected void Operation3()
            {
                Debug.WriteLine("Performing operation 3");
            }
            protected abstract void RequriedOperation1();
            protected abstract void RequiredOperation2();
            protected virtual void Hook1() { }
            protected virtual void Hook2() { }
        }
        class ConcreteClass1 : AbstractClass
        {
            protected override void RequriedOperation1()
            {
                Debug.WriteLine("Concrete class 1 - performing required operation 1");
            }
            protected override void RequiredOperation2()
            {
                Debug.WriteLine("Concrete class 1 - performing required operation 2");
            }
        }
        class ConcreteClass2 : AbstractClass
        {
            protected override void RequriedOperation1()
            {
                Debug.WriteLine("Concrete class 2 - performing required operation 1");
            }
            protected override void RequiredOperation2()
            {
                Debug.WriteLine("Concrete class 2 - performing required operation 2");
            }
            protected override void Hook1()
            {
                Debug.WriteLine("Concrete class 2 - Hook 1");
            }
            protected override void Hook2()
            {
                Debug.WriteLine("Concrete class 2 - Hook 2");
            }
        }
        class Client
        {
            public static void ClientCode(AbstractClass abstractClass)
            {
                abstractClass.TemplateMethod();
            }
        }
        static void Main(string[] args)
        {
            Client.ClientCode(new ConcreteClass1());
            Client.ClientCode(new ConcreteClass2());
        }
    }
}
