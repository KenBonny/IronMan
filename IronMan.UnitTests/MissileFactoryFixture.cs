using IronMan.Weapons;

namespace IronMan.UnitTests
{
    public class MissileFactoryFixture
    {
        public MissileFactory Factory { get; set; }

        public MissileFactoryFixture()
        {
            Factory= new MissileFactory();
        }
    }
}