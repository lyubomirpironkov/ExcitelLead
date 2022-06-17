using ExcitelLead.Application.Leads.Commands.CreateLead;
using ExcitelLead.Application.Leads.Queries.GetLeadById;
using FluentAssertions;
using NUnit.Framework;
using static ExcitelLead.IntegrationTests.Testing;

namespace ExcitelLead.IntegrationTests.Leads.Commands
{
    internal class CreateLeadTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldCreateLead()
        {
            var command = new CreateLeadCommand
            {
                Address = "Address 1 Test",
                Name = "Lead 1 Test",
                SubAreaId = 1
            };

            var id = await SendAsync(command);

            var query = new GetLeadByIdQuery { Id = id };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result!.Address.Should().Be(command.Address);
            result!.Name.Should().Be(command.Name);
            result.Created.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }
    }
}
