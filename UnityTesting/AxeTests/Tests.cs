using NUnit.Framework;
using System;
using System;

namespace AxeTests
{
    public class Tests
    {

        [Test]
        public void When_Attack_Does_Weapon_Lose_Durabbiltiy()
        {
            Axe axe = new Axe(5, 100);
            axe.Attack(new Dummy(50, 10));
            Assert.That(axe.DurabilityPoints < 100);
        }

        [Test]
        public void When_Weapon_Is_Broken_Does_It_Attack()
        {
            Axe axe = new Axe(100, 1);
            
            Assert.Throws<InvalidOperationException>( () =>
            {
                axe.Attack(new Dummy(50, 10));
                axe.Attack(new Dummy(50, 10));
            });
        }
    }
}