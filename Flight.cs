using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerocompany
{
    class Flight
    {
        private static int globalID = 1;

        private DateTime flightTime;
        private Airport source, destination;
        private Plane plane;

        public Flight(Airport s, Airport d, Plane p, DateTime date)
        {
            this.source = s;
            this.destination = d;
            this.plane = p;
            this.flightTime = date;
        }

        public string ToShortString()
        {
            return " Source: " + source.getName + "; Destination: "
                + destination.getName + "; FlightTime: " + flightTime.ToString() + ".\n";
        }

        public override string ToString()
        {
            return "; Plane: " + plane.getID + "; Source: " + source.getName + "; Destination: "
                + destination.getName + "; FlightTime: " + flightTime.ToString() + ".\n";
        }

        public Plane getPlane
        {
            get { return plane; }
        }

        public Airport getSource
        {
            get { return source; }
        }

        public Airport getDestination
        {
            get { return destination; }
        }

        public DateTime getFlightTime
        {
            get { return flightTime; }
        }

    }
}
