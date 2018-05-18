using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerocompany
{
    class Airport
    {
        private string name;

        public Airport(string name)
        {
            this.name = name;
        }

        public Airport()
        {
            name = string.Empty;
        }

        public string getName
        {
            get { return name; }
        }

        public override string ToString()
        {
            return "Airport: " + name + "\n";
        }
    }
}
