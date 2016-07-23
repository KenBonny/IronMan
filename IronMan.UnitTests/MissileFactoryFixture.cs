using IronMan.Weapons;

namespace IronMan.UnitTests
{
    public class MissileFactoryFixture
    {
        public MissileFactory MissileFactory { get; set; }

        public MissileFactoryFixture()
        {
            MissileFactory = new MissileFactory();
        }
    }
}