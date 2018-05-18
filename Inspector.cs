using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class Inspector
    {
        private string name;
        private FlightDB flightDB;
        private AirportsDB airportDB;
        private PlanesDB planeDB;

        public Inspector(string name)
        {
            this.name = name;
        }

        public string getName
        {
            get {return name;}
        }

        public void openDB(FlightDB f)
        {
            flightDB = f;
        }

        public void openDB(AirportsDB a)
        {
            airportDB = a;
        }

        public void openDB(PlanesDB p)
        {
            planeDB = p;
        }

        public void closeFlightsDB()
        {
            flightDB = null;
        }

        public void closeAirportsDB()
        {
            airportDB = null;
        }

        public void closePlanesDB()
        {
            planeDB = null;
        }

        public void readFlight(int ID)
        {
            if (flightDB != null)
            {
                Flight f = CRUDFlight.getFlight(this.flightDB, ID);
                if (f != null) Console.WriteLine(f.ToString());
                else Console.WriteLine("The flight with this ID wasn't found!");
            }
            else
                Console.WriteLine("The DB of the flights wasn't open!");
        }

        public void readAirport(string name)
        {
            if (airportDB != null)
            {
                Airport a = CRUDAirport.getAirport(this.airportDB, name);
                if (a != null) Console.WriteLine(a.ToString());
                else Console.WriteLine("The airport with this name wasn't found!");
            }
            else
                Console.WriteLine("The DB of the airports wasn't open!");
        }

        public void readPlanes(int id)
        {
            if (planeDB != null)
            {
                Plane p = CRUDPlanes.getPlane(this.planeDB, id);
                if (p != null) Console.WriteLine(p.ToString());
                else Console.WriteLine("The plane with this ID wasn't found!");
            }
            else
                Console.WriteLine("The DB of the planes wasn't open!");
        }
    }
}
