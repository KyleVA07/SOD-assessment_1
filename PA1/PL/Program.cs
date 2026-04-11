using static System.Console;
using System.Collections;

namespace SmartDevices
{
    internal class Program
    {
        private static List<SmartDevice> smartDeviceList;
        private static void Initialise()
        {
            //
            //Method Name     : void Initialise() 
            //Purpose         : Initialise and instantiate global variables
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //

            smartDeviceList = new List<SmartDevice>();
            smartDeviceList.Add(new SmartLight("SL001", "Living Room Light", new Manufacturer("Philips", "Netherlands"), 75));
            smartDeviceList.Add(new SmartThermostat("ST001", "Hallway Thermostat", new Manufacturer("Nest", "USA"), 22.5, 80));
            smartDeviceList.Add(new SmartDoorLock("SDL001", "Front Door Lock", new Manufacturer("August", "USA"), 75));
    
        } // end method
        public static void ShowMainMenu()
        {
            //
            //Method Name     : void ShowMainMenu() 
            //Purpose         : Display the main menu
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            WriteLine();
            WriteLine("Please select an option:");
            WriteLine("========================");
            WriteLine("1. Smart Home System");
            WriteLine("X. Exit");
            WriteLine();
        } // end method ShowMainMenu()
        public static void ShowSmartDeviceMainMenu()
        {
            //
            //Method Name     : void ShowSmartDeviceMainMenu() 
            //Purpose         : Display the Smart Home System Menu
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            WriteLine();
            WriteLine("SMART HOME SYSTEM: Please select an option:");
            WriteLine("==============================================");
            WriteLine("1. List All Smart Devices");
            WriteLine("2. Add A Smart Device");
            WriteLine("3. Remove A Smart Device");
            WriteLine("4. Update A Smart Device");
            WriteLine("R. Return");
            WriteLine();
        } // end method ShowSmartDeviceMainMenu()
        public static void ProcessSmartDeviceMenu()
        {
            //
            //Method Name     : void ProcessSmartDeviceMenu() 
            //Purpose         : Invoke appropriate method to handle user menu selection
            //Re-use          : ShowSmartDeviceMainMenu();SmartDeviceList();SmartDeviceAdd();SmartDeviceRemove();SmartDeviceUpdate()
            //                  EmployeeUpdate()
            //Input Parameter : none
            //Output Type     : none
            //
            char choice = '0';
            ConsoleKeyInfo cki;

            WriteLine();
            ShowSmartDeviceMainMenu();

            cki = ReadKey();
            WriteLine();
            choice = cki.KeyChar;

            while (choice != 'r' && choice != 'R')
            {
                switch (choice)
                {
                case '1':
                    SmartDeviceList();
                break;
                case '2':
                    SmartDeviceAdd();
                break;
                case '3':
                    SmartDeviceRemove();
                break;
                case '4':
                    SmartDeviceUpdate();
                break;
                case 'R':
                case 'r':
                break;
                default:
                    WriteLine("Invalid input");
                break;
                } // end switch

                WriteLine();
                ShowSmartDeviceMainMenu();

                cki = ReadKey();
                WriteLine();
                choice = cki.KeyChar;
            } // end while
        } // end method
         public static void SmartDeviceAdd()
        {
            {
    string deviceId = "";
    string deviceName = "";
    string manufacturerName = "";
    string manufacturerCountry = "";

    SmartDevice deviceFoundRef = null;
    SmartDevice device = null;

    char choice = '0';

    if (smartDeviceList.Count > 0)
    {
        WriteLine();
        WriteLine("SMART HOME SYSTEM - Add Smart Device");
        WriteLine("=====================================");
        WriteLine("1. Add Smart Light");
        WriteLine("2. Add Smart Thermostat");
        WriteLine("3. Add Smart Door Lock");
        WriteLine("R. Return");

        choice = ReadLine().ToUpper()[0];

        while (choice != 'R')
        {
            WriteLine();

            Write("Device ID: ");
            deviceId = ReadLine().ToUpper();

            deviceFoundRef = FindSmartDevice(deviceId);

            if (deviceFoundRef != null)
            {
                WriteLine(deviceId + " NOT added since it is already in the system");
            }
            else
            {
                Write("Device Name: ");
                deviceName = ReadLine();

                Write("Manufacturer Name: ");
                manufacturerName = ReadLine();

                Write("Manufacturer Country: ");
                manufacturerCountry = ReadLine();

                Manufacturer manufacturer = new Manufacturer(manufacturerName, manufacturerCountry);

                switch (choice)
                {
                    case '1':
                        Write("Brightness (0-100): ");
                        int brightness = int.Parse(ReadLine());

                        device = new SmartLight(deviceId, deviceName, manufacturer, brightness);
                        break;

                    case '2':
                        Write("Temperature: ");
                        double temp = double.Parse(ReadLine());

                        Write("Battery Level (0-100): ");
                        int battery = int.Parse(ReadLine());

                        device = new SmartThermostat(deviceId, deviceName, manufacturer, temp, battery);
                        break;

                    case '3':
                        Write("Battery Level (0-100): ");
                        int lockBattery = int.Parse(ReadLine());

                        device = new SmartDoorLock(deviceId, deviceName, manufacturer, lockBattery);
                        break;

                    default:
                        WriteLine("Invalid input");
                        break;
                }

                if (device != null)
                {
                    smartDeviceList.Add(device);
                    WriteLine(deviceId + " added successfully");
                }
            }

            WriteLine();
            WriteLine("1. Add Smart Light");
            WriteLine("2. Add Smart Thermostat");
            WriteLine("3. Add Smart Door Lock");
            WriteLine("R. Return");

            choice = ReadLine().ToUpper()[0];
        }
    }
    else
    {
        WriteLine("No smart devices found in system.");
    }
}
}
        } // end method

