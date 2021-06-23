using System;
using System.Diagnostics;
// Create 5 things
// Abstract factory - interface for the operations we will use to create and abstract product
// Concrete factory - class implementing the abstract factory interface operations to create concrete products
// abstract products - interfaces for a type of product object
// concrete products - product that is created with above implemented interface (abstract product)
// client - uses abstract factory and abstract product interfaces to create a family of related objects
namespace AbstractFactoryPattern
{
    /// <summary>
    /// Abstract Factory
    /// </summary>
    interface IMobile
    {
        IAndroid GetAndroidPhone();
        IiOS GetiOSPhone();

    }
    /// <summary>
    /// Concrete Factory used to create concrete products
    /// </summary>
    class Samsung : IMobile
    {
        public IAndroid GetAndroidPhone()
        {
            return new SamsungGalaxy();
        }

        public IiOS GetiOSPhone()
        {
            return new SamsungGuru();
        }
    }
    /// <summary>
    /// Abstract Product - interface for a type of android product
    /// </summary>
    interface IAndroid
    {
        string GetModelDetails();
    }
    /// <summary>
    /// Abstract Product - interface for IOS product
    /// </summary>
    interface IiOS
    {
        string GetModelDetails();
    }
    /// <summary>
    /// Product to create implementing the above abstract product interfaces (concrete product)
    /// </summary>
    class SamsungGalaxy : IAndroid
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Galaxy - RAM: 2GB - Camera: 13MP";
        }
    }

    class SamsungGuru : IiOS
    {
        public string GetModelDetails()
        {
            return "Model: Samsung Guru - RAM: N/A - Camera: N/A";
        }
    }
    /// <summary>
    /// Client - 
    /// </summary>
    class MobileClient
    {
        IAndroid androidPhone;
        IiOS iOSPhone;
        //constructor for class takes in an IMobile variable named factory
        public MobileClient(IMobile factory)
        { //this is using the factory to create both types of phones
            androidPhone = factory.GetAndroidPhone();
            iOSPhone = factory.GetiOSPhone();
        }

        public string GetAndroidPhoneDetails()
        {
            return androidPhone.GetModelDetails();
        }

        public string GetiOSPhoneDetails()
        {
            return iOSPhone.GetModelDetails();
        }
    }
    class Program
    {
        static void Main(string[] args)
        { //showing how the above code works, i.e. the implementation of an abstract factory
            IMobile samsungMobilePhone = new Samsung();
            MobileClient samsungClient = new MobileClient(samsungMobilePhone);

            Debug.WriteLine(samsungClient.GetAndroidPhoneDetails());
            Debug.WriteLine(samsungClient.GetiOSPhoneDetails());
        }
    }
}
