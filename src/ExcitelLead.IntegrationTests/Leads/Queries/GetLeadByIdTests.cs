using ExcitelLead.Application.Common.Exceptions;
using ExcitelLead.Application.Leads.Commands.CreateLead;
using ExcitelLead.Application.Leads.Queries.GetLeadById;
using ExcitelLead.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

using static ExcitelLead.IntegrationTests.Testing;

namespace ExcitelLead.IntegrationTests.Leads.Queries
{
    internal class GetLeadByIdTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldReturnItem()
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

            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Address, Is.EqualTo("Address 1 Test"));
        }

        [Test]
        public async Task ShouldNotReturnItem()
        {
            var command = new CreateLeadCommand
            {
                Address = "Address 1 Test",
                Name = "Lead 1 Test",
                SubAreaId = 1
            };

            var id = await SendAsync(command);

            var query = new GetLeadByIdQuery { Id = 222 };

            var action = () => SendAsync(query);
            await action.Should().ThrowAsync<NotFoundException>();
        }
    }
}
