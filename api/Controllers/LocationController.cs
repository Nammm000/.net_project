using api.Dtos.Location;
using api.Interfaces.Repositories;
using api.Interfaces.Service;
using api.Models;
using api.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("location")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUserService _currentUserService;

        private readonly ILocationRepository _locationRepo;

        public LocationController(UserManager<AppUser> userManager, ICurrentUserService currentUserService,
        ILocationRepository locationRepo)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
            _locationRepo = locationRepo;
        }

        // [HttpGet]
        // [Authorize]
        // public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     var stocks = await _stockRepo.GetAllAsync(query);

        //     var stockDto = stocks.Select(s => s.ToStockDto()).ToList();

        //     return Ok(stockDto);
        // }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var location = await _locationRepo.GetAllLocationsAsync();

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpGet("{id:long}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var location = await _locationRepo.GetByIdAsync(id);

            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddLocation([FromBody] LocationAERequestDto locationAERequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_currentUserService.IsAdmin())
                return Unauthorized("Only admins can add locations!");

            var locationModel = locationAERequestDto.ToLocationFromCreateDTO();

            await _locationRepo.AddAsync(locationModel);
            return Ok(locationModel);
        }

        [HttpPut]
        [Route("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] LocationAERequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var locationModel = await _locationRepo.UpdateAsync(id, updateDto);

            if (locationModel == null)
            {
                return NotFound();
            }

            return Ok(locationModel);
        }

        [HttpDelete]
        [Route("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var locationModel = await _locationRepo.DeleteAsync(id);

            if (locationModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}