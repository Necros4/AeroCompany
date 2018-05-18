using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class Flight
    {
        private static int globalID = 1;

        private DateTime flightTime;
        private Airport source, destination;
        private int id;
        private Plane plane;

        public Flight(Airport s, Airport d, Plane p, DateTime date)
        {
            this.id = globalID++;
            this.source = s;
            this.destination = d;
            this.plane = p;
            this.flightTime = date;
        }

        public int getID
        {
            get { return id; }
        }

        public Plane Plane
        {
            get { return plane; }
            set { if (value != null) plane = value; }
        }

        public Airport Source
        {
            get { return source; }
            set { if (value != null) source = value; }
        }

        public Airport Destination
        {
            get { return destination; }
            set { if (value != null) destination = value; }
        }

        public DateTime FlightTime
        {
            get { return flightTime; }
            set { if (value != null) flightTime = value; }
        }

        public string ToShortString()
        {
            return "ID of the Flight: " + id + "; Source: " + source.Name + "; Destination: "
                + destination.Name + "; FlightTime: " + flightTime.ToString() + ".\n";
        }

        public override string ToString()
        {
            return "ID of the Flight: " + id + "; Plane: " + plane.ID + "; Source: " + source.Name + "; Destination: " 
                + destination.Name + "; FlightTime: " + flightTime.ToString() + ".\n";
        }

        public override bool Equals(object obj)
        {
            try
            {
                Flight f = (Flight)obj;
                if (f.Source == this.Source && f.Destination == this.Destination &&
                    f.Plane == this.Plane && f.FlightTime == this.FlightTime) return true;
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Not comparable values! Original message:" + ex.Message);
                return false;
            }
        }
    }
}