         public static void SmartDeviceList()
        {
            //
            //Method Name     : void SmartDeviceList() 
            //Purpose         : Display the Smart Device records in the DB
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            if (smartDeviceList.Count == 0)
            {
                WriteLine("No smart devices found.");
            }//end if
            else
            {
                WriteLine("Smart Devices:");
                WriteLine("==============");
                foreach (SmartDevice device in smartDeviceList)
                {
                    WriteLine($"ID: {device.DeviceId} | Name: {device.DeviceName} | Manufacturer: {device.Manufacturer.Name} | {device.GetStatus()}");
                }//end foreach
            }//end else
    
        } // end method

        public static void SmartDeviceRemove()
        {
            //
            //Method Name     : void SmartDeviceRemove() 
            //Purpose         : Try to remove a Smart Device record from the DB
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
             string deviceId = "";
             SmartDevice smdRef;

        if (smartDeviceList.Count > 0)
         {
          Write("Please enter the SmartDevice ID to remove: ");
          deviceId = ReadLine().ToUpper();

          smdRef = FindSmartDevice(deviceId);
                  if (smdRef != null)
                  {
                     smartDeviceList.Remove(smdRef);
                     WriteLine(deviceId + " removed successfully.");
                  }//end if
                 else
                 {
                    WriteLine(deviceId + " not removed since it is not in the system.");
                 }//end else
                }//end if
         else
        {
           WriteLine("No smart devices found to remove.");
        }//end else
   
        } // end method

