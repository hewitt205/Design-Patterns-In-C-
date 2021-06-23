using System;
using System.Diagnostics;


namespace DecoratorPattern
{
    class Program
    {
        public interface ICar
        {
            string Type { get; }
            double Price { get; }
        }

        public class Car : ICar
        {
            public string Type
            {
                get { return "Tesla"; }
            }

            public double Price
            {
                get { return 1000000; }
            }
        }

        public abstract class VehicleDecorator : ICar
        {
            private ICar vehicle;

            public VehicleDecorator(ICar vehicle)
            {
                this.vehicle = vehicle;
            }

            public string Type
            {
                get { return vehicle.Type; }
            }

            public double Price
            {
                get { return vehicle.Price; }
            }
        }

        public class SpecialOffer: VehicleDecorator
        {
            public SpecialOffer(ICar vehicle) : base(vehicle) { }

            public int DiscountPercentage { get; set; }
            public string Offer { get; set; }

            public double Price
            {
                get
                {
                    double Price = base.Price;
                    int percentage = 100 - DiscountPercentage;
                    return Math.Round((Price * percentage) / 100, 2);
                }
            }
        }
        static void Main(string[] args)
        {
            Car car = new Car();
            Console.WriteLine($"Tesla base price is : {car.Price}");
            SpecialOffer offer = new SpecialOffer(car);
            offer.DiscountPercentage = 50;
            offer.Offer = "50% discount";
            Debug.WriteLine($"{offer.Offer} discount on Tesla cars, new price is : {offer.Price} ");
        }
    }
}
