using static System.Console;

namespace SmartDevices
{
    public interface IBatteryPowered
    {
        //property
        int BatteryLevel { get; set; }

        //constructor
        string Charge();

    }
}
