using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerocompany
{
    class AeroCompany
    {
        List<Plane> ThePlanes;
        List<Flight> TheFlights;
        private string name;

        public AeroCompany(string name)
        {
            this.name = name;
            ThePlanes = new List<Plane>();
            TheFlights = new List<Flight>();
        }

        public void addPlane(Plane plane)
        {
            ThePlanes.Add(plane);
            Console.WriteLine("The plane was succesfully added to the AeroCompany " + name + "!");
        }

        public void deletePlane(Plane plane)
        {
            ThePlanes.Remove(plane);
            Console.WriteLine("The plane was succesfully removed from AeroCompany " + name + "!");
        }


        public void createFlight(Flight flight)
        {
            TheFlights.Add(flight);
            Console.WriteLine("The flight was succesfully added to the AeroCompany " + name + "!");
        }

        private bool isFlightInList(Flight flight)
        {
            foreach (Flight f in TheFlights)
            {
                if (f == flight)
                {
                    return true;
                }
            }
            return false;
        }

        public void getFlights()
        {
            foreach (Flight f in TheFlights)
                Console.WriteLine(f.ToString());
        }

        public void getPlanes()
        {
            foreach (Plane p in ThePlanes)
                Console.WriteLine(p.ToString());
        }


        public void showFlightsOnDate(DateTime date)
        {
            foreach (Flight f in TheFlights)
                if (f.getFlightTime.Date == date.Date)
                    Console.WriteLine(f.ToString());
        }

        public void showFlightsTo(Airport a)
        {
            foreach (Flight f in TheFlights)
                if (f.getDestination == a)
                    Console.WriteLine(f.ToString());
        }

        public void showFlightsFrom(Airport a)
        {
            foreach (Flight f in TheFlights)
                if (f.getSource == a)
                    Console.WriteLine(f.ToString());
        }
    }
}

