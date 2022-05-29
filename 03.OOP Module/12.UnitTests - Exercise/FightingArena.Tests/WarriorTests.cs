using FightingArena;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class WarriorTests
    {
        private Warrior warrior;
        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Gosho", 50, 100);
        }

        [Test]
        public void CarClassShouldSetValuesThroughConstructorIfTheyAreValid()
        {
            Assert.AreEqual("Gosho", warrior.Name);
            Assert.AreEqual(50, warrior.Damage);
            Assert.AreEqual(100, warrior.HP);
        }

        [TestCase("")]
        [TestCase(null)]
        public void WarriorShouldThrowExceptionIfWarriorNameIsInvalid(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 50, 100));
        }

        [TestCase(0)]
        [TestCase(-10)]
        public void WarriorShouldThrowExceptionIfWarriorDamageIsZeroOrNegative(int damage)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Gosho", damage, 100));
        }

        [TestCase(-10)]
        public void WarriorShouldThrowExceptionIfWarriorHPIsZeroOrNegative(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Gosho", 50, hp));
        }


        [TestCase(25)]
        [TestCase(30)]

        public void WarriorAttackMethodShouldThrowExceptionIfAttackerHasHpBelowOrEqualMinHP(int hp)
        {
            var attacker = new Warrior("Petio", 50, hp);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(warrior));
        }

        [TestCase(25)]
        [TestCase(30)]
        public void WarriorAttackMethodShouldThrowExceptionIfWarriorHasHpBelowOrEqualMinHP(int hp)
        {
            var attacker = new Warrior("Petio", 50, 100);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(new Warrior("Pesho", 50, hp)));
        }

        [TestCase(50)]
        [TestCase(89)]

        public void WarriorAttackMethodShouldThrowExceptionIfAttackerHasHpBelowThanEnemyDamage(int damage)
        {
            var attacker = new Warrior("Petio", 50, 40);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(new Warrior("Pesho", damage, 60)));
        }

        [Test]
        public void WarriorAttackMethodShouldDecreaseAttackerHPWithEnemyDamage()
        {
            var attacker = new Warrior("Petio", 50, 100);
            attacker.Attack(warrior);
            Assert.AreEqual(attacker.HP, 50);
        }

        [Test]
        public void WarriorAttackMethodShouldSetEnemyHpOnZeroIfItBeenBelowZero()
        {
            var attacker = new Warrior("Petio", 101, 100);
            attacker.Attack(warrior);
            Assert.AreEqual(warrior.HP, 0);
        }

        [Test]
        public void WarriorAttackMethodShouldDecreaseEnemyHp()
        {
            var attacker = new Warrior("Petio", 50, 100);
            attacker.Attack(warrior);
            Assert.AreEqual(warrior.HP, 50);
        }
    }
}