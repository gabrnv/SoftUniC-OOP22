using NUnit.Framework;
using System;

namespace DummyTests
{
    public class Tests
    {
        [Test]
        public void When_Dummy_Is_Attacked_It_Loses_Health()
        {
            Axe weapon = new Axe(10, 5);
            Dummy dummy = new Dummy(15, 50);
            weapon.Attack(dummy);
            Assert.That(dummy.Health < 15);
        }

        [Test]
        public void Does_Dead_Dummy_Throw_An_Exception_If_Attacked()
        {
            Dummy dummy = new Dummy(0, 10);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.TakeAttack(10);
            });
        }

        [Test]
        public void Does_Dead_Dummy_Give_XP()
        {
            Dummy dummy = new Dummy(0, 50);
            Assert.DoesNotThrow(() =>
            {
                dummy.GiveExperience();
            });
        }

        [Test]
        public void Does_Alive_Dummy_Give_XP()
        {
            Dummy dummy = new Dummy(10, 50);
            Assert.Throws<InvalidOperationException>(() =>
            {
                dummy.GiveExperience();
            });
        }
    }
}