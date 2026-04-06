using static System.Console;


namespace SmartDevices
{
    public class SmartLight : SmartDevice
    {
        //Properties
        public int Brightness { get; private set; }

        //constructors
        public SmartLight(string name, Manufacturer manufacturer, int brightness) : base(name, manufacturer)
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
    }
}
