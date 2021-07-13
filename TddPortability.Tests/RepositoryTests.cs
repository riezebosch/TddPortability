using System;
using System.Threading.Tasks;
using Bogus;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TddPortability.Tests
{
    public class RepositoryTests
    {
        private readonly Faker<Entry> _faker = new Faker<Entry>()
            .CustomInstantiator(f => new Entry(
                f.IndexFaker, 
                f.Random.Number(), 
                new Uri(f.Internet.Url()), 
                f.Date.PastOffset())
            );

        [Fact]
        public async Task Save_WithEntry_ShouldAddToContext()
        {
            // Arrange
            await using var context = new PortabilityContext(new DbContextOptionsBuilder()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options);
            
            // Act
            await new Repository(context)
                .Store(_faker.Generate());

            // Assert
            context
                .Entries
                .Should()
                .NotBeEmpty();
        }
    }
}