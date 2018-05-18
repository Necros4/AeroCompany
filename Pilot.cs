using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class Pilot
    {
        private string name;
        private FlightDB flightDB;

        public Pilot(string name)
        {
            this.name = name;
        }

        public string getName
        {
            get { return name; }
        }

        public void openDB(FlightDB f)
        {
            flightDB = f;
        }

        public void closeDB()
        {
            flightDB = null;
        }

        public void createFlight(Flight f)
        {
            if (flightDB != null)
            {
                CRUDFlight.createFlight(this.flightDB, f);
            }
            else
                Console.WriteLine("The DB of the flights wasn't open!");
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

        public void updateFlight(int ID, Flight newFlight)
        {
            if (flightDB != null)
            {
                CRUDFlight.updateFlight(this.flightDB, ID, newFlight);
            }
            else
                Console.WriteLine("The DB of the flights wasn't open!");
        }

        public void deleteFlight(int ID)
        {
            if (flightDB != null)
            {
                CRUDFlight.deleteFlight(this.flightDB, ID);
            }
            else
                Console.WriteLine("The DB of the flights wasn't open!");
        }
    }
}
