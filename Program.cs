using System;
using System.Linq;

namespace brenoExampleCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string vehicleDisplay = GetVehicleInformation(args[0]);
            Console.WriteLine(vehicleDisplay);
        }

/// <summary>
/// Takes a vehicle number and returns the year, make, model, VIN, and owner
/// </summary>
        private string GetVehicleInformation(string vehicleNumber)
        {
            /// gets the vehicle from a list of vehicles on the container for the insurance policy, based on its primary key
            Vehicle vehicle = TheContainer.Vehicles.Values.FilterActive().First(vehicle => vehicle.VehicleNum = vehicleNumber.ToInt32());

            /// returns an owner object. returns null if an owner is not found.
            Person owner = GetOwnerByVIN(vehicle.VIN);

            string result = $"{vehicle.Year} {vehicle.Make} {vehicle.Model}" + Environment.NewLine + vehicle.VIN 
                + Environment.NewLine
                + owner.FirstName + " " + owner.LastName;

            return result;
        }
    }
}
