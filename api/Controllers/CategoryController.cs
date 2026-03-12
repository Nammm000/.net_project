using api.Interfaces;
using api.Models;
using api.Mappers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Interfaces.Repositories;
using api.Interfaces.Service;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICurrentUserService _currentUserService;

        private readonly ICategoryRepository _categoryRepo;

        public CategoryController(ICurrentUserService currentUserService,
        ICategoryRepository categoryRepo)
        {
            _currentUserService = currentUserService;
            _categoryRepo = categoryRepo;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepo.GetAllCategoriesAsync();

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpGet("{id:long}")]
        [Authorize]

        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var category = await _categoryRepo.GetByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory([FromBody] Category category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_currentUserService.IsAdmin())
                return Unauthorized("Only admins can add categories!");

            var categoryModel = category.ToCategoryFromCreateDTO();

            await _categoryRepo.AddAsync(categoryModel);
            return Ok(categoryModel);
        }

        [HttpPut]
        [Authorize]
        [Route("{id:long}")]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] Category updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = await _categoryRepo.UpdateAsync(id, updateDto);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return Ok(categoryModel);
        }

        [HttpDelete]
        [Route("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = await _categoryRepo.DeleteAsync(id);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}