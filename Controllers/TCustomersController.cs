﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PeTest.Models;

namespace PeTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TCustomersController : ControllerBase
    {
        private readonly TestpContext _context;

        public TCustomersController(TestpContext context)
        {
            _context = context;
        }

        // GET: api/TCustomers
        [HttpGet]
        public IEnumerable<object> GetCustomer()
        {

            
            var Customer = from Ty in _context.Type
                           join Cus in _context.Customer on Ty.CustType equals Cus.CustType
                           join ti in _context.Title on Cus.InitialCode equals ti.InitialCode
                           select new
                           {
                               ti.InitialCode,
                               ti.InitialName,
                               Cus.CustId,
                               Cus.Name,
                               Cus.Lastname,
                               Ty.CustType,
                               Ty.NameType

                           };

            return Customer;
        }

        // GET: api/TCustomers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Customer = await _context.Customer.FindAsync(id);

            if (Customer == null)
            {
                return NotFound();
            }

            return Ok(Customer);
        }

        // PUT: api/TCustomers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] string id, [FromBody] Customer Customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != Customer.CustId)
            {
                return BadRequest();
            }

            _context.Entry(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TCustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TCustomers
        [HttpPost]
        public async Task<IActionResult> PostTCustomer([FromBody] Customer tCustomer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Customer.Add(tCustomer);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TCustomerExists(tCustomer.CustId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTCustomer", new { id = tCustomer.CustId }, tCustomer);
        }

        // DELETE: api/TCustomers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTCustomer([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tCustomer = await _context.Customer.FindAsync(id);
            if (tCustomer == null)
            {
                return NotFound();
            }

            _context.Customer.Remove(tCustomer);
            await _context.SaveChangesAsync();

            return Ok(tCustomer);
        }

        private bool TCustomerExists(string id)
        {
            return _context.Customer.Any(e => e.CustId == id);
        }
    }
}