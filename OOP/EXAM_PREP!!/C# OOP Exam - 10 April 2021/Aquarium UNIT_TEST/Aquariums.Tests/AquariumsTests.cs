using System.Collections.Generic;
using NUnit.Framework;

namespace Aquariums.Tests
{
    using System;

    public class AquariumsTests
    {
        private string name = "Aquamen";
        private int capacity = 10;
        private Aquarium aquarium;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium(name, capacity);
        }

        //[Test]
        //public void NameShouldReturnsName()
        //{
        //    Assert.AreEqual(name,aquarium.Name);
        //}

        //[Test]
        //public void CapacityShouldReturnCapacity()
        //{
        //    Assert.AreEqual(capacity,aquarium.Capacity);
        //}

        [Test]
        [TestCase("")]
        [TestCase(null)]
        public void NameShouldThrowExceptionWhenIsNullOrWhiteSpace(string name)
        {
            Assert.Throws<ArgumentNullException>((() => new Aquarium(name, capacity)));
        }

        [Test]
        [TestCase(-1)]
        public void CapacityShouldThrowExceptionWhesIsUnderZero(int capacity)
        {
            Assert.Throws<ArgumentException>((() => new Aquarium(name, capacity)));
        }

        [Test]
        public void CountIncreasesWhenAddFish()
        {
            int count = 5;

            for (int i = 0; i < count; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }

            Assert.AreEqual(count, aquarium.Count);
        }

        [Test]
        public void AddShouldThrowExceptionWhenIsFull()
        {
         
            for (int i = 0; i < 10; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }

            Assert.Throws<InvalidOperationException>((() => aquarium.Add(new Fish("name"))));
        }

        [Test]
        public void RemoveShouldThrowExceptionIfIsNull()
        {
            for (int i = 0; i < 10; i++)
            {
                aquarium.Add(new Fish($"{i}"));
            }

            Assert.Throws<InvalidOperationException>((() => aquarium.RemoveFish("name")));
        }

        [Test]
        public void SellFishReturnsFish()
        {
            Fish fish = new Fish("Petko");

            aquarium.Add(fish);

            Fish returnedFish = aquarium.SellFish(fish.Name);

            Assert.AreEqual(returnedFish, fish);
        }

        [Test]
        public void ReportMethodWorks()
        {
            List<string> fishList = new List<string>() { "Ivo", "Petko", "Stefcho" };

            foreach (string fish in fishList)
            {
                aquarium.Add(new Fish(fish));
            }

            string expected = $"Fish available at {aquarium.Name}: {string.Join(", ", fishList)}";

            string actual = aquarium.Report();

            Assert.AreEqual(expected, actual);
        }
    }
}
