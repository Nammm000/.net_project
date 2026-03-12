using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Provider;
using api.Interfaces.Repositories;
using api.Interfaces.Service;
using api.Models;
using api.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// using api.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("provider")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUserService _currentUserService;

        private readonly IProviderRepository _providerRepo;

        public ProviderController(UserManager<AppUser> userManager, ICurrentUserService currentUserService,
        IProviderRepository providerRepo)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
            _providerRepo = providerRepo;
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
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var providers = await _providerRepo.GetAllProvider();

            if (providers == null)
            {
                return NotFound();
            }

            return Ok(providers);
        }

        // [HttpGet("{id:long}")]
        // public async Task<IActionResult> GetById([FromRoute] long id)
        // {
        //     if (!ModelState.IsValid)
        //         return BadRequest(ModelState);

        //     var provider = await _providerRepo.GetByIdAsync(id);

        //     if (provider == null)
        //     {
        //         return NotFound();
        //     }

        //     return Ok(provider);
        // }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddProvider([FromBody] ProviderAERequestDto providerAERequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_currentUserService.IsAdmin())
                return Unauthorized("Only admins can add providers!");

            var providerModel = providerAERequestDto.ToProviderFromCreateDTO();

            await _providerRepo.AddAsync(providerModel);
            return Ok(providerModel);
        }

        [HttpPut]
        [Route("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] ProviderAERequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var providerModel = await _providerRepo.UpdateAsync(id, updateDto);

            if (providerModel == null)
            {
                return NotFound();
            }

            return Ok(providerModel);
        }

        [HttpDelete]
        [Route("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var providerModel = await _providerRepo.DeleteAsync(id);

            if (providerModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}