using System;
using System.Collections.Generic;
using System.Linq;
using IronMan.Core;
using System.Threading.Tasks;

namespace IronMan.Weapons
{
    public class Launcher : ILauncher
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

        public Task LaunchAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var missile = missiles.First();
                missiles.Remove(missile);
            });
        }
    }
}