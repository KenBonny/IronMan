using System;
using System.Collections.Generic;
using System.Linq;
using IronMan.Core;
using IronMan.Weapons.Missiles;

namespace IronMan.Weapons
{
    public class OldLauncher
    {
        private List<OldMissile> missiles;

        public OldLauncher()
        {
            // simulate missiles loaded from database
            this.missiles = new List<OldMissile> {new OldMissile(), new OldMissile()};
        }

        public OldLauncher(List<OldMissile> missiles)
        {
            this.missiles = missiles;
        }

        public int MissileCount => missiles.Count;

        public void Launch()
        {
            var missile = missiles.First();
            missiles.Remove(missile);

            if (!missile.Fire())
            {
                throw new Exception("Missile could not be launched.");
            }
        }
    }
}