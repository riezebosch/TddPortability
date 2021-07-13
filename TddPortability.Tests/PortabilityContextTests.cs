using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace TddPortability.Tests
{
    public class PortabilityContextTests
    {
        [Fact]
        public async Task TestEntries()
        {
            await using var context = new PortabilityContext(new DbContextOptionsBuilder().UseSqlite("Data Source=test.db").Options);
            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            
            context
                .Entries.Add(new Entry(
                    1234,
                    26,
                    new Uri("https://zg2-zorgaanbieder2.test1.medmij.nl/BZR/Patient?_include=Patient:general-practitioner"), 
                    new DateTimeOffset(2020, 05, 11, 12, 25, 38, 00, TimeSpan.Zero)
                    )
                );

            await context.SaveChangesAsync();
        }
    }
}