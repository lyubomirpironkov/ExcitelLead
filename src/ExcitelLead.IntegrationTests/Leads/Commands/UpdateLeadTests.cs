using ExcitelLead.Application.Common.Exceptions;
using ExcitelLead.Application.Leads.Commands.CreateLead;
using ExcitelLead.Application.Leads.Commands.UpdateLead;
using ExcitelLead.Application.Leads.Queries.GetLeadById;
using ExcitelLead.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

using static ExcitelLead.IntegrationTests.Testing;

namespace ExcitelLead.IntegrationTests.Leads.Commands
{
    internal class UpdateLeadTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireValidTodoItemId()
        {
            var command = new UpdateLeadCommand
            {
                Id = 99,
                Address = "Test Address",
                Name = "Test Name",
                SubAreaId = 1
            };
            await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldUpdateTodoItem()
        {
            var itemId = await SendAsync(new CreateLeadCommand
            {
                Address = "Test Address",
                Name = "Test Name",
                SubAreaId = 1
            });

            var command = new UpdateLeadCommand
            {
                Id = itemId,
                Address = "New Test Address",
                Name = "New Test Name",
                SubAreaId = 1
            };

            await SendAsync(command);

            var query = new GetLeadByIdQuery { Id = itemId };

            var result = await SendAsync(query);

            result.Should().NotBeNull();
            result!.Address.Should().Be(command.Address);
            result!.Name.Should().Be(command.Name);
            result.Modified.Should().NotBeNull();
            result.Modified.Should().BeCloseTo(DateTime.Now, TimeSpan.FromMilliseconds(10000));
        }
    }
}
