using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace GameEngine.Tests
{
    [TestClass]
    public class PlayerCharacterShould
    {
        PlayerCharacter sut;
        [TestInitialize]
        public void TestInitialize()
        {
            sut = new PlayerCharacter
            {
                FirstName = "Brenna",
                LastName = "Cosby"
            };
        }

        [TestMethod]
        [PlayerDefaults]
        // [Ignore]
        public void BeInexperiencedWhenNew()
        {
            Assert.IsTrue(sut.IsNoob);
        }

        [TestMethod]
        [PlayerDefaults]
        // [Ignore("Temporarily disabled for refactoring")]
        public void NotHaveNicknameByDefault()
        {
            Assert.IsNull(sut.Nickname);
        }

        [TestMethod]
        [PlayerDefaults]
        public void StartWithDefaultHealth()
        {
            Assert.AreEqual(100, sut.Health);
        }

        [DataTestMethod]
        [CsvDataSource("Damage.csv")]
        [PlayerHealth]
        public void TakeDamage(int damage, int expectedHealth)
        {
            sut.TakeDamage(damage);

            Assert.AreEqual(expectedHealth, sut.Health);
        }

        [TestMethod]
        [PlayerHealth]
        public void TakeDamageNotEqual()
        {
            sut.TakeDamage(1);

            Assert.AreNotEqual(100, sut.Health);
        }

        [TestMethod]
        [PlayerHealth]
        public void IncreaseHealthAfterSleeping()
        {
            sut.Sleep(); //expect increase between 1 and 100 inclusive

            //Assert.IsTrue(sut.Health >= 101 && sut.Health <= 200);
            Assert.That.IsInRange(sut.Health, 101, 200);
        }

        [TestMethod]
        public void CalculateFullName()
        {
            Assert.AreEqual("Brenna Cosby", sut.FullName, true);
        }

        [TestMethod]
        public void HaveFullNameStartingWithFirstName()
        {

            // Assert.IsTrue(sut.FullName.StartsWith("Brenna"));
            StringAssert.StartsWith(sut.FullName, "Brenna");
        }

        [TestMethod]
        public void HaveFullNameEndingWithLastName()
        {

            // Assert.IsTrue(sut.FullName.EndsWith("Cosby"));
            StringAssert.EndsWith(sut.FullName, "Cosby");
        }

        [TestMethod]
        public void CalculateFullName_SubstringAssert()
        {
            StringAssert.Contains(sut.FullName, "a Cos");
        }

        [TestMethod]
        public void CalculateFullNameWithTitleCase()
        {
            StringAssert.Matches(sut.FullName, new Regex("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]"));
        }

        [TestMethod]
        public void HaveALongBow()
        {
            CollectionAssert.Contains(sut.Weapons, "Long Bow");
        }

        [TestMethod]
        public void HaveAllExpectedStartingWeapons()
        {
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
            CollectionAssert.AllItemsAreUnique(sut.Weapons);
        }

        [TestMethod]
        public void HaveAtLeastOneKindOfSword()
        {
            //Assert.IsTrue(sut.Weapons.Any(weapon => weapon.Contains("Sword")));
            CollectionAssert.That.AtLeastOneItemSatisfies(sut.Weapons, weapon => weapon.Contains("Sword"));
        }

        [TestMethod]
        public void HaveNoEmptyDefaultWeapons()
        {
            //sut.Weapons.Add(" ");
            //Assert.IsFalse(sut.Weapons.Any(weapon => string.IsNullOrWhiteSpace(weapon)));
            //CollectionAssert.That.AllItemsNotNullOrWhitespace(sut.Weapons);
            //CollectionAssert.That.AllItemsSatisfy(sut.Weapons, weapon => !string.IsNullOrWhiteSpace(weapon));
            CollectionAssert.That.All(sut.Weapons, weapon =>
            {
                StringAssert.That.NotNullOrWhiteSpace(weapon);
                Assert.IsTrue(weapon.Length > 5);
            });
        }

    }
}
