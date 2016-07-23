using System;
using System.Collections.Generic;
using System.Linq;
using IronMan.Core;

namespace IronMan.Weapons
{
    public class Launcher
    {
        private ICollection<IMissile> missiles;

        public Launcher(ICollection<IMissile> missiles)
        {
            this.missiles = missiles;
        }

        public int MissileCount => missiles.Count;

        public void Launch()
        {
            var missile = missiles.First();
            missiles.Remove(missile);
        }
    }
}