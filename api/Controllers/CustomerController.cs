// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
using api.Dtos.Customer;
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
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICurrentUserService _currentUserService;

        private readonly ICustomerRepository _customerRepo;

        public CustomerController(UserManager<AppUser> userManager, ICurrentUserService currentUserService, ICustomerRepository customerRepo)
        {
            _userManager = userManager;
            _currentUserService = currentUserService;
            _customerRepo = customerRepo;
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

            var customer = await _customerRepo.GetAllCustomersAsync();

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpGet("{id:long}")]
        [Authorize]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await _customerRepo.GetCustomerByIdAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerAERequestDto customerAERequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_currentUserService.IsAdmin())
                return Unauthorized("Only admins can add customers!");

            var customerModel = customerAERequestDto.ToCustomerFromCreateDTO();

            await _customerRepo.AddAsync(customerModel);
            return Ok(customerModel);
        }

        [HttpPut]
        [Route("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] CustomerAERequestDto updateDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerModel = await _customerRepo.UpdateAsync(id, updateDto);

            if (customerModel == null)
            {
                return NotFound();
            }

            return Ok(customerModel);
        }

        [HttpDelete]
        [Route("{id:long}")]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerModel = await _customerRepo.DeleteAsync(id);

            if (customerModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}