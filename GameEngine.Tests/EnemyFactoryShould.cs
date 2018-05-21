﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    [TestClass]
    public class EnemyFactoryShould
    {
        [TestMethod]
        public void NotAllowNullName()
        {
            EnemyFactory sut = new EnemyFactory();

            Assert.ThrowsException<ArgumentNullException>(
                () => sut.Create(null)
            );

        }

        [TestMethod]
        public void OnlyAllowKingOrQueenBossEnemies()
        {
            EnemyFactory sut = new EnemyFactory();

            EnemyCreationException ex = Assert.ThrowsException<EnemyCreationException>(
                () => sut.Create("Zombie", true));

            Assert.AreEqual("Zombie", ex.RequestedEnemyName);
        }

        [TestMethod]
        public void CreateNormalEnemyByDefault()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie");

            Assert.IsInstanceOfType(enemy, typeof(NormalEnemy));
        }

        //[TestMethod]
        //public void CreateNormalEnemyByDefault_NotType()
        //{
        //    EnemyFactory sut = new EnemyFactory();

        //    Enemy enemy = sut.Create("Zombie");

        //    Assert.IsNotInstanceOfType(enemy, typeof(NormalEnemy));
        //}

        [TestMethod]
        public void CreateBossEnemy()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy = sut.Create("Zombie King", true);

            Assert.IsInstanceOfType(enemy, typeof(BossEnemy));
        }

        [TestMethod]
        public void CreateSeperateInstances()
        {
            EnemyFactory sut = new EnemyFactory();

            Enemy enemy1 = sut.Create("Zombie");
            Enemy enemy2 = sut.Create("Zombie");

            Assert.AreNotSame(enemy1, enemy2);

        }

    }
}