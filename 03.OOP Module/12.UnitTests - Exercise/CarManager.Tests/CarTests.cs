
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
        public void CarClassShouldSetValuesThroughConstructorIfTheyAreValid()
        {
            Car car = new Car("Audi", "A6", 3, 20);
            Assert.AreEqual("Audi", car.Make);
            Assert.AreEqual("A6", car.Model);
            Assert.AreEqual(3, car.FuelConsumption);
            Assert.AreEqual(20, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [TestCase("")]
        [TestCase(null)]
        public void CarClassShouldThrowExceptionIfMakeIsInvalid(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "A6", 3, 20));
        }

        [TestCase("")]
        [TestCase(null)]
        public void CarClassShouldThrowExceptionIfModelIsInvalid(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("Audi", model, 3, 20));
        }

        [TestCase(0)]
        [TestCase(-6)]
        public void CarClassShouldThrowExceptionIfFuelConsumptionIsInvalid(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("Audi", "A6", fuelConsumption, 20));
        }
        [Test]
        public void CarClassShouldChangeAmountPropertyIfUseMethodRefuelOrDrive()
        {
            var car = new Car("Audi", "A6", 5, 20);
            car.Refuel(10);
            car.Drive(200);
            Assert.AreEqual(0, car.FuelAmount) ;
        }

        [TestCase(0)]
        [TestCase(-6)]
        public void CarClassShouldThrowExceptionIfFuelCapacityIsNegative(double capacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("Audi", "A6", 5, capacity));
        }

        [Test]
        [TestCase(12)]
        [TestCase(0.1)]
        [TestCase(0.0001)]
        [TestCase(50)]
        public void RefuelMethodShouldWorkCorrectlyWhenFuelAmountIsZero(double refuel)
        {
            var car = new Car("Audi", "A6", 8.5, 80);
            car.Refuel(refuel);
            Assert.AreEqual(refuel, car.FuelAmount);
        }
        [TestCase(0)]
        [TestCase(-6)]
        public void CarRefuelMethodShouldThrowExceptionIfAmountIsZeroOrNegative(double amount)
        {
            var car = new Car("Audi", "A6", 5, 20);
            Assert.Throws<ArgumentException>(() => car.Refuel(amount));
        }

        [Test]
        public void CarDriveMethodShouldThrowArgumentExceptionIfTryDriveMoreThanICan()
        {
            var car = new Car("Audi", "A6", 5, 20);
            car.Refuel(10);
            Assert.Throws<InvalidOperationException>(() => car.Drive(201));
        }
    }
}