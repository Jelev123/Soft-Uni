using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            bankVault = new BankVault();
        }

        [Test]
        public void ConstructorInitialize()
        {
            Assert.That(bankVault.VaultCells,Is.Not.Null);
        }

        [Test]
        public void DictionaryCountIsTwelve()
        {
            Assert.AreEqual(bankVault.VaultCells.Count, 12);
        }

        [Test]
        public void AddShouldThrowExceptionWhenCellDoesntContains()
        {
            Item item = new Item("Pesho", "b2");
            Assert.Throws<ArgumentException>((() => bankVault.AddItem("pesho", item)));
        }

        [Test]
        public void ThrowExceptionWhenCellIsAllReadyTaken()
        {
            Item itemOne = new Item("Pesho", "1");
            Item itemTwo = new Item("Gosho", "2");

            bankVault.AddItem("A1", itemOne);

            Assert.Throws<ArgumentException>(() => bankVault.AddItem("A1", itemTwo));
        }

        [Test]
        public void ThrowExceptionWhenItemIsAlreadyTaken()
        {
            Item item = new Item("Pesho", "3");

            bankVault.AddItem("A1", item);
            Item newItem = new Item("Mesho", "3");

            Assert.Throws<InvalidOperationException>((() => bankVault.AddItem("A2", newItem)));

           
        }

        [Test]
        public void AddItemAddsItemToTheVault()
        {
            Item item = new Item("Ivo", "1");

            bankVault.AddItem("A1", item);

            Assert.That(item, Is.EqualTo(bankVault.VaultCells["A1"]));
        }

        [Test]
        public void RemoveShouldThrowExceptionWhenCellDoesntExist()
        {
            Item item = new Item("Pesho", "A1");

            Assert.Throws<ArgumentException>((() => bankVault.RemoveItem("a2", item)));
        }

        [Test]
        public void RemoveShouldThrowExceptionIfItemDoesntExist()
        {
            Item item = new Item("pesho", "B2");

            bankVault.AddItem("A2", item);

            Item newItem = new Item("kinder", "a3");

            Assert.Throws<ArgumentException>((() => bankVault.RemoveItem("asd", newItem)));
        }

        [Test]
        public void RemoveMethodRemovesItem()
        {
            Item item = new Item("Ivo", "1");

            bankVault.AddItem("A1", item);

            bankVault.RemoveItem("A1", item);

            Assert.That(bankVault.VaultCells["A1"], Is.Null);
        }
    }
}