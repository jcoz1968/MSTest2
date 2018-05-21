using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    [TestClass]
    public class BossEnemyShould
    {
        [TestMethod]
        public void HaveCorrectSpecialAttackPower()
        {
            var sut = new BossEnemy();

            Assert.AreEqual(166.6, sut.SpecialAttackPower, 0.07);
        }

    }
}
