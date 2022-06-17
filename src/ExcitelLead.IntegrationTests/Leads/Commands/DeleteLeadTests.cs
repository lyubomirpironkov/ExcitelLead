using ExcitelLead.Application.Common.Exceptions;
using ExcitelLead.Application.Leads.Commands.CreateLead;
using ExcitelLead.Application.Leads.Commands.DeleteLead;
using ExcitelLead.Application.Leads.Queries.GetLeadById;
using ExcitelLead.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;

using static ExcitelLead.IntegrationTests.Testing;

namespace ExcitelLead.IntegrationTests.Leads.Commands
{
    internal class DeleteLeadTests : BaseTestFixture
    {
        [Test]
        public async Task ShouldRequireValidTodoListId()
        {
            var command = new DeleteLeadCommand(99);
            await FluentActions.Invoking(() => SendAsync(command)).Should().ThrowAsync<NotFoundException>();
        }

        [Test]
        public async Task ShouldDeleteTodoList()
        {
            var listId = await SendAsync(new CreateLeadCommand
            {
                Address = "Address 1 Test",
                Name = "Lead 1 Test",
                SubAreaId = 1
            });

            var query = new GetLeadByIdQuery { Id = listId };

            var result = await SendAsync(query);

            result.Should().NotBeNull();

            await SendAsync(new DeleteLeadCommand(listId));

            await FluentActions.Invoking(() => SendAsync(query)).Should().ThrowAsync<NotFoundException>();
        }
    }
}
