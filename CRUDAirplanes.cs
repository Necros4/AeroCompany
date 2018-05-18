using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class CRUDAirport
    {
        public static void createAirport(AirportsDB adb, Airport aprt)
        {
            if (isAirportInList(adb, aprt))
                Console.WriteLine("This airport has been already in the " + adb.getName + "!");
            else
            {
                adb.add(aprt);
                Console.WriteLine("The airport " + aprt.Name + "  was succesfully added to the " + adb.getName + "!");
            }
        }

        public static void deleteAirport(AirportsDB adb, string name)
        {
            Airport aprt = getAirport(adb, name);
            if (aprt != null && isAirportInList(adb, aprt))
            {
                adb.delete(aprt);
                Console.WriteLine("Airport " + name + " was succesfully removed from the " + adb.getName + "!");
            }
            else
                Console.WriteLine("Check the name of the airport! The " + adb.getName + "isn't have such name of the airport!");
        }

        public static void updateAirport(AirportsDB adb, string name, Airport newAirport)
        {
            Airport p = getAirport(adb, name);
            if (p != null)
            {
                p.Name = newAirport.Name;
            }
            else
                Console.WriteLine("Can't find airport with such name! Check the name of the airport!");
        }

        public static Airport getAirport(AirportsDB adb, string name)
        {
            foreach (Airport p in adb.getAirports)
                if (p.Name == name)
                    return p;
            return null;
        }

        private static bool isAirportInList(AirportsDB adb, Airport aprt)
        {
            foreach (Airport p in adb.getAirports)
                if (p == aprt)
                    return true;
            return false;
        }
    }
}
