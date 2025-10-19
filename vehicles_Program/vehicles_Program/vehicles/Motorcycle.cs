using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicles_Program.vehicles
{
    public class Motorcycle:vehicle
    {
        public bool Kick_Starter { get; set; }

        public override double Rental_price()
        {
            return 100 * (MaxSpeed % 2);

        }
    }
}
