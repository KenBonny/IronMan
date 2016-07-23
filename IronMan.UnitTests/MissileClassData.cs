using System.Collections;
using System.Collections.Generic;
using IronMan.Weapons.Missiles;

namespace IronMan.UnitTests
{
    public class MissileClassData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // get data from database or webservice
            // or do some complicated computation
            yield return new object[] {new HeatSeekingMissile()};
            yield return new object[] {new LaserGuidedMissile()};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}