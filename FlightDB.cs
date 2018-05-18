using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerocompany
{
    class FlightDB
    {
        List<Flight> flightsList;
        private string name;

        public FlightDB(string name)
        {
            flightsList = new List<Flight>();
            this.name = name;
        }

        public string getName
        {
            get { return name; }
        }

        public void createFlight(Airport s, Airport d, Plane p, DateTime date)
        {
            Flight flight = new Flight(s, d, p, date);
            flightsList.Add(flight);
            Console.WriteLine("The flight was succesfully added " + name);
        }
    }
}
