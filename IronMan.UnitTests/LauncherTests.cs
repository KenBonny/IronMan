using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronMan.Core;
using IronMan.Weapons;
using IronMan.Weapons.Missiles;
using Moq;
using Xunit;

namespace IronMan.UnitTests
{
    public class LauncherTests
    {
        private readonly Mock<IMissile> mockMissile;

        public LauncherTests()
        {
            mockMissile = new Mock<IMissile>();
        }

        [Fact]
        public void When_launching_missile_then_decrease_missile_count_by_1()
        {
            // arrange
            var launcher = new Launcher(new List<IMissile> {mockMissile.Object});
            // act
            launcher.Launch();
            // assert
            Assert.Equal(0, launcher.MissileCount);
            Assert.True(launcher.MissileCount == 0, "Missile was not launched");
        }

        public static IEnumerable<object[]> MissileData
        {
            get
            {
                return new[]
                {
                    new object[] {new HeatSeekingMissile()},
                    new object[] {new LaserGuidedMissile()}
                };
            }
        }

        [Theory]
        [MemberData(nameof(MissileData))]
        [Trait("Category", "ComponentTest")]
        public void When_launching_missile_from_memberdata_then_decrease_missile_count_by_1(IMissile missile)
        {
            // arrange
            var launcher = new Launcher(new List<IMissile> {missile});
            // act
            launcher.Launch();
            // assert
            Assert.Equal(0, launcher.MissileCount);
        }

        [Theory]
        [ClassData(typeof(MissileClassData))]
        [Trait("Category", "ComponentTest")]
        public void When_launching_missile_from_classdata_then_decrease_missile_count_by_1(IMissile missile)
        {
            // arrange
            var launcher = new Launcher(new List<IMissile> {missile});
            // act
            launcher.Launch();
            // assert
            Assert.Equal(0, launcher.MissileCount);
        }
    }
}
