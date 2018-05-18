using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class PlanesDB
    {
        private List<Plane> planeList;
        private string name;

        public PlanesDB(string name)
        {
            this.planeList = new List<Plane>();
            this.name = name;
        }

        public string getName
        {
            get { return name; }
        }

        public List<Plane> getPlanes
        {
            get { return planeList; }
        }

        public void add(Plane f)
        {
            planeList.Add(f);
        }

        public void delete(Plane f)
        {
            planeList.Remove(f);
        }
    }
}
