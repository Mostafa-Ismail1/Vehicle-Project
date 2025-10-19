using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicles_Program.vehicles
{
  

    public class Car:vehicle
    {

        public bool Sunroof { get; set; }

        public override double Rental_price()
        {
            if (Year > 2018)
                return 1000 * (MaxSpeed);
            else
                return 500 * (MaxSpeed);


        }

    }
}
