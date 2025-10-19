using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vehicles_Program.vehicles
{
   
    public class vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; }

        public string Model { get; set; }

        public int Year { get;  set; }=DateTime.Now.Year;

        public float MaxSpeed { get; set; } = 0f;


        public virtual double Rental_price()
        {
            return 0;
        }




    }
}
