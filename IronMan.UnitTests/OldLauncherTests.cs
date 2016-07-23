using IronMan.Weapons;
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


        private static OldLauncher CreateOldLauncher()
        {
            return new OldLauncher();
        }
    }
}