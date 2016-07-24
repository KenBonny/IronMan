using System;
using System.Linq;
using IronMan.Core;
using IronMan.Weapons;
using IronMan.Weapons.Missiles;
using LightInject;

namespace IronMan.Jarvis
{
    public static class Jarvis
    {
        public static void Main()
        {
            try
            {
                var container = ConfigureContainer();
                Console.WriteLine("Hello sir, how can I be of assistance?");

                var launcher = container.GetInstance<ILauncher>();
                Console.WriteLine($"The {launcher.GetType().Name} contains {launcher.MissileCount} missile(s)");
                Console.WriteLine();

                var missiles = container.GetAllInstances(typeof(IMissile));
                Console.WriteLine("The available missiles are:");
                var count = 1;
                foreach (var missile in missiles)
                {
                    Console.WriteLine($"{count++}. {missile.GetType().Name}");
                }
                Console.WriteLine();

                Console.WriteLine("Choose missile type:");
                count = 1;
                var missileTypes = Enum.GetValues(typeof(MissileType)).Cast<MissileType>().ToArray();
                foreach (var value in missileTypes)
                {
                    Console.WriteLine($"{count++}. {value}");
                }
                Console.WriteLine();

                Console.Write("Choose missile type: ");
                var chosen = int.Parse(Console.ReadLine()) - 1;
                var missileType = missileTypes[chosen];
                Console.WriteLine($"Chosen missile type: {missileType}");
                Console.WriteLine();

                var factory = container.GetInstance<IMissileFactory>();
                var createdMissile = factory.Create(missileType);
                Console.WriteLine($"The created missile is of type {createdMissile.GetType().Name}");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR: {ex.Message}");
            }

            Console.ReadLine();
        }

        internal static IServiceContainer ConfigureContainer()
        {
            var container = new ServiceContainer();

            // normal registration
            container.Register<ILauncher, Launcher>();

            // named registration
            container.Register<IMissile, HeatSeekingMissile>(MissileType.Autonomous.ToString());
            container.Register<IMissile, LaserGuidedMissile>(MissileType.Guided.ToString());

            // mass registration
            container.RegisterAssembly(typeof(WeaponsAssembly).Assembly,
                (serviceType, implementingType) => serviceType.IsAssignableFrom(typeof(IMissileFactory)));

            return container;
        }
    }
}
