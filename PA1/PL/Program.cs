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
    
        } // end method
        public static void Main(string[] args)
        {
            

        }
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
            WriteLine("3. A Smart Device");
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
            //
            //Method Name     : void SmartDeviceAdd() 
            //Purpose         : Get new Smart Device info and try to add it to DB
            //Re-use          : none
            //Input Parameter : none
            //Output Type     : none
            //
    
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
    
        } // end method
    }
}
