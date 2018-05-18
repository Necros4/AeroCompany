using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class Airport
    {
        private string name;

        public Airport(string n)
        {
            this.name = n;
        }

        public Airport() 
        {
            name = string.Empty;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return "Airport name is: " + name + "\n";
        }
    }
}
