using Data.DTOs;
using Data.Validators;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Net;

namespace Controllers;

[ApiController]
[Route("/users")]
public class UsersController : ControllerBase
{
    private IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpPost]
    [Produces("application/json")]
    public async Task<IActionResult> Create([FromForm] UserDTO userDto)
    {
        var validator = new UserValidator();
        var validationResult = validator.Validate(userDto);

        if (validationResult.IsValid)
        {
            var entity = Data.Entities.User.Create(userDto);
            await _usersService.AddUser(entity);
            return Created("string.Empty", new Response("message", HttpStatusCode.Created, null));
        }

        return BadRequest();
    }

    [HttpPatch]
    public IActionResult Update(string email, string password)
    {
        return null;
    }

    [HttpDelete]
    public IActionResult Delete(int id)
    {
        return null;
    }
}