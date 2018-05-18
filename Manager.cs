using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class Manager
    {
        private string name;
        private AirportsDB airportDB;
        private PlanesDB planeDB;

        public Manager(string name)
        {
            this.name = name;
        }

        public string getName
        {
            get { return name; }
        }

        public void openDB(AirportsDB a)
        {
            airportDB = a;
        }

        public void closeAirportsDB()
        {
            airportDB = null;
        }

        public void createAirport(Airport a)
        {
            if (airportDB != null)
            {
                CRUDAirport.createAirport(this.airportDB, a);
            }
            else
                Console.WriteLine("The DB of the airports wasn't open!");
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

        public void updateAirport(string name, Airport newAirport)
        {
            if (airportDB != null)
            {
                CRUDAirport.updateAirport(this.airportDB, name, newAirport);
            }
            else
                Console.WriteLine("The DB of the airports wasn't open!");
        }

        public void deleteAirport(string name)
        {
            if (airportDB != null)
            {
                CRUDAirport.deleteAirport(this.airportDB, name);
            }
            else
                Console.WriteLine("The DB of the airports wasn't open!");
        }

        public void openDB(PlanesDB p)
        {
            planeDB = p;
        }

        public void closePlanesDB()
        {
            planeDB = null;
        }

        public void createPlane(Plane f)
        {
            if (planeDB != null)
            {
                CRUDPlanes.createPlane(this.planeDB, f);
            }
            else
                Console.WriteLine("The DB of the planes wasn't open!");
        }

        public void readPlane(int ID)
        {
            if (planeDB != null)
            {
                Plane f = CRUDPlanes.getPlane(this.planeDB, ID);
                if (f != null) Console.WriteLine(f.ToString());
                else Console.WriteLine("The plane with this ID wasn't found!");
            }
            else
                Console.WriteLine("The DB of the planes wasn't open!");
        }

        public void updatePlane(int ID, Plane newPlane)
        {
            if (planeDB != null)
            {
                CRUDPlanes.updatePlane(this.planeDB, ID, newPlane);
            }
            else
                Console.WriteLine("The DB of the planes wasn't open!");
        }

        public void deletePlane(int ID)
        {
            if (planeDB != null)
            {
                CRUDPlanes.deletePlane(this.planeDB, ID);
            }
            else
                Console.WriteLine("The DB of the planes wasn't open!");
        }
    }
}
