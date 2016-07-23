using System;
using IronMan.Core;
using IronMan.Weapons;
using IronMan.Weapons.Missiles;
using Xunit;

namespace IronMan.UnitTests
{
    public class MissileFactoryTests
    {
        [Fact]
        public void When_creating_guided_then_expect_LaserGuidedMissile()
        {
            // arrange
            var factory = new MissileFactory();
            // act
            var missile = factory.Create(MissileType.Guided);
            // assert
            Assert.IsType<LaserGuidedMissile>(missile);
        }

        [Fact]
        public void When_creating_autonomous_then_expect_HeatSeekingMissile()
        {
            // arrange
            var factory = new MissileFactory();
            // act
            var missile = factory.Create(MissileType.Autonomous);
            // assert
            Assert.IsType<HeatSeekingMissile>(missile);
        }

        [Fact]
        public void When_creating_unkown_then_expect_exception()
        {
            // arrange
            var factory = new MissileFactory();
            var type = (MissileType) 3;
            // act & assert
            Assert.Throws<ArgumentOutOfRangeException>(() => factory.Create(type));
        }
    }
}