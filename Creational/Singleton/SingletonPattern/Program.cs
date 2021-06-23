using System;

namespace SingletonPattern
{
    class Singleton
    {
        private static Singleton instance;

        protected Singleton() { }

        public static Singleton Instance() //this will use lazy initialization
        {
            if(instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
