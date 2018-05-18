using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class CRUDFlight
    {
        public static void createFlight(FlightDB fdb, Flight flight)
        {
            if (isFlightInList(fdb, flight))
                Console.WriteLine("This flight has been already in the " + fdb.getName + "!");
            else
            {
                fdb.add(flight);
                Console.WriteLine("The flight was succesfully added to the " + fdb.getName + " with the #" + flight.getID);
            }
        }

        public static void deleteFlight(FlightDB fdb, int ID)
        {
            Flight flight = getFlight(fdb, ID);
            if (flight != null && isFlightInList(fdb, flight))
            {
                fdb.delete(flight);
                Console.WriteLine("Flight with #" + ID + " was succesfully removed from the " + fdb.getName + "!");
            }
            else
                Console.WriteLine("Check the ID! The " + fdb.getName + "isn't have such ID of a flight!");
        }

        public static void updateFlight(FlightDB fdb, int flightID, Flight newFlight)
        {
            Flight f = getFlight(fdb, flightID);
            if (f != null)
            {
                f.Plane = newFlight.Plane;
                f.Source = newFlight.Source;
                f.Destination = newFlight.Destination;
                f.FlightTime = newFlight.FlightTime;
                Console.WriteLine("The flight #" + flightID + " was succesfully updated!");
            }
            else
                Console.WriteLine("Can't find flight with such ID! Check the ID of flight!");
        }

        public static Flight getFlight(FlightDB fdb, int ID)
        {
            foreach (Flight f in fdb.getFlights)
                if (f.getID == ID)
                    return f;
            return null;
        }

        private static bool isFlightInList(FlightDB fdb, Flight flight)
        {
            foreach (Flight f in fdb.getFlights)
                if (f == flight)
                    return true;
            return false;
        }
    }
}
