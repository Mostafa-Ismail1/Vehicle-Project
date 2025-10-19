using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicles_Program.vehicles
{
    public class Truck:vehicle
    {

        public  int Number_of_trailer{ get; set; }
        public override double Rental_price()
        {
            return 400*Number_of_trailer +(MaxSpeed);

        }

    }
}
