using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Application.Features.Authorization.Command.Model;
using SchoolProject.Application.Features.Authorization.Queries.Model;

namespace SchoolProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : AppControllerBase
    {
        public RolesController(IMediator mediator) : base(mediator) { }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddRoleCommand command)
        => NewResult(await Mediator.Send(command));

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditRoleCommand command)

     => NewResult(await Mediator.Send(command));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
       => NewResult(await Mediator.Send(new DeleteRoleCommand { Id = id }));
    

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleToUserCommand command)
        => NewResult(await Mediator.Send(command));

         [HttpGet]
          public async Task<IActionResult> GetAll()
          => NewResult(await Mediator.Send(new GetRolesQuery()));
    
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
            => NewResult(await Mediator.Send(new GetRoleByIdQuery { Id = id }));

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserRoles(string userId)
      => NewResult(await Mediator.Send(new GetUserRolesQuery { UserId = userId }));

        [HttpPost("remove")]
        public async Task<IActionResult> RemoveRole(RemoveRoleFromUserCommand command)
      => NewResult(await Mediator.Send(command));


        [HttpPost("update-user-roles")]
        public async Task<IActionResult> UpdateUserRoles(UpdateUserRolesCommand command)
        => NewResult(await Mediator.Send(command));



    }
    //1️⃣ Pagination + Search في Roles
    //2️⃣ Policies بدل[Authorize(Roles = "Admin")]
    //3️⃣ Claims / Permissions System
}