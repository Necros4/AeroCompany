using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class AirportsDB
    {
        private List<Airport> airportsList;
        private string name;

        public AirportsDB(string name)
        {
            this.airportsList = new List<Airport>();
            this.name = name;
        }

        public string getName
        {
            get { return name; }
        }

        public List<Airport> getAirports
        {
            get { return airportsList; }
        }

        public void add(Airport a)
        {
            airportsList.Add(a);
        }

        public void delete(Airport a)
        {
            airportsList.Remove(a);
        }
    }
}
