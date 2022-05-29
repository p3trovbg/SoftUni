using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeLosesDurabilityAfterAttack()
        {
            Axe axe = new Axe(10, 10);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(9, axe.DurabilityPoints, "Axe Durability doesn't change after attack");
        }

        [Test]
        public void AttackingWithBrokenWeaponShouldBeError()
        {
            Axe axe = new Axe(10, 0);
            Dummy dummy = new Dummy(10, 10);

            Assert.That(() => { axe.Attack(dummy); }, Throws.InvalidOperationException);
        }
    }
}