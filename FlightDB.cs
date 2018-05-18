﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class FlightDB
    {
        private List<Flight> flightList;
        private string name;

        public FlightDB(string name)
        {
            this.flightList = new List<Flight>();
            this.name = name;
        }

        public string getName
        {
            get { return name; }
        }

        public List<Flight> getFlights
        {
            get { return flightList; }
        }

        public void add(Flight f)
        {
            flightList.Add(f);
        }

        public void delete(Flight f)
        {
            flightList.Remove(f);
        }
    }
}
