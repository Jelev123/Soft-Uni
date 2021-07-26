using System;
using NUnit.Framework;




namespace Tests
{
    public class DatabaseTests
    {
        

        private Database database;
        private readonly int[] initialData = new int[] {1, 2};

        [SetUp]
        public void Setup()
        {
            this.database = new Database(initialData);
        }

        [Test]
        public void If_Work_Corecktly()
        {
            int[] data = new int[] {1, 2, 3};
            this.database = new Database(data);

            int expectedCont = data.Length;
            int actualyCount = this.database.Count;

            Assert.AreEqual(expectedCont,actualyCount);
        }

        [Test]
        public void Constructor_Throw_Exceptins_When_Is_Bigger()
        {
            int[] data = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17};

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.database = new Database(data);

            });



        }

        [Test]

        public void Add_Should_Increase_Count_When_Added_Succesfuly()
        {
            this.database.Add(3);

            int expectedCount = 3;
            int actualCount = this.database.Count;

            Assert.AreEqual(expectedCount,actualCount);
        }

        [Test]
        public void Thrown_Exceptio_When_Is_Full()
        {
            for (int i = 3; i <= 16; i++)
            {
                database.Add(i);
            }

            Assert.Throws<InvalidOperationException>((() =>
            {
                database.Add(17);
            }));
        }

        [Test]

        public void Should_Support_Only_Removing_An_Element()
        {
            int expected = 1;

            database.Remove();

            int actual = database.Count;

            Assert.AreEqual(expected,actual);
        }

        [Test]
        public void Throw_Exception_When_Data_Is_Empty()
        {
            database.Remove();
            database.Remove();

            Assert.Throws<InvalidOperationException>((() =>
            {
                database.Remove();
            }));
        }

        [Test]
        public void Fetch_Should_Return_Coppy()
        {

            int[] data = new int[] {1, 2, 3,};
            database = new Database(data);

            int[] actualData = this.database.Fetch();

            Assert.AreEqual(data,actualData);
        }
    }
}