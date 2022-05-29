using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class DummyTests
    {
        [TestCase(10, 10, 10, 10)]
        public void DummyShouldLosesHealthIfAttacked(int attack, int durability, int health, int experince)
        {
            Axe axe = new Axe(attack, durability);
            Dummy dummy = new Dummy(health, experince);

            axe.Attack(dummy);

            Assert.AreEqual(0, dummy.Health);
        }

        [TestCase(10, 10, 0, 10)]
        public void DeadDummyShouldThrowExceptionIfAttacked(int attack, int durability, int health, int experince)
        {
            Axe axe = new Axe(attack, durability);
            Dummy dummy = new Dummy(health, experince);
            Assert.That(() => { axe.Attack(dummy); }, Throws.InvalidOperationException);
        }

        //Dead Dummy can give XP
        [TestCase(10, 10, 0, 10)]
        public void DummyShouldGiveXpIfDead(int attack, int durability, int health, int experince)
        {
            Axe axe = new Axe(attack, durability);
            Dummy dummy = new Dummy(health, experince);

            Assert.AreEqual(10, dummy.GiveExperience());
        }
        // //Alive Dummy can't give XP
        [TestCase(10, 10, 10, 10)]
        public void DummyShouldThrowExceptionIfIsLive(int attack, int durability, int health, int experince)
        {
            Axe axe = new Axe(attack, durability);
            Dummy dummy = new Dummy(health, experince);
            Assert.That(() => {dummy.GiveExperience(); }, Throws.InvalidOperationException);
        }
    }
}
