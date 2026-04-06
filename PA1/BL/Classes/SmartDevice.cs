using PA1.BL.Classes;
using static System.Console;


namespace SmartDevices
{
    // Programmer name : PS Simelane
    // Student nr : 224042163
    // Assignment nr : Assignment 2
    // Purpose : This class represents the general concept of a smart device. 
    //It cannot be instantiated directly.Only specific device types may be created.
    public abstract class SmartDevice
    {
        //Properties
        public string DeviceName { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public bool IsOn { get; private set; }

        //constructor
        public SmartDevice(string deviceName, Manufacturer manufacturer)
        {
            DeviceName = deviceName;
            Manufacturer = manufacturer;
        }

        //methods
        public void TurnOn()
        {
            IsOn = true;
        }

        public void TurnOff()
        {
            IsOn = false;
        }

        public string GetPowerStatus()
        {
            string status = "";
            if (IsOn == true)
            {
                status = "On";
            }
            else
            {
                status = "Off";
            }

            return status;
        }

        public abstract string GetStatus();





    }
}
