using static System.Console;
using System.Collections;

namespace SmartDevices
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //myDoorLock.IsLocked = true;

            //Manufacturer objects
            Manufacturer philips = new Manufacturer("Philips Hue", "Netherlands");
            Manufacturer lifx = new Manufacturer("LIFX ", "Australia");
            Manufacturer nest = new Manufacturer("Google Nest", "USA");
            Manufacturer ecobee = new Manufacturer("Ecobee", "Canada");
            Manufacturer yale = new Manufacturer("Yale Smart Locks", "UK");
            Manufacturer august = new Manufacturer("August Home", "USA");
            Manufacturer nanoleaf = new Manufacturer("Nanoleaf", "Canada");

            //SmartLight objects
            SmartLight livingRoomLight = new SmartLight("Living Room Light", philips, 80);
            SmartLight kitchenLight = new SmartLight("Kitchen Light", lifx, 65);
            SmartLight bedroomLight = new SmartLight("Bedroom Light", philips, 50);
            SmartLight gamingRoomLight = new SmartLight("Gaming Room Light", nanoleaf, 90);

            //SmartTheromstat objects
            SmartThermostat hallwayThermostat = new SmartThermostat("Hallway Thermostat", nest, 21.5, 70);
            SmartThermostat bedroomThermostat = new SmartThermostat("Bedroom Thermostat", ecobee, 20.0, 85);
            SmartThermostat officeThermostat = new SmartThermostat("Office Thermostat", nest, 22.0, 60);

            //SmartDoorLock objects
            SmartDoorLock frontDoorLock = new SmartDoorLock("Front Door Lock", yale, 75, true);
            SmartDoorLock backDoorLock = new SmartDoorLock("Back Door Lock", august, 50);
            SmartDoorLock garageDoorLock = new SmartDoorLock("Garage Door Lock", yale, 40, true);

            //ArraylistDevices
            ArrayList devices = new ArrayList();

            //objects arraylist
            devices.Add(livingRoomLight);
            devices.Add(hallwayThermostat);
            devices.Add(frontDoorLock);
            devices.Add(backDoorLock);
            devices.Add(garageDoorLock);
            devices.Add(kitchenLight);
            devices.Add(bedroomLight);
            devices.Add(gamingRoomLight);
            devices.Add(bedroomThermostat);
            devices.Add(officeThermostat);



            foreach (object obj in devices)
            {
                SmartDevice device = obj as SmartDevice;

                WriteLine(device.DeviceName);
                WriteLine(device.GetStatus());
            }

            foreach (object obj in devices)
            {
                SmartLight lightRef;

                lightRef = obj as SmartLight;

                if (lightRef != null)
                {
                    lightRef.TurnOff();
                    WriteLine($"{lightRef.DeviceName} is turned off.");
                }
            }

            SmartLight brightestLight = null;

            SmartLight slightRef;

            foreach (object obj in devices)
            {

                slightRef = obj as SmartLight;
                if (slightRef != null)
                {
                    if (brightestLight == null || slightRef > brightestLight)
                    {
                        brightestLight = slightRef;
                    }
                }
            }
            if (brightestLight != null)

            {

                WriteLine($"Brightest light: {brightestLight.DeviceName} ({brightestLight.Brightness}%)");

            }


        }
    }
}