        public static void SmartDeviceUpdate()
        {
            //
            //Method Name     : void SmartDeviceUpdate() 
            //Purpose         : Update existing smart device info
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
            string deviceId = "";
            string deviceName = "";
            Manufacturer manufacturer = null;
            bool validInput = false;

            SmartDevice deviceFoundRef = null;
            bool change = false;

            if(smartDeviceList.Count > 0)
            {
                WriteLine();
                WriteLine("Please enter the SmartDevice ID:");
                deviceId = ReadLine().ToUpper();
                deviceFoundRef = FindSmartDevice(deviceId);
                if (deviceFoundRef != null)
                {
                    Write("New device name or press Enter to keep current name: ");
                    deviceName = ReadLine();
                    if (deviceName.Length != 0)
                    {
                        deviceFoundRef.DeviceName = deviceName;
                        change = true;
                    }//end if
                    while (validInput == false)
                    {
                        Write("Turn device ON/OFF (on/off) or press Enter to not change: ");
                        string isOnInput = ReadLine().ToUpper();
                        if (isOnInput.Length == 0)
                        {
                            validInput = true;
                        }//end if
                        else if (isOnInput == "ON")
                        {

                            deviceFoundRef.TurnOn();
                            change = true;
                            validInput = true;
                        }//end else if
                        else if (isOnInput == "OFF")
                        {
                            deviceFoundRef.TurnOff();
                            change = true;
                            validInput = true;
                        }//end else if
                        else
                        {
                            WriteLine("Invalid input. Please enter 'ON' or 'OFF'.");
                        }//end else
                    }//end while
                    if (deviceFoundRef is IBatteryPowered batteryPowered)
                    {
                        validInput = false;

                        while (validInput == false)
                        {
                            Write("New battery level (0-100) or press Enter to keep current level: ");
                            string input = ReadLine();
                            if (input.Length == 0)
                            {
                                validInput = true;
                            }//end if
                            else if (int.TryParse(input, out int batteryLevelInput))
                            {

                                if (batteryLevelInput >= 0 && batteryLevelInput <= 100)
                                {
                                    batteryPowered.BatteryLevel = batteryLevelInput;
                                    change = true;
                                    validInput = true;
                                }//end if
                                else
                                {
                                    WriteLine("Invalid input. Please enter a valid integer between 0 and 100.");
                                }//end else
                            }//end else if
                            else
                            {
                                WriteLine($"Format Error: {input} is not a valid number. Please use digits.");
                            }//end else
                        }//end while
             
                    }//end if
                    if (change)
                    {
                        WriteLine($"{deviceId} updated successfully.");
                    }//end if
                }//end if
                else
                {
                    WriteLine($"SmartDevice {deviceId.ToUpper()} NOT FOUND!");
                }//end else
            }//end if
            else
            {
                WriteLine("No smart devices found to update.");
            }//end else
    
        } // end method
        private static SmartDevice FindSmartDevice(string deviceId)
        {
            //
            //Method Name     : SmartDevice FindSmartDevice(string deviceId)
            //Purpose         : Search for a SmartDevice object in the generic collection
            //Re-use          : none
            //Input Parameter : string deviceId
            //Output Type     : SmartDevice
            //                  - if the SmartDevice object was found it is returned, otherwise null
            //
            bool found = false;
            int lc = 0;
            SmartDevice deviceRef = null;
            while (found == false && lc < smartDeviceList.Count)
            {
                if (smartDeviceList[lc].DeviceId == deviceId)
                {
                found = true;
                deviceRef = smartDeviceList[lc];
                } // end if

                lc++;
            } // end while

            return deviceRef;
        } // end method
        private static void Main(string[] args)
        {
            //
            //Method Name     : void Main(string[] args)
            //Purpose         : Main entry into program
            //Re-use          : Initialise(); ShowMainMenu();
            //                  ProcessEmployeeMenu(); ProcessStudentMenu();
            //Input Parameter : string[] args
            //                  - command line args - not used
            //Output Type     : none
            //
            char choice = '0';
            ConsoleKeyInfo cki;

            try
            {
                Initialise();

                WriteLine();
                ShowMainMenu();

                cki = ReadKey();
                WriteLine();
                choice = cki.KeyChar;

                while (choice != 'x' && choice != 'X')
                {
                    switch (choice)
                    {
                        case '1':
                            ProcessSmartDeviceMenu();
                            break;
                        case 'x':
                        case 'X':
                            break;
                        default:
                            WriteLine("Invalid input");
                            break;
                    } // end switch

                    WriteLine();
                    ShowMainMenu();

                    cki = ReadKey();
                    WriteLine();
                    choice = cki.KeyChar;
                } // end while
            } // end try 
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            } // end catch
        }//end method
    }//end class internal program
}//end namespace
