using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UltimateSolutions.Application.Commands.User.LogInUser;
using UltimateSolutions.Application.Commands.User.SignUpUser;
using UltimateSolutions.Application.Queries.User.GetUserByName;

namespace UltimateSolutions.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // Convention
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("signUp")]
        public async Task<ActionResult<UserForReturnDto>> SignUp(SignUpUserCommand signUpUserCommand)
        {
            var result = await _mediator.Send(signUpUserCommand);
            if (!result.Succeeded) return BadRequest(result.Errors);
            return await _mediator.Send(new GetUserByNameQuery() { UserName = signUpUserCommand.UserName });
        }

        [HttpPost("logIn")]
        public async Task<ActionResult<LogInUserForReturnDto>> LogIn(LogInUserCommand logInUserCommand)
        {
            return await _mediator.Send(logInUserCommand);
        }
    }
}