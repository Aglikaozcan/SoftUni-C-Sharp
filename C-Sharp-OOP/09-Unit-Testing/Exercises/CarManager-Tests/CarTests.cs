using CarManager;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldInitializeCorrectly()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            Assert.AreEqual(make, car.Make);
            Assert.AreEqual(model, car.Model);
            Assert.AreEqual(fuelConsumption, car.FuelConsumption);
            Assert.AreEqual(fuelCapacity, car.FuelCapacity);
        }

        [Test]
        public void ModelShouldThrowArgumentExceptionWhenNameIsNull()
        {
            string make = "VW";
            string model = null;
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void MakeShouldThrowArgumentExceptionWhenNameIsNull()
        {
            string make = null;
            string model = "Golf";
            double fuelConsumption = 2;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenIsBelowZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = -10;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        public void FuelConsumptionShouldThrowArgumentExceptionWhenIsZero()
        {
            string make = "VW";
            string model = "Golf";
            double fuelConsumption = 0;
            double fuelCapacity = 100;

            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }

        [Test]
        [TestCase(null, "Golf", 10, 100)]
        [TestCase("VW", "Golf", 10, 100)]
        [TestCase("VW", "Golf", -10, 100)]
        [TestCase("VW", "Golf", 0, 100)]
        [TestCase("VW", "Golf", 10, -20)]
        [TestCase("VW", "Golf", 10, 0)]
        public void AllPropertiesShouldThrowArgumentExceptionForInvalidValues(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, model, fuelConsumption, fuelCapacity));
        }
    }
}