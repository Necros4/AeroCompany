using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aerocompany
{
    class Myclass
    {
        static void Main(string[] args)
        {
            AeroCompany company = new AeroCompany("F-Air");

            Plane f1 = new Plane("F-22", 82);
            company.addPlane(f1);
            Plane f2 = new Plane("F-14", 90);
            company.addPlane(f2);
            Plane f3 = new Plane("F-69 VTOL", 90);
            company.addPlane(f3);

            Flight fl1 = new Flight(new Airport("New York"), new Airport("Tokyo"), f2, new DateTime(2019, 11, 7, 8, 30, 0));
            company.createFlight(fl1);

            Flight fl2 = new Flight(new Airport("Boryspil"), new Airport("Beijing"), f1, new DateTime(2020, 1, 8, 11, 30, 0));
            company.createFlight(fl2);

        }
    }
}
