using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class AeroCompany
    {
        List<Plane> planesList;
        List<Flight> flightsList;
        private string name;

        public AeroCompany(string n)
        {
            this.name = n;
            planesList = new List<Plane>();
            flightsList = new List<Flight>();
        }

        public void addPlane(Plane plane)
        {
            if (isPlaneInList(plane))
                Console.WriteLine("This plane has been already in the AeroCompany " + name + "!");
            else
            {
                planesList.Add(plane);
                Console.WriteLine("The plane was succesfully added to the AeroCompany " + name + "!");
            }
        }

        public void deletePlane(Plane plane)
        {
            if (isPlaneInList(plane))
            {
                planesList.Remove(plane);
                Console.WriteLine("The plane was succesfully removed from AeroCompany " + name + "!");
            }
            else
                Console.WriteLine("Check the data! The AeroCompany " + name + "isn't have this plane!");
        }

        private bool isPlaneInList(Plane plane)
        {
            foreach (Plane p in planesList)
            {
                if (p == plane)
                {
                    return true;
                }
            }
            return false;
        }

        public void createFlight(Flight flight)
        { 
            if (!isPlaneInList(flight.Plane))
            {
                Console.WriteLine("This flight can't be added to the AeroCompany " + name + ", because plane isn't belong to that company!");
                return;
            }
            if (isFlightInList(flight))
                Console.WriteLine("This flight has been already in the AeroCompany " + name + "!");
            else
            {
                flightsList.Add(flight);
                Console.WriteLine("The flight was succesfully added to the AeroCompany " + name + "!");
            }
        }

        public void deleteFlight(Flight flight)
        {
            if (isFlightInList(flight))
            {
                flightsList.Remove(flight);
                Console.WriteLine("This flight was succesfully removed from the AeroCompany " + name + "!");
            }
            else
                Console.WriteLine("Check the data! The AeroCompany " + name + "isn't have this flight!");
        }

        private bool isFlightInList(Flight flight)
        {
            foreach (Flight f in flightsList)
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
            foreach (Flight f in flightsList)
                Console.WriteLine(f.ToString());
        }

        public void getPlanes()
        {
            foreach (Plane p in planesList)
                Console.WriteLine(p.ToString());
        }

        public void showPlaneFlight(Plane plane)
        {
            if (!isPlaneInList(plane))
                Console.WriteLine("This plane isn't in the AeroCompany " + name + "!");
            else
                foreach (Flight f in flightsList)
                    if (f.Plane == plane)
                        Console.WriteLine(f.ToShortString());
        }

        public void showFlightsOnDate(DateTime date)
        {
             foreach (Flight f in flightsList)
                 if (f.FlightTime.Date == date.Date)
                     Console.WriteLine(f.ToString());
        }

        public void showFlightsTo(Airport a)
        {
            foreach (Flight f in flightsList)
                if ((f.Destination).Name == a.Name)
                    Console.WriteLine(f.ToString());
        }

        public void showFlightsFrom(Airport a)
        {
            foreach (Flight f in flightsList)
                if ((f.Source).Name == a.Name)
                    Console.WriteLine(f.ToString());
        }
    }
}
