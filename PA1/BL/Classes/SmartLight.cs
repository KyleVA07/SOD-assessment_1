using static System.Console;


namespace SmartDevices
{
    public class SmartLight : SmartDevice
    {
        //Properties
        public int Brightness { get; private set; }

        //constructors
        public SmartLight(string deviceId, string deviceName, Manufacturer manufacturer, int brightness) : base(deviceId, deviceName, manufacturer)
        {

            Brightness = brightness;
        }
        //Methods
        public void SetBrightness(int brightness)
        {
            Brightness = brightness;
        }
        public override string GetStatus()
        {
            return $"Brightness:{Brightness}%  | Power:{GetPowerStatus()}";

        }

        public static bool operator >(SmartLight left, SmartLight right)
        {

            return left.Brightness > right.Brightness;
        }

        public static bool operator <(SmartLight left, SmartLight right)
        {
            return left.Brightness < right.Brightness;
        }
        public override string ToString()
        {
         return $"\nPlease supply the following SmartDevice info:" +
         $"\nDevice ID: {DeviceId}" +
         $"\nDevice Name: {DeviceName}" +
         $"\nManufacturer Name: {Manufacturer.Name}" +
         $"\nManufacturer Country: {Manufacturer.Country}" +
         $"\nBrightness (0-100): {Brightness}" +
         $"\n\n{DeviceName} added";
         }
    }
}
