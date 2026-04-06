using PA1.BL.Classes;
using static System.Console;

namespace SmartDevices
{
    public class SmartThermostat : SmartDevice, IBatteryPowered
    {
        //Property
        public double Temperature { get; private set; }
        public int BatteryLevel { get; set; }


        //constructor
        public SmartThermostat(string name, Manufacturer manufacturer, double temperature, int batteryLevel) : base(name, manufacturer)
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

    }
}
