using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Warehouse;
using api.Interfaces.Repositories;
using api.Interfaces.Service;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("warehouse")]
    [ApiController]
    public class WarehouseController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUserService _currentUserService;

        private readonly IWarehouseRepository _warehouseRepo;

        public WarehouseController(UserManager<AppUser> userManager, ICurrentUserService currentUserService,
        IWarehouseRepository warehouseRepo)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
            _warehouseRepo = warehouseRepo;
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

            var warehouses = await _warehouseRepo.GetAllWarehouses();

            if (warehouses == null)
            {
                return NotFound();
            }

            return Ok(warehouses);
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
        public async Task<IActionResult> AddWarehouse([FromBody] WarehouseAERequestDto warehouseAERequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_currentUserService.IsAdmin())
                return Unauthorized("Only admins can add warehouses!");

            var warehouseModel = await _warehouseRepo.AddAsync(warehouseAERequestDto);
            if (warehouseModel == null)
            {
                return BadRequest("Failed to add warehouse.");
            }
            return Ok(warehouseModel);
        }

        [HttpPut]
        [Route("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] WarehouseAERequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var warehouseModel = await _warehouseRepo.UpdateAsync(id, updateDto);

            if (warehouseModel == null)
            {
                return NotFound();
            }

            return Ok(warehouseModel);
        }

        [HttpDelete]
        [Route("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var warehouseModel = await _warehouseRepo.DeleteAsync(id);

            if (warehouseModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}