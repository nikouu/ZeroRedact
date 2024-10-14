using Microsoft.Extensions.DependencyInjection;

namespace ZeroRedact.UnitTest.ServiceRegistration
{
    [TestClass]
    public class ServiceRegistrationTests
    {
        [TestMethod]
        public void AddZeroRedact_WithNoOptions_ShouldRegisterRedactor()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            services.AddZeroRedact();

            // Assert
            var serviceDescriptor = services.Single(x => x.ServiceType == typeof(IRedactor));
            Assert.IsNotNull(serviceDescriptor);
            Assert.AreEqual(ServiceLifetime.Singleton, serviceDescriptor.Lifetime);
            Assert.AreEqual(typeof(Redactor), serviceDescriptor.ImplementationType);
        }

        [TestMethod]
        public void AddZeroRedact_WithOptions_ShouldRegisterRedactor()
        {
            // Arrange
            var services = new ServiceCollection();
            var options = new RedactorOptions();

            // Act
            services.AddZeroRedact(options);

            // Assert
            var serviceDescriptor = services.Single(x => x.ServiceType == typeof(IRedactor));
            Assert.IsNotNull(serviceDescriptor);
            Assert.AreEqual(ServiceLifetime.Singleton, serviceDescriptor.Lifetime);

            // ImplementationInstance because the instance is created at the time
            Assert.AreEqual(typeof(Redactor), serviceDescriptor.ImplementationInstance.GetType());
        }

        [TestMethod]
        public void AddZeroRedact_WithNoOptions_ShouldReturnServiceCollection()
        {
            // Arrange
            var services = new ServiceCollection();

            // Act
            var result = services.AddZeroRedact();

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IServiceCollection));
        }

        [TestMethod]
        public void AddZeroRedact_WithOptions_ShouldReturnServiceCollection()
        {
            // Arrange
            var services = new ServiceCollection();
            var options = new RedactorOptions();

            // Act
            var result = services.AddZeroRedact(options);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(IServiceCollection));
        }

        [TestMethod]
        public void AddZeroRedact_WithNoOptions_WithNullService_ShouldThrowArgumentNullException()
        {
            // Arrange
            IServiceCollection services = null;

            // Act
            void Act() => services.AddZeroRedact();

            // Assert
            Assert.ThrowsException<ArgumentNullException>(Act);
        }

        [TestMethod]
        public void AddZeroRedact_WithOptions_WithNullService_ShouldThrowArgumentNullException()
        {
            // Arrange
            IServiceCollection services = null;
            var options = new RedactorOptions();

            // Act
            void Act() => services.AddZeroRedact(options);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(Act);
        }
    }
}
