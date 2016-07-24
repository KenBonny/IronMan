using IronMan.Core;
using IronMan.Weapons;
using LightInject;
using Xunit;

namespace IronMan.UnitTests
{
    public class IocConfigurationTests
    {
        private readonly IServiceContainer container;

        public IocConfigurationTests()
        {
            container = Jarvis.Jarvis.ConfigureContainer();
        }

        [Fact]
        public void Ioc_configuration_should_resolve_ILauncher()
        {
            var instance = container.GetInstance<ILauncher>();
            Assert.NotNull(instance);
            Assert.IsType<Launcher>(instance);
        }
    }
}