using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {
        [TestMethod]
        public void BeInexperiencedWhenNew()
        {
            var sut = new PlayerCharacter();

            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        public void NotHaveNicknameByDefault()
        {
            var sut = new PlayerCharacter();

            Assert.IsNull(sut.Nickname);
        }

        [TestMethod]
        public void StartWithDefaultHealth()
        {
            var sut = new PlayerCharacter();

            Assert.AreEqual(100, sut.Health);
        }

        [TestMethod]
        public void TakeDamage()
        {
            var sut = new PlayerCharacter();

            sut.TakeDamage(1);

            Assert.AreEqual(99, sut.Health);
        }

        [TestMethod]
        public void TakeDamageNotEqual()
        {
            var sut = new PlayerCharacter();

            sut.TakeDamage(1);

            Assert.AreNotEqual(100, sut.Health);
        }

        [TestMethod]
        public void IncreaseHealthAfterSleeping()
        {
            var sut = new PlayerCharacter();

            sut.Sleep(); //expect increase between 1 and 100 inclusive

            Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
        }

        [TestMethod]
        public void CalculateFullName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Brenna";
            sut.LastName = "Cosby";

            Assert.AreEqual("Brenna Cosby", sut.FullName, true);
        }

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Brenna";
            sut.LastName = "Cosby";

            // Assert.IsTrue(sut.FullName.StartsWith("Brenna"));
            StringAssert.StartsWith(sut.FullName, "Brenna");
        }

        [TestMethod]
        public void HaveFullNameEndingWithLastName()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Brenna";
            sut.LastName = "Cosby";

            // Assert.IsTrue(sut.FullName.EndsWith("Cosby"));
            StringAssert.EndsWith(sut.FullName, "Cosby");
        }

        [TestMethod]
        public void CalculateFullName_SubstringAssert()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Brenna";
            sut.LastName = "Cosby";

            StringAssert.Contains(sut.FullName, "a Cos");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            var sut = new PlayerCharacter();

            sut.FirstName = "Brenna";
            sut.LastName = "Cosby";

            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            var sut = new PlayerCharacter();

            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        public void HaveAllExpectedStartingWeapons()
        {
            var sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Long Bow",
                "Short Bow",
                "Short Sword"
            };

            CollectionAssert.AreEqual(expectedWeapons, sut.Weapons);
        }

        [TestMethod]
        public void HaveAllExpectedStartingWeapons_AnyOrder()
        {
            var sut = new PlayerCharacter();

            var expectedWeapons = new[]
            {
                "Short Bow",
                "Long Bow",
                "Short Sword"
            };

            CollectionAssert.AreEquivalent(expectedWeapons, sut.Weapons);
        }

        [TestMethod]
        public void HaveNoDuplicateWeapons()
        {
            var sut = new PlayerCharacter();

            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {
            var sut = new PlayerCharacter();

            Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {
            var sut = new PlayerCharacter();

            Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));
        }

    }
}
