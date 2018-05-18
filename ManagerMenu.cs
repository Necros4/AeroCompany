using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class ManagerMenu : AbstrInstance
    {
        private PlanesDB pdb;
        private AirportsDB adb;
        private string command = String.Empty;
        private Manager man;

        public ManagerMenu(PlanesDB p, AirportsDB a)
        {
            pdb = p;
            adb = a;
        }

        protected override void Init()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Manager Menu.\nEnter your name:");
            Console.ResetColor();
            string name = Console.ReadLine();
            man = new Manager(name);
            Console.Clear();
            man.openDB(adb);
            man.openDB(pdb);
        }

        protected override void Idle()
        {
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Manager Menu");
                Console.ResetColor();
                Console.WriteLine("Insert one command-key per string. For help insert \"h\" (without quotes).");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(man.getName + ">");
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
                    case "ca":
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("Create Airport.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Airport name:");
                            string name = Console.ReadLine();
                            Airport a = new Airport(name);
                            man.createAirport(a);
                            break;
                        }
                    case "cp":
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.Write("Create Plane.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Plane name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Plane capacity:");
                            int cap = Convert.ToInt32(Console.ReadLine());
                            Plane p = new Plane(name, cap);
                            man.createPlane(p);
                            break;
                        }
                    case "da":
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Delete Airport.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Airport name:");
                            string name = Console.ReadLine();
                            man.deleteAirport(name);
                            break;
                        }
                    case "dp":
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("Delete Plane.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Plane ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            man.deletePlane(id);
                            break;
                        }
                    case "h":
                        {
                            Console.WriteLine("The command keys is: \nca - create Airport;\ncp - create Plane;\nda - delete Airport;\n" +
                                "dp - delete Plane;\nh - help;\nla - show list of Airport;\nlp - show list of Planes;\nq - quit from Pilot Menu;\nra - read(check) Airport;\nrp - read(check) Plane;\n" +
                                "ua - update Airport;\n.up - update Plane.");
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
                    case "q":
                        {
                            man.closeAirportsDB();
                            man.closePlanesDB();
                            SetDone();
                            break;
                        }
                    case "ra":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Read(check) Airport.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Airport name:");
                            string name = Console.ReadLine();
                            man.readAirport(name);
                            break;
                        }
                    case "rp":
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("Read(check) Plane.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Plane ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            man.readPlane(id);
                            break;
                        }
                    case "ua":
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Update Airport.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Airport name:");
                            string old = Console.ReadLine();
                            Console.WriteLine("Airport new name:");
                            string newA = Console.ReadLine();
                            man.updateAirport(old, new Airport(newA));
                            break;
                        }
                    case "up":
                        {
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Update flight.");
                            Console.ResetColor();
                            Console.WriteLine("Enter required data:");
                            Console.WriteLine("Plane ID:");
                            int id = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Plane new name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Plane new capacity:");
                            int cap = Convert.ToInt32(Console.ReadLine());
                            Plane p = new Plane(name, cap);
                            man.updatePlane(id, p);
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
            }
            while (command != "q");
        }
    }
}
