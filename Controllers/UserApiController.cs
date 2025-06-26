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
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var user = await _userService.GetByIdAsync(id);
        if (user == null)
            return NotFound($"User with ID {id} not found.");

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
        return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(int id, [FromBody] User user)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != user.UserID)
            return BadRequest("ID mismatch between route and body.");

        var existing = await _userService.GetByIdAsync(id);
        if (existing == null)
            return NotFound($"User with ID {id} not found.");

        await _userService.UpdateAsync(user);
        return NoContent();
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _userService.GetByIdAsync(id);
        if (existing == null)
            return NotFound($"User with ID {id} not found.");

        await _userService.DeleteAsync(id);
        return NoContent();
    }
}