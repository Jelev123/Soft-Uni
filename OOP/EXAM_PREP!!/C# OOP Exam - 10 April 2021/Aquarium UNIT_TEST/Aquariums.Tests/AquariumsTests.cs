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
        private Fish fish;

        [SetUp]
        public void SetUp()
        {
            aquarium = new Aquarium(name, capacity);
        }

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
        public void Ctor_AquariumProperlySetNameAndCapacity()
        {
            aquarium = new Aquarium("Ribite", 10);
            Assert.That(aquarium.Name, Is.EqualTo("Ribite"));
            Assert.That(aquarium.Capacity, Is.EqualTo(10));
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

            Fish firstFish = new Fish("Ivan");
            Fish secondFish = new Fish("Gosho");
            aquarium = new Aquarium("Ribite", 1);
            aquarium.Add(firstFish);
            Assert.Throws<InvalidOperationException>(() => aquarium.Add(secondFish));
        }

        [Test]
        public void RemoveShouldThrowExceptionIfIsNull()
        {
            fish = new Fish("Pesho");
            aquarium = new Aquarium("Ribite", 5);
            aquarium.Add(fish);
            Assert.That(aquarium.Count, Is.EqualTo(1));
            aquarium.RemoveFish("Pesho");
            Assert.That(aquarium.Count, Is.EqualTo(0));
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
