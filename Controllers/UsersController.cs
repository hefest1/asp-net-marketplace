using Data.DTOs;
using Data.Validators;
using Extensions;
using Microsoft.AspNetCore.Http.Extensions;
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

    [Route("/{id?}")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        var user = await _usersService.Get(id);

        if (user == null)
        {
            return NotFound(new Response($"User with id {id} not found", HttpStatusCode.NotFound, null));
        }

        var response = new Response(string.Empty, HttpStatusCode.OK, user);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] UserDTO userDto)
    {
        var validator = new UserCreateValidator();
        var validationResult = await validator.ValidateAsync(userDto);

        if (validationResult.IsValid)
        {
            var entity = Data.Entities.User.Create(userDto);
            var createdEntity = await _usersService.AddUser(entity);

            var url = $"{Request.GetDisplayUrl()}/{createdEntity.Id}";
            var successResponse = new Response(string.Empty, HttpStatusCode.Created, null);
            return Created(url, successResponse);
        }
        
        var failureResponse = new Response("Validation failed", HttpStatusCode.BadRequest, validationResult.GetFieldsErrorsMap());
        return BadRequest(failureResponse);
    }

    [HttpPatch]
    [Route("/{id?}")]
    public async Task<IActionResult> Update([FromForm] UserDTO userDto)
    {
        var validator = new UserUpdateValidator();
        var validationResult = await validator.ValidateAsync(userDto);
        
        return null;
    }

    [HttpDelete]
    [Route("/{id?}")]
    public IActionResult Delete([FromRoute]int id)
    {
        _usersService.Delete(id);
        return NoContent();
    }
}