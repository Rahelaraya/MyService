using NUnit.Framework;
using MyService.Api.Services; // 👈 Lägg till denna rad för att komma åt din klass

namespace MyService.Tests
{
    public class GreetingServiceTests
    {
        [Test]
        public void SayHello_ReturnsExpectedMessage()
        {
            // Arrange
            var service = new GreetingService();

            // Act
            var result = service.SayHello("Rahel");

            // Assert
            Assert.That(result, Is.EqualTo("Hello, Rahel!"));
        }
    }
}
