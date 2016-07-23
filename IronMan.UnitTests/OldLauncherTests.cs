using System;
using System.Collections.Generic;
using IronMan.Weapons;
using IronMan.Weapons.Missiles;
using Moq;
using Xunit;

namespace IronMan.UnitTests
{
    public class OldLauncherTests
    {
        [Fact]
        public void When_launching_old_missile_then_decrease_missilecount_by_1()
        {
            // arrange
            var oldLauncher = CreateOldLauncher();
            // act
            oldLauncher.Launch();
            // assert
            Assert.Equal(1, oldLauncher.MissileCount);
        }

        [Fact]
        public void When_fire_fails_then_expect_exception()
        {
            // arrange
            var mockMissile = new Mock<OldMissile>();
            mockMissile.Setup(x => x.Fire()).Returns(false);
            var oldLauncher = CreateOldLauncher(mockMissile.Object);
            // act & assert
            Assert.Throws<Exception>(() => oldLauncher.Launch());
        }

        private static OldLauncher CreateOldLauncher(OldMissile oldMissile)
        {
            return new OldLauncher(new List<OldMissile> {oldMissile});
        }

        private static OldLauncher CreateOldLauncher()
        {
            return new OldLauncher();
        }
    }
}