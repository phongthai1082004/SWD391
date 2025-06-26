using Assignment1.Models;
using Assignment1.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/Users
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();
        return Ok(users);
    }

    // GET: api/Users/5
    [HttpGet("{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int userId)
    {
        var user = await _userService.GetByIdAsync(userId);
        if (user == null)
            return NotFound($"User with ID {userId} not found.");

        return Ok(user);
    }

    // POST: api/Users
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _userService.CreateAsync(user);
        return CreatedAtAction(nameof(Get), new { userId = user.UserID }, user);
    }

    // PUT: api/Users/5
    [HttpPut("{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int userId, [FromBody] User user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (userId != user.UserID)
            return BadRequest("UserID mismatch between route and body.");

        var existing = await _userService.GetByIdAsync(userId);
        if (existing == null)
            return NotFound($"User with ID {userId} not found.");

        await _userService.UpdateAsync(user);
        return NoContent();
    }

    // DELETE: api/Users/5
    [HttpDelete("{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int userId)
    {
        var existing = await _userService.GetByIdAsync(userId);
        if (existing == null)
            return NotFound($"User with ID {userId} not found.");

        await _userService.DeleteAsync(userId);
        return NoContent();
    }
}
