using Demo.Application.Commands;
using Demo.Application.Dtos;
using Demo.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var result = await _mediator.Send(new GetUsersQuery());

            return Ok(result);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            return Ok(result);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id:int}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;

            var result = await _mediator.Send(command);
            
            return Ok(result);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDto>> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);

            var result = await _mediator.Send(command);

            if (!result)
                return BadRequest();

            return NoContent();
        }
    }
}
