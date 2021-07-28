using System;
using NUnit.Framework;

namespace Tests
{
    public class CarTests
    {

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("make", "model", 10, 63)]
        public void ConstructorInitCorrectly(string make
            , string model
            , double fuelConsumption
            , double fuelCapacity)
        {
            Car car = new Car(make: make,
                model: model, 
                fuelConsumption: fuelConsumption, 
                fuelCapacity: fuelCapacity);

            Assert.AreEqual(car.Model, model);
            Assert.AreEqual(car.Make, make);
            Assert.AreEqual(car.FuelCapacity, fuelCapacity);
            Assert.AreEqual(car.FuelConsumption, fuelConsumption);

        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ConstructorShouldThrowExcpetionWhenMakeIsEmptyOrNull(string make)
        {
            Assert.Throws<ArgumentException>((() =>
                new Car(make,"model",10,63)));
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void ConstructorShouldThrowExcpetionWhenModelIsEmptyOrNull(string model)
        {
            Assert.Throws<ArgumentException>((() => new Car("make"
                , model, 10, 63)));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorShouldThrowExcpetionWhenFuelConsumtionIsBelowZero(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>((() => new Car("make","model",fuelConsumption,63)));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorShouldThrowExcpetionWhenFuelCapacityIsBelowZero(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>((() => new Car("make", "model", 10, fuelCapacity)));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void ConstructorShouldThrowExcpetionWhenRefuelIsBelowOrEqualZero(double value)
        {
            Car car = new Car("make", "model", 10, 10);
            Assert.Throws<ArgumentException>((() => car.Refuel(value)));
        }

        [Test]
        [TestCase(100,50,50)]
        [TestCase(200,350,200)]
        public void RefuelShouldWorksAsExpected(double capacity,double fuel,double expectedFuel)
        {
            Car car = new Car("make", "model", 10, 10);

            car.Refuel(fuel);

        }

        [Test]
        [TestCase(10,100,50,5)]
        public void DriveShouldReducedFuel(double fuelConsumption,double fuel,double km,double fuelAmountLeft)
        {
            Car car = new Car("make", "model", fuelConsumption, 10);
            car.Refuel(fuel);

            car.Drive(km);

            var expected = fuelAmountLeft;
            var actual = car.FuelAmount;

            Assert.AreEqual(expected,actual);

        }
    }
}