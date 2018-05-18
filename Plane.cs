using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerocompany
{
    class Plane
    {

        private int passangers;
        private string name;
        private int id;

        public Plane(string n, int cap)
        {
            this.name = n;
            this.passangers = cap;
            this.id = id++;
        }

        public override string ToString()
        {
            return "ID: " + id + "; Name: " + name + "; Capacity: " + passangers + ".\n";
        }

        public int getCapacity
        {
            get { return passangers; }
        }

        public int getID
        {
            get { return id; }
        }

        public string getName
        {
            get { return name; }
        }
    }
}
