using System;

namespace _07._Speed_Racing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumption = fuelConsumption;
            this.TraveledDistance = 0;
        }

        public string Model { get; set; }

        public double FuelAmount { get; set; }

        public double FuelConsumption { get; set; }

        public int TraveledDistance { get; set; }

        public void CheckFuel(int traveledDistance)
        {
            if (FuelAmount - traveledDistance * FuelConsumption >= 0)
            {
                FuelAmount -= traveledDistance * FuelConsumption;
                TraveledDistance += traveledDistance;
            }

            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }

        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TraveledDistance}".ToString();
        }
    }
}
