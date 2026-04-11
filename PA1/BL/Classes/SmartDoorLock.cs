using static System.Console;


namespace SmartDevices
{
    public class SmartDoorLock : SmartDevice, IBatteryPowered
    {
        public bool IsLocked { get; private set; }
        public int BatteryLevel { get; set; }


        //Constructors
        public SmartDoorLock(string deviceId, string name, Manufacturer manufacturer, int batteryLevel, bool isLocked = false) : base(deviceId, deviceName, manufacturer)
        {
            IsLocked = isLocked;
            BatteryLevel = batteryLevel;

        }

        //Methods
        public void ToggleLock()
        {
            IsLocked = !IsLocked;
        }
        public override string GetStatus()
        {
            string lockState = IsLocked ? "Locked" : "Unlocked";

            return $"Lock: {lockState} | Battery: {BatteryLevel}% | Power: {GetPowerStatus()}";

        }
        public string Charge()
        {
            BatteryLevel = 100;

            return "Door lock fully charged";
        }






    }
}
