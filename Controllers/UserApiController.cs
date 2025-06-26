using Assignment1.Models.DTOs.User;
using Assignment1.Services;
using Microsoft.AspNetCore.Mvc;



namespace Assignment1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] UserCreateDTO dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var created = await _userService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = created.UserID }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UserUpdateDTO dto)
    {
        if (id != dto.UserID) return BadRequest("ID mismatch");
        var updated = await _userService.UpdateAsync(dto);
        if (updated == null) return NotFound();
        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _userService.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return user == null ? NotFound() : Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }
}
