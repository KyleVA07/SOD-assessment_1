using static System.Console;

namespace SmartDevices
{
    public class SmartThermostat : SmartDevice, IBatteryPowered
    {
        //Property
        public double Temperature { get; private set; }
        public int BatteryLevel { get; set; }


        //constructor
        public SmartThermostat(string deviceId, string deviceName, Manufacturer manufacturer, double temperature, int batteryLevel) : base(deviceId, deviceName, manufacturer)
        {

            Temperature = temperature;
            BatteryLevel = batteryLevel;
        }

        //methods
        public void SetTemperature(double temperature)
        {
            Temperature = temperature;
        }
        public override string GetStatus()
        {
            return $"Temperature:{Temperature}°C | Battery: {BatteryLevel}% | Power:{GetPowerStatus()}";

        }
        public string Charge()
        {
            BatteryLevel = 100;

            return "Thermostat fully charged.";
        }
        public override string ToString()
        {
         return $"\nPlease supply the following SmartDevice info:" +
           $"\nDevice ID: {DeviceId}" +
           $"\nDevice Name: {DeviceName}" +
           $"\nManufacturer Name: {Manufacturer.Name}" +
           $"\nManufacturer Country: {Manufacturer.Country}" +
           $"\nTemperature : {Temperature}" +
           $"\nBattery Level: {BatteryLevel}" +
           $"\n\n{DeviceName} added";
        }
    }
}
