using static System.Console;


namespace SmartDevices
{
    public class SmartDoorLock : SmartDevice, IBatteryPowered
    {
        public bool IsLocked { get; private set; }
        public int BatteryLevel { get; set; }


        //Constructors
        public SmartDoorLock(string deviceId, string deviceName, Manufacturer manufacturer, int batteryLevel, bool isLocked = false) : base(deviceId, deviceName, manufacturer)
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
        public override string ToString()
        {
          return $"\nPlease supply the following SmartDevice info:" +
           $"\nDevice ID: {DeviceId}" +
           $"\nDevice Name: {DeviceName}" +
           $"\nManufacturer Name: {Manufacturer.Name}" +
           $"\nManufacturer Country: {Manufacturer.Country}" +
           $"\nBattery Level: {BatteryLevel}" +
           $"\nLock State: {(IsLocked ? "Locked" : "Unlocked")}" +
           $"\n\n{DeviceName} added";
         }





    }
}
