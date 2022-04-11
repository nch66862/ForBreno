using System;
using System.Linq;
using System.Collections.Generic;

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

        /// you will need to know the difference between value and reference data types.
        private void YouWillAlsoNeedToKnowWhatAVariableWillHold()
        {

            // this usuall makes sense
            int numOne = 50;
            int numTwo = numOne; //numTwo=numOne=50
            numOne = 100;
            Console.WriteLine(numOne); //outputs 100
            Console.WriteLine(numTwo); //outputs 50

            // this is what to watch out for
            List<string> object1 = new List<string>(){"one", "two", "three"};
            List<string> object2 = object1;

            //updating object1,
            object1[2] = "five";

            // object 2 is also updated because they are pointing to the same address in memory.
            Console.WriteLine(object2);
        }
    }
}
