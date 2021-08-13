using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Presents.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class PresentsTests
    {
        private Bag bag;

        [SetUp]

        public void SetUp()
        {
            bag = new Bag();
        }

        [Test]
        public void ConstructorInitializer()
        {
            Assert.That(bag, Is.Not.Null);
        }


        [Test]
        [TestCase(null)]
        public void CreateShouldThrowExceptionWhenPresentIsNull(Present present)
        {
            Assert.Throws<ArgumentNullException>((() => bag.Create(present)));

        }

        [Test]
        public void CreateShuldThrowExceptionWhenPresentAllreadyExist()
        {
            Present present = new Present("name", 200);
            bag.Create(present);

            Assert.Throws<InvalidOperationException>((() => bag.Create(present)));
        }

        [Test]
        public void CreatAddPresent()
        {
            Present present = new Present("anme", 25.5);
            bag.Create(present);

            Assert.That(present, Is.EqualTo(bag.GetPresent(present.Name)));
        }

        [Test]
        public void ReturnMessage()
        {
            Present present = new Present("anme", 25.5);
            string expected = $"Successfully added present {present.Name}.";

            string actual = bag.Create(present);

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void RemovePresentFromTheBag()
        {
            Present present = new Present("name", 100);
            bag.Create(present);
            bag.Remove(present);

            Assert.That(bag.GetPresent(present.Name), Is.Null);
        }

        [Test]
        public void GetPresentWithLeastMagic()
        {
            Present presentOne = new Present("name", 200);
            Present presentTwo = new Present("asd", 12);
            Present presentThree = new Present("dsa", 15);

            bag.Create(presentOne);
            bag.Create(presentTwo);
            bag.Create(presentThree);

            Assert.That(presentTwo, Is.EqualTo(bag.GetPresentWithLeastMagic()));
        }

        [Test]
        public void GetPresenstReturnPresent()
        {
            Present present = new Present("name", 200);
            bag.Create(present);

            Assert.AreEqual(present, bag.GetPresent(present.Name));
        }

        [Test]
        public void GetPresentsAsReadOnly()
        {
            Assert.That(bag.GetPresents(), Is.InstanceOf<IReadOnlyCollection<Present>>());
        }
    }
}
