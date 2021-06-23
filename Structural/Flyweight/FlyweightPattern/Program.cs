using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FlyweightPattern
{
    class Program
    {
        const string RED = "Red";
        const string GREEN = "Green";
        const string BLUE = "Blue";

        interface IColor
        {
            void Print();
        }
        class Red : IColor
        {
            public void Print()
            {
                Debug.WriteLine("printing red");
            }
        }
        class Green : IColor
        {
            public void Print()
            {
                Debug.WriteLine("printing green");
            }
        }
        class Blue : IColor
        {
            public void Print()
            {
                Debug.WriteLine("printing blue");
            }
        }

        class ColorObjectFactory
        {
            Dictionary<string, IColor> colors = new Dictionary<string, IColor>();

            public int TotalObjectsCreated
            {
                get
                {
                    return colors.Count;
                }
            }

            public IColor GetColor(string colorName)
            {
                IColor color = null;

                if(colors.ContainsKey(colorName))
                {
                    color = colors[colorName];
                } else
                {
                    switch(colorName)
                    {
                        case RED:
                            color = new Red();
                            colors.Add(RED, color);
                            break;
                        case GREEN:
                            color = new Green();
                            colors.Add(GREEN, color);
                            break;
                        case BLUE:
                            color = new Blue();
                            colors.Add(BLUE, color);
                            break;
                        default:
                            throw new Exception("Factory cannot creatte the sppecified oobject");
                    }
                }
                return color;
            }
        }
        static void Main(string[] args)
        {
            ColorObjectFactory colorFactory = new ColorObjectFactory();

            IColor color = colorFactory.GetColor(RED);
            color.Print();
            color = colorFactory.GetColor(GREEN);
            color.Print();
            color = colorFactory.GetColor(BLUE);
            color.Print();
            color = colorFactory.GetColor(RED); //swtiched back to read without creating a new instance of the object, it is already saved in the dictionary
            color.Print();

            int numberOfObjects = colorFactory.TotalObjectsCreated;
            Debug.WriteLine($"Total objects created {numberOfObjects}");
        }
    }
}
