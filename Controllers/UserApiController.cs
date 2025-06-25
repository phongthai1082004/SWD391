using Assignment1.Models;
using Assignment1.Models.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{



    [ApiController] // Validatation required this shit
    // [Route("api/[controller]")]
    [Route("api/UserAPI")]
    public class UserApiController : ControllerBase
    {
        // Mapper

        private readonly IMapper _mapper;
        public UserApiController(IMapper mapper)
        {
            _mapper = mapper;
        }

        // Get All
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(Datastore.Users.ToList());
        }

        // Get by ID

        [HttpGet("{UserId:int}", Name = "GetUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> GetUser(int UserId)
        {
            if (UserId <= 0)
            {
                return BadRequest("Invalid ID provided.");
            }

            var user = Datastore.Users.FirstOrDefault(u => u.UserID == UserId);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound($"User with ID {UserId} not found.");
            }
        }

        // Create User

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<User> CreateUser([FromBody] UserDTO userDto)
        {
            // Check userDTO
            if (userDto == null)
            {
                return BadRequest(userDto);
            }

            if (Datastore.Users.FirstOrDefault(u => u.UserID == userDto.UserID) != null)
            {
                ModelState.AddModelError("ExistedError", "User is existed!");
                return BadRequest(ModelState);
            }

            if (userDto.UserID > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            userDto.UserID = Datastore.Users.OrderByDescending(u => u.UserID).FirstOrDefault()?.UserID + 1 ?? 1;
            var user = _mapper.Map<User>(userDto);
            Datastore.Users.Add(user);
            return Ok(userDto);
        }

        // Delete User 

        [HttpDelete("{UserId:int}", Name = "DeleteUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult DeleteUser(int UserID)
        {
            if (UserID == 0)
            {
                return BadRequest();
            }

            var user = Datastore.Users.FirstOrDefault(u => u.UserID == UserID);

            if (user == null)
            {
                return NotFound();
            }
            Datastore.Users.Remove(user);
            return NoContent();
        }

        // Cập nhật toàn bộ thông tin người dùng
        [HttpPatch("{UserId:int}", Name = "UpdateUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateUser(int UserId, [FromBody] UserDTO userDto)
        {
            if (userDto == null || UserId != userDto.UserID)
            {
                return BadRequest("Invalid user data provided.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = Datastore.Users.FirstOrDefault(u => u.UserID == UserId);
            if (user == null)
            {
                return NotFound($"User with ID {UserId} not found.");
            }

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Password = userDto.Password;
            user.RoleID = userDto.RoleID;
            user.Status = userDto.Status;

            return NoContent(); // 204
        }

        // Cập nhật một phần thông tin người dùng (JSON Patch)
        [HttpPatch("partial/{UserId:int}", Name = "UpdatePartialUser")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialUser(int UserId, [FromBody] JsonPatchDocument<UserDTO> patchDTO)
        {
            if (patchDTO == null)
            {
                return BadRequest("Invalid patch data provided.");
            }

            var user = Datastore.Users.FirstOrDefault(u => u.UserID == UserId);
            if (user == null)
            {
                return NotFound($"User with ID {UserId} not found.");
            }

            var userToPatch = _mapper.Map<UserDTO>(user);

            try
            {
                patchDTO.ApplyTo(userToPatch, ModelState);
            }
            catch (JsonPatchException ex)
            {
                return BadRequest($"Error applying patch: {ex.Message}");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(userToPatch, user);

            return NoContent(); // 204
        }
    }
}

