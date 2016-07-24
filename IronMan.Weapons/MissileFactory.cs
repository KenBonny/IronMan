using System;
using IronMan.Core;
using IronMan.Weapons.Missiles;

namespace IronMan.Weapons
{
    public class MissileFactory : IMissileFactory
    {
        public IMissile Create(MissileType type)
        {
            switch (type)
            {
                case MissileType.Guided:
                    return new LaserGuidedMissile();
                case MissileType.Autonomous:
                    return new HeatSeekingMissile();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}