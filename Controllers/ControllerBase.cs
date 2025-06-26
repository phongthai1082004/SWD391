using Assignment1.Services;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseController<T, TCreateDto, TUpdateDto, TResponseDto> : ControllerBase
        where T : class
    {
        protected readonly IBaseService<T> _baseService;

        public BaseController(IBaseService<T> baseService)
        {
            _baseService = baseService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> GetAll()
        {
            var result = await _baseService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            var entity = await _baseService.GetByIdAsync(id);
            if (entity == null) return NotFound();
            return Ok(entity);
        }

        [HttpDelete("{id}")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            var entity = await _baseService.GetByIdAsync(id);
            if (entity == null) return NotFound();

            await _baseService.DeleteAsync(id);
            return NoContent();
        }
    }
}