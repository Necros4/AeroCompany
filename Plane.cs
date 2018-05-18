using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class Plane
    {
        static private int globalID = 1;

        private int capacity;
        private string name;
        private int id;

        public Plane(string n, int cap)
        {
            this.name = n;
            this.capacity = cap;
            this.id = globalID++;
        }

        public int Capacity
        {
            get { return capacity; }
            set { if (value > 0) capacity = value; }
        }

        public int ID
        {
            get { return id; }
            set { if (value > 0) id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return "ID of the plane: " + id + "; Name: " + name + "; Capacity: " + capacity + ".\n";
        }
    }
}
