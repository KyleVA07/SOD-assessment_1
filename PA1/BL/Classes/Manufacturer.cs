using static System.Console;


namespace SmartDevices
{
    // Programmer name : PS Simelane
    // Student nr : 224042163
    // Assignment nr : Assignment 2
    // Purpose : This class represents a company that produces smart devices. 
    //It will be used as part of another class.
    public class Manufacturer
    {

        //Properties

        public string Name { get; set; }
        public string Country { get; set; }

        //Constructors
        public Manufacturer()
        {

        }
        public Manufacturer(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public string GetInfo()
        {
            return $"{Name} ({Country})"
            ;


        }//end method
    }//end class
}//end namespace
