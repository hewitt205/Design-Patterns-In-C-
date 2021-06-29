using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace VisitorPattern
{
    class Program
    {
        public interface IComponent
        {
            void Accept(IVisitor visitor);
        }
        public class ConcreteComponent1 : IComponent
        {
            public void Accept(IVisitor visitor)
            {
                visitor.VisitConcreteComponent1(this);
            }
            public int MethodOfConcreteComponent1()
            {
                return 1;
            }
        }
        public class ConcreteComponent2 : IComponent
        {
            public void Accept(IVisitor visitor)
            {
                visitor.VisitConcreteComponent2(this);
            }

            public int MethodOfConcreteComponent2()
            {
                return 2;
            }
        }
        public interface IVisitor
        {
            void VisitConcreteComponent1(ConcreteComponent1 element);
            void VisitConcreteComponent2(ConcreteComponent2 element);
        }
        class ConcreteVisitor1 : IVisitor
        {
            public void VisitConcreteComponent1(ConcreteComponent1 element)
            {
                Debug.WriteLine(element.MethodOfConcreteComponent1() + " + ConcreteVisitor1");
            }
            public void VisitConcreteComponent2(ConcreteComponent2 element)
            {
                Debug.WriteLine(element.MethodOfConcreteComponent2() + " + ConcreteVisitor1");
            }
        }
        class ConcreteVisitor2 : IVisitor
        {
            public void VisitConcreteComponent1(ConcreteComponent1 element)
            {
                Debug.WriteLine(element.MethodOfConcreteComponent1() + " + ConcreteVisitor2");
            }
            public void VisitConcreteComponent2(ConcreteComponent2 element)
            {
                Debug.WriteLine(element.MethodOfConcreteComponent2() + " + ConcreteVisitor2");
            }
        }
        public class Client
        {
            public static void ClientCode(List<IComponent> components, IVisitor visitor)
            {
                foreach(IComponent compnent in components)
                {
                    component.Accept(visitor);
                }
            }
        }
        static void Main(string[] args)
        {
            List<IComponent> components = new List<IComponent>
            {
                new ConcreteComponent1(),
                new ConcreteComponent2()
            };

            var visitor1 = new ConcreteVisitor1();
            Client.ClientCode(components, visitor1);

            var visitor2 = new ConcreteVisitor2();
            Client.ClientCode(components, visitor2);
        }
    }
}
