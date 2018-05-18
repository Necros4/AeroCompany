using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aero
{
    class CRUDPlanes
    {
        public static void createPlane(PlanesDB pdb, Plane plane)
        {
            if (isPlaneInList(pdb, plane))
                Console.WriteLine("This plane has been already in the " + pdb.getName + "!");
            else
            {
                pdb.add(plane);
                Console.WriteLine("The plane was succesfully added to the " + pdb.getName + " with the #" + plane.ID);
            }
        }

        public static void deletePlane(PlanesDB pdb, int ID)
        {
            Plane plane = getPlane(pdb, ID);
            if (plane != null && isPlaneInList(pdb, plane))
            {
                pdb.delete(plane);
                Console.WriteLine("Plane with #" + ID + " was succesfully removed from the " + pdb.getName + "!");
            }
            else
                Console.WriteLine("Check the ID! The " + pdb.getName + "isn't have such ID of a plane!");
        }

        public static void updatePlane(PlanesDB pdb, int planeID, Plane newPlane)
        {
            Plane p = getPlane(pdb, planeID);
            if (p != null)
            {
                p.ID = newPlane.ID;
                p.Name = newPlane.Name;
                p.Capacity = newPlane.Capacity;
            }
            else
                Console.WriteLine("Can't find plane with such ID! Check the ID of plane!");
        }

        public static Plane getPlane(PlanesDB pdb, int ID)
        {
            foreach (Plane p in pdb.getPlanes)
                if (p.ID == ID)
                    return p;
            return null;
        }

        private static bool isPlaneInList(PlanesDB pdb, Plane plane)
        {
            foreach (Plane p in pdb.getPlanes)
                if (p == plane)
                    return true;
            return false;
        }
    }
}
