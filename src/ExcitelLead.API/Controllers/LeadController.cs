using ExcitelLead.Application.Leads.Commands.CreateLead;
using ExcitelLead.Application.Leads.Commands.DeleteLead;
using ExcitelLead.Application.Leads.Commands.UpdateLead;
using ExcitelLead.Application.Leads.Queries.GetLeadById;
using Microsoft.AspNetCore.Mvc;

namespace ExcitelLead.API.Controllers
{
    public class LeadController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<LeadDTO>> GetLeadById(int id)
        {
            return await Mediator.Send(new GetLeadByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateLeadCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateLeadCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteLeadCommand(id));

            return NoContent();
        }
    }
}
