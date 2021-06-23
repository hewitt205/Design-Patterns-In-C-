using System;
using System.Diagnostics;
/// <summary>
/// 4 things needed - 
/// builder interface - contains all the steps to creating the object
/// concrete builder class - class for each object representation (type)
/// product class - the product or object being built
/// director class - class used to construct and object using the builder interface
/// </summary>
namespace BuilderPattern
{//Building a computer
    /// <summary>
    /// builder interface
    /// </summary>
    public interface IComputerBuilder
    {
        void SetMonitor();
        void SetMouse();
        void SetKeyboard();
        void SetTower();
        void SetPrinter();

        Computer GetComputer();
    }

    /// <summary>
    /// Product
    /// </summary>
    public class Computer
    {
        public string Monitor { get; set; }
        public string Mouse { get; set; }
        public string Keyboard { get; set; }
        public string Tower { get; set; }
        public string Printer { get; set; }
    }
    /// <summary>
    /// Concrete builder class - each type of computer
    /// </summary>
    public class ComputerABuilder : IComputerBuilder
    {
        Computer computer = new Computer();

        public void SetMonitor()
        {
            computer.Monitor = "Single";
        }
        public void SetMouse()
        {
            computer.Mouse = "Regular";
        }
        public void SetKeyboard()
        {
            computer.Keyboard = "Standard";
        }
        public void SetTower()
        {
            computer.Tower = "16Gb RAM";
        }
        public void SetPrinter()
        {
            computer.Printer = "HP Laserjet 5000";
        }

        //this is the way to get the built computer
        public Computer GetComputer()
        {
            return computer; //this is the computer built by this class
        }
    }

     public class ComputerBBuilder : IComputerBuilder
    {
        Computer computer = new Computer();

        public void SetMonitor()
        {
            computer.Monitor = "Dual";
        }
        public void SetMouse()
        {
            computer.Mouse = "Gaming";
        }
        public void SetKeyboard()
        {
            computer.Keyboard = "Standard";
        }
        public void SetTower()
        {
            computer.Tower = "64Gb RAM";
        }
        public void SetPrinter()
        {
            computer.Printer = "HP Laserjet 7000";
        }

        //this is the way to get the built computer
        public Computer GetComputer()
        {
            return computer; //this is the computer built by this class
        }
    }

    public class ComputerCreator
    {
        //private instance of the builder interface
        private IComputerBuilder computerBuilder;
        //constructor taking in the builder interface type variable
        public ComputerCreator(IComputerBuilder computerBuilder)
        { //setting the member variable of the class to the passed in variable
            this.computerBuilder = computerBuilder;
        }
        //function for creating the computer
        public CreateComputer()
        {
            computerBuilder.SetMonitor();
            computerBuilder.SetMouse();
            computerBuilder.SetKeyboard();
            computerBuilder.SetTower();
            computerBuilder.SetPrinter();
        }
        //returns the built computer using the interface
        public Computer GetComputer()
        {
            return computerBuilder.GetComputer();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ComputerCreator computerACreator = new ComputerCreator(new ComputerABuilder());
            computerACreator.CreateComputer();
            
            ComputerCreator computerBCreator = new ComputerCreator(new ComputerBBuilder());
            computerBCreator.CreateComputer();
        }
    }
}
