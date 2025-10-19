using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using vehicles_Program.vehicles;


namespace vehicles_Program.Vehicle_Service
{
    public class VehicleService
    {
        Dictionary<string, List<vehicle>> Vehiclesb_byType;
        public VehicleService()
        {
            Vehiclesb_byType = new Dictionary<string, List<vehicle>>();
        }
        public static IEnumerable<string> get_Vehicl_Names()
        {
            return typeof(vehicle).Assembly.GetTypes()
                .Where(t => t.IsClass && t.IsSubclassOf(typeof(vehicle)))
                .Select(t => t.Name).ToList();
        }

        public void AddVehicle(string vehicleType, vehicle vehicle)
        {
            if (!Vehiclesb_byType.ContainsKey(vehicleType))
            {
                Vehiclesb_byType[vehicleType] = new List<vehicle>();
            }
            Vehiclesb_byType[vehicleType].Add(vehicle);


        }
        public void InjectVehicle(string typechose)
        {
            var assemple = typeof(vehicle).Assembly;
            var vehicleType = assemple.GetTypes().Where(x=>x.IsSubclassOf(typeof(vehicle)));
            Type type = vehicleType.FirstOrDefault(y => y.Name.Equals(typechose,StringComparison.OrdinalIgnoreCase));  
            vehicle vehicle = (vehicle)Activator.CreateInstance(type);
            foreach (var prop in vehicle.GetType().GetProperties())
            {
                {
                    Console.WriteLine($"Enter Value of {prop.Name}");
                    string value_prop = Console.ReadLine();
                    object value = Convert.ChangeType(value_prop, prop.PropertyType);
                    prop.SetValue(vehicle, value);

                }


            }
                AddVehicle(typechose, vehicle);
        }
        public void ShowVehicles()
        {
                if (Vehiclesb_byType.Count ==0 )
                {
                    Console.WriteLine("Empty Sorry");
                return;
                }
            foreach (var Vehicle in Vehiclesb_byType)
            {
                Console.WriteLine($"\n== {Vehicle.Key} ===");
                foreach (var item in Vehicle.Value)
                {

                    var properts = item.GetType().GetProperties();
                    foreach (var prop in properts)
                    {
                        Console.Write($"{prop.Name}: {prop.GetValue(item)} |");
                    }
                    Console.WriteLine();

                }
                Console.WriteLine();
            }


        }
        public void Searching(string brand)
        {

            vehicle result = null ;
            foreach (var vehicl in Vehiclesb_byType.Values)
            {
                result = vehicl.FirstOrDefault(x => x.Brand.Equals(brand,StringComparison.OrdinalIgnoreCase));
                if (result != null)
                    break;
            }

            if (result == null)
            {
                Console.WriteLine("Not Fuond");
                    return ; 
            }
            

            foreach (var prop in result.GetType().GetProperties())
            {
                Console.Write($"{prop.Name}: {prop.GetValue(result)}, ");
            }
            Console.WriteLine();
        }
        public void Remover(int id)
        {
            bool Check = false;
            foreach (var vehicl in Vehiclesb_byType.Values)
            {
               
                var result = vehicl.FirstOrDefault(x => x.Id == id);
                if (result!=null)
                {

                    vehicl.Remove(result);
                    Console.WriteLine($"{id} is remove");
                    Check = true;
                    break;
                }
            }
            if (!Check)
            {
                Console.WriteLine("This id Not found");
            }

        }

        public double showrental_price(int id)
        { 
            var Result = Vehiclesb_byType.Values.SelectMany(x=>x).FirstOrDefault(x => x.Id == id);

            if (Result == null)
            {
                Console.WriteLine("Vichl not found");
                return 0;

            }
            else
                return Result.Rental_price();
        }
    }

}
