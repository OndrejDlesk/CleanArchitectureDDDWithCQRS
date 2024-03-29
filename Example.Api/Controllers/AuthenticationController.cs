﻿
using ErrorOr;
using Example.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;
using Example.Domain.Common.Errors;
using MediatR;
using Example.Application.Authentication.Commands.Register;
using Example.Application.Authentication.Queries.Login;
using Example.Application.Authentication.Common;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace Example.Api.Controllers
{
    [Route("auth")]
    [AllowAnonymous]
    public class AuthenticationController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public AuthenticationController(
            ISender mediator,
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = _mapper.Map<RegisterCommand>(request);

            ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(command);

            return registerResult.Match(
                result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                errors => Problem(errors)
            );
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = _mapper.Map<LoginQuery>(request);

            var authResult = await _mediator.Send(query);

            if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
            {
                return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
            }

            return authResult.Match(
                            result => Ok(_mapper.Map<AuthenticationResponse>(result)),
                            errors => Problem(errors)
                        );
        }
    }
}
