using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class PilotMenu : AbstrInstance
    {
        private Pilot pilot;
        private string command = String.Empty;
        private PlanesDB planesDB;
        private FlightDB flightDB;
        private AirportsDB airDB;

        public PilotMenu(PlanesDB p, FlightDB f, AirportsDB a)
        {
            planesDB = p;
            flightDB = f;
            airDB = a;
        }

        protected override void Init()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Pilot Menu.\nEnter your name:");
            Console.ResetColor();
            string name = Console.ReadLine();
            pilot = new Pilot(name);
            Console.Clear();
            pilot.openDB(flightDB);
        }

        protected override void Idle()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Pilot Menu");
                Console.ResetColor();
                Console.WriteLine("Insert one command-key per string. For help insert \"h\" (without quotes).");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(pilot.getName + ">");
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
                    case "c":
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write("Create flight.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Source airport:");
                            Airport source = new Airport(Console.ReadLine());
                            Console.WriteLine("Destination airport:");
                            Airport dest = new Airport(Console.ReadLine());
                            Console.WriteLine("Plane ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Plane p = CRUDPlanes.getPlane(planesDB, id);
                            Console.WriteLine("Date (yyyy-mm-dd hh:mm):");
                            string d = String.Empty;
                            while (d.IndexOf(":") == -1)
                                d = Console.ReadLine();
                            DateTime date = DateTime.ParseExact(d, "yyyy-MM-dd HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);
                            Flight f = new Flight(source, dest, p, date);
                            Console.WriteLine("Your flight:");
                            Console.WriteLine(f.ToString());
                            Console.WriteLine("Add this flight? (y/n)");
                            if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                            {
                                pilot.createFlight(f);
                                Console.WriteLine("Flight was succesfully created!");
                            }
                            else
                            {
                                Console.WriteLine("Do you realy want to cancel? (y/n)");
                                if (Console.ReadLine() == "N" || Console.ReadLine() == "n")
                                {
                                    pilot.createFlight(f);
                                }
                                else
                                    Console.WriteLine("Addition was canceled.");
                            }
                            break;
                        }
                    case "d":
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Delete flight.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Flight ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Delete this flight? (y/n)");
                            if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                            {
                                Console.WriteLine("Do you realy want to delete this flight? (y/n)");
                                if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                                {
                                    pilot.deleteFlight(id);
                                }
                                else
                                    Console.WriteLine("Deleting was canceled.");
                            }
                            else
                                Console.WriteLine("Deleting was canceled.");
                            break;
                        }
                    case "h":
                        {
                            Console.WriteLine("The command keys is: \nc - create flight;\nd - delete flight;\nh - help;" +
                                "\nla - show list of Aiports;\nlp - show list of Planes;\nlp - show list of Flights;" + 
                                "\nq - quit from Pilot Menu;\nr - read flight;\nu - update flight.");
                            break;
                        }
                    case "la":
                        {
                            foreach (Airport a in airDB.getAirports)
                                Console.WriteLine(a.ToString());
                            break;
                        }
                    case "lp":
                        {
                            foreach (Plane p in planesDB.getPlanes)
                                Console.WriteLine(p.ToString());
                            break;
                        }
                    case "lf":
                        {
                            foreach (Flight f in flightDB.getFlights)
                                Console.WriteLine(f.ToString());
                            break;
                        }
                    case "q":
                        {
                            pilot.closeDB();
                            SetDone();
                            break; 
                        }
                    case "r":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Read flight.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Flight ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            pilot.readFlight(id);
                            break;
                        }
                    case "u":
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Update flight.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Flight id, which need to update:");
                            int idO = Console.Read();
                            Flight fOld = CRUDFlight.getFlight(flightDB, idO);
                            Console.WriteLine(fOld.ToString());
                            Console.WriteLine("Source airport:");
                            Airport source = new Airport(Console.ReadLine());
                            Console.WriteLine("Destination airport:");
                            Airport dest = new Airport(Console.ReadLine());
                            Console.WriteLine("Plane ID:");
                            int id = Console.Read();
                            Plane p = CRUDPlanes.getPlane(planesDB, id);
                            Console.WriteLine("Date (yyyy-mm-dd hh:mm):");
                            string d = String.Empty;
                            while (d.IndexOf(":") == -1)
                                d = Console.ReadLine();
                            DateTime date = DateTime.ParseExact(d, "yyyy-MM-dd HH:mm",
                                       System.Globalization.CultureInfo.InvariantCulture);
                            Flight fNew = new Flight(source, dest, p, date);
                            Console.WriteLine("Your new flight:");
                            Console.WriteLine(fNew.ToString());
                            Console.WriteLine("Update flight? (y/n)");
                            if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                            {
                                Console.WriteLine("Do you realy want to update this flight? (y/n)");
                                if (Console.ReadLine() == "y" || Console.ReadLine() == "Y")
                                {
                                    pilot.updateFlight(idO, fNew);
                                }
                                else
                                    Console.WriteLine("Updated was canceled.");
                            }
                            else
                                Console.WriteLine("Updated was canceled.");
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Incorrect command-key! For help insert \"h\" (without quotes).");
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
