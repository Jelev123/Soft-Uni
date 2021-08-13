using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Computers.Tests
{
    public class Tests
    {
        private ComputerManager computerManager;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            this.computerManager = new ComputerManager();
            this.computer = new Computer("HP", "ProBook", 1000);
        }

        [Test]
        public void Ctor_InitializesCollection()
        {
            Assert.That(this.computer, Is.Not.Null);
        }

        [Test]
        public void Prop_ReturnsCollectionAsReadOnly()
        {
            Assert.IsInstanceOf<IReadOnlyCollection<Computer>>(this.computerManager.Computers);
        }

        [Test]
        public void AddComputer_ThrowsException_WhenComputerIsNull()
        {
            Computer computer = null;

            Assert.Throws<ArgumentNullException>(() => this.computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputer_ThrowsException_WhenComputerIsAlreadyExists()
        {
            this.computerManager.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => this.computerManager.AddComputer(computer));
        }

        [Test]
        public void AddComputer_AddsComputer_WhenAddIsValidOperation()
        {
            this.computerManager.AddComputer(computer);

            int expectedCount = 1;

            Assert.AreEqual(expectedCount, this.computerManager.Count);
        }

        [Test]
        [TestCase(null, null)]
        public void RemoveComputer_ThrowsException_WhenManufacturerAndModelAreNull(string manufacturer, string model)
        {
            this.computerManager.AddComputer(computer);

            Assert.Throws<ArgumentNullException>(() => this.computerManager.RemoveComputer(manufacturer, model));
        }

        [Test]
        public void RemoveComputer_RemovesComputer_WhenRemoveIsValidOperation()
        {
            this.computerManager.AddComputer(computer);

            var expectedResult = computer;

            Assert.AreEqual(expectedResult, this.computerManager.RemoveComputer(this.computer.Manufacturer, this.computer.Model));
        }

        [Test]
        [TestCase(null, null)]
        public void GetComputer_ThrowsException_WhenManufacturerAndModelAreNull(string manufacturer, string model)
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputer(manufacturer, model));
        }

        [Test]
        public void GetComputer_ThrowsException_WhenComputerIsNull()
        {
            Assert.Throws<ArgumentException>(() => this.computerManager.GetComputer("HP", "HP"));
        }

        [Test]
        public void GetComputer_ReturnsComputer_WhenGetComputerIsValidOperation()
        {
            this.computerManager.AddComputer(computer);
            var actualResult = this.computer;
            var expectedResult = this.computerManager.GetComputer(this.computer.Manufacturer, this.computer.Model);

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        [Test]
        public void GetComputersByManufacturer_ThrowsException_WhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => this.computerManager.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturer_ReturnsComputers_WhenIsValidOperation()
        {
            this.computerManager.AddComputer(computer);
            this.computerManager.AddComputer(new Computer("Lenovo", "Thinkpad", 1003));

            var actualResult = this.computerManager.GetComputersByManufacturer("Lenovo");

            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult.Count);
        }
    }
}