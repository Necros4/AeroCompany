using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class MainMenu : AbstrInstance
    {
        FlightDB flightDB = new FlightDB("Flight Data Base");
        PlanesDB planesDB = new PlanesDB("Planes Data Base");
        AirportsDB airDB = new AirportsDB("Aiports Date Base");

        protected override void Init()
        {
            planesDB.add(new Plane("AN-17", 96));
            planesDB.add(new Plane("AN-18", 156));
            planesDB.add(new Plane("AN-17", 96));
            planesDB.add(new Plane("AN-22", 120));
            airDB.add(new Airport("Boryspil"));
            airDB.add(new Airport("Jylianu"));
            airDB.add(new Airport("Cyprus"));
            airDB.add(new Airport("London"));
        }

        protected override void Idle()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Main Menu.");
            Console.ResetColor();
            Console.WriteLine("Choose an action: \n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1 - Pilot menu");
            Console.ForegroundColor = ConsoleColor.Cyan ;
            Console.WriteLine("2 - Manager menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("3 - Inspector menu");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("4 - Exit");
            Console.ResetColor();
            Console.Write("\nYour choise is: ");
            Console.ForegroundColor = ConsoleColor.Green;
            int choise = Convert.ToInt32(Console.ReadLine());
            Console.ResetColor();
            switch (choise)
            {
                case 1:
                    {
                        PilotMenu pilotMenu = new PilotMenu(planesDB, flightDB, airDB);
                        CleanUp();
                        pilotMenu.Run();
                        break;
                    }
                case 2:
                    {
                        ManagerMenu manMenu = new ManagerMenu(planesDB, airDB);
                        CleanUp();
                        manMenu.Run();
                        break;
                    }
                case 3:
                    {
                        InspectorMenu insMenu = new InspectorMenu(flightDB, planesDB, airDB);
                        CleanUp();
                        insMenu.Run();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Exit");
                        SetDone();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Wrong key! To continue press enter...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    }
            }
        }
    }
}
