using vehicles_Program.vehicles;
using vehicles_Program.Vehicle_Service;

namespace vehicles_Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            VehicleService vehicleService = new VehicleService();
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("        Vehicle Management System         ");
            Console.WriteLine("==========================================\n");
           ;
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("══════════════════════════════════════════");
                Console.WriteLine("              MAIN MENU");
                Console.WriteLine("══════════════════════════════════════════");

                Console.WriteLine("\n=========== Chose ====================== : ");
                Console.WriteLine("1 for Add Vehicle");
                Console.WriteLine("2 for Show Vehicle");
                Console.WriteLine("3 Searching_By_Brand ");
                Console.WriteLine("4 for Remove_Vehicle");
                Console.WriteLine("5 for Print_Rental_price_By_Id");
                Console.WriteLine("0 for Exit");

                Console.WriteLine("---------------------------------------------");

                string Chose = Console.ReadLine();

                switch (Chose)
                {
                    case "1":
                        Console.WriteLine("\n══════════════════════════════════════");
                        Console.WriteLine("       Choose Vehicle Type to Add      ");
                        Console.WriteLine("══════════════════════════════════════");
                        var vehicleTypes = VehicleService.get_Vehicl_Names();
                        foreach (var vehicleType in vehicleTypes)
                            Console.WriteLine($"-----{vehicleType}");

                        Console.Write("Enter type name: ");
                        string typeOfvehicle = Console.ReadLine();
                        vehicleService.InjectVehicle(typeOfvehicle);
                        break;

                    case "2":
                        Console.WriteLine("\n══════════════════════════════════════");
                        Console.WriteLine("           All Registered Vehicles      ");
                        Console.WriteLine("══════════════════════════════════════");
                        vehicleService.ShowVehicles();
                        break;

                    case "3":
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Enter Brand : ");
                        var  Brand = Console.ReadLine();
                        Console.WriteLine("\n══════════════════════════════════════");
                        Console.WriteLine("           Result for search      ");
                        Console.WriteLine("══════════════════════════════════════");
                        vehicleService.Searching(Brand);
                        break;
                    case "4":
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Enter Id :");
                        var Id = Console.ReadLine();
                        vehicleService.Remover(int.Parse(Id));
                        break;
                    case "5":
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("Enter Id :");
                        var ID_Vechicle = Console.ReadLine();
                        Console.WriteLine("\n══════════════════════════════════════");
                        Console.WriteLine("           Price:      ");
                        Console.WriteLine("══════════════════════════════════════");
                        var price = vehicleService.showrental_price(int.Parse(ID_Vechicle));
                        if (price == 0)
                        {
                            Console.WriteLine("Try again");
                            break;
                        }
                        Console.WriteLine($"Rental_price => {price}");
                        break;
                    case "0":
                        Console.WriteLine("---------------------------------------------");
                        Console.WriteLine("\nThank you for using the Vehicle System!");
                        Console.WriteLine("==========================================");
                        return;
                    default:
                        Console.WriteLine("Enter Number in range (1,2,3,4,5)");
                        break;


                }
            }




        }
    }
}
