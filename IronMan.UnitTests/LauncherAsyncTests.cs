using IronMan.Core;
using IronMan.Weapons;
using IronMan.Weapons.Missiles;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace IronMan.UnitTests
{
    public class LauncherAsyncTests
    {
        private readonly Mock<IMissile> mockMissile;

        public LauncherAsyncTests()
        {
            mockMissile = new Mock<IMissile>();
        }

        [Fact]
        public async Task When_launching_missile_then_decrease_missile_count_by_1()
        {
            // arrange
            var launcher = new Launcher(new List<IMissile> { mockMissile.Object });
            // act
            await launcher.LaunchAsync();
            // assert
            Assert.Equal(0, launcher.MissileCount);
            Assert.True(launcher.MissileCount == 0, "Missile was not launched");
        }

        public static IEnumerable<object[]> MissileData => new[]
        {
            new object[] {new HeatSeekingMissile()},
            new object[] {new LaserGuidedMissile()}
        };

        [Theory]
        [MemberData(nameof(MissileData))]
        [Trait("Category", "ComponentTest")]
        public async Task When_launching_missile_from_memberdata_then_decrease_missile_count_by_1Async(IMissile missile)
        {
            // arrange
            var launcher = new Launcher(new List<IMissile> { missile });
            // act
            await launcher.LaunchAsync();
            // assert
            Assert.Equal(0, launcher.MissileCount);
        }

        [Theory]
        [ClassData(typeof(MissileClassData))]
        [Trait("Category", "ComponentTest")]
        public async Task When_launching_missile_from_classdata_then_decrease_missile_count_by_1Async(IMissile missile)
        {
            // arrange
            var launcher = new Launcher(new List<IMissile> { missile });
            // act
            await launcher.LaunchAsync();
            // assert
            Assert.Equal(0, launcher.MissileCount);
        }
    }
}
