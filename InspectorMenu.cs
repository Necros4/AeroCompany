using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class InspectorMenu : AbstrInstance
    {
        private Inspector ins;
        private FlightDB fdb;
        private PlanesDB pdb;
        private AirportsDB adb;
        private string command = String.Empty;

        public InspectorMenu(FlightDB f, PlanesDB p, AirportsDB a)
        {
            fdb = f;
            pdb = p; 
            adb = a;
        }

        protected override void Init()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Inspector Menu.\nEnter your name:");
            Console.ResetColor();
            string name = Console.ReadLine();
            ins = new Inspector(name);
            Console.Clear();
            ins.openDB(fdb);
            ins.openDB(pdb);
            ins.openDB(adb);
        }

        protected override void Idle()
        {
            do {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Inspector Menu");
            Console.ResetColor();
            Console.WriteLine("Insert one command-key per string. For help insert \"h\" (without quotes).");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(ins.getName + ">");
            Console.ResetColor();
            try
            {
                 command = Convert.ToString(Console.ReadLine());
            }
            catch (System.IO.IOException)
            {
                 Console.WriteLine("Incorrect command-key! For help insert \"h\" (without quotes).");
                 Console.WriteLine("To continue press Enter...");
                 Console.ReadKey();
                 Console.Clear();
            }
            switch (command)
            {
                case "a":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Read aiport.");
                        Console.ResetColor();
                        Console.WriteLine("Enter required data:");
                        Console.Write("Airpor name: ");
                        string name = Console.ReadLine();
                        ins.readAirport(name);
                        break;
                    }
                case "f":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Read flight.");
                        Console.ResetColor();
                        Console.WriteLine("Enter required data:");
                        Console.Write("Flight ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        ins.readFlight(id);
                        break;
                    }
                case "h":
                    {
                        Console.WriteLine("The command keys is: a - read Airport;\nf - read flight;\nh - for help;" +
                            "\nla - show list of Aiports;\nlp - show list of Planes;\nlp - show list of Flights;\np - read plane;" +
                           "\nq - quit from Inspector Menu.");
                        break;
                    }
                    case "la":
                        {
                            foreach (Airport a in adb.getAirports)
                                Console.WriteLine(a.ToString());
                            break;
                        }
                    case "lp":
                        {
                            foreach (Plane p in pdb.getPlanes)
                                Console.WriteLine(p.ToString());
                            break;
                        }
                    case "lf":
                        {
                            foreach (Flight f in fdb.getFlights)
                                Console.WriteLine(f.ToString());
                            break;
                        }
                    case "p":
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("Read plane.");
                        Console.ResetColor();
                        Console.WriteLine("Enter required data:");
                        Console.Write("Plane ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        ins.readPlanes(id);
                        break;
                    }
                case "q":
                     {
                         ins.closeAirportsDB();
                         ins.closeFlightsDB();
                         ins.closePlanesDB();
                         SetDone();
                         break; 
                     }
                 default:
                     {
                         Console.WriteLine("Incorrect command-key! For help insert \"h\" (without quotes).");
                         Console.WriteLine("To continue press Enter...");
                         Console.ReadKey();
                         Console.Clear();
                         break;
                     }
             }
             Console.WriteLine("To continue press enter...");
             Console.ReadKey();
             Console.Clear();
            } while (command != "q");
        }
    }
}
