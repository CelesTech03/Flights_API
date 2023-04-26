using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FlightsAPI.Models;

namespace FlightsAPI.Controllers
{
    [Route("api/passengers")]
    [ApiController]
    public class PassengerController : ControllerBase
    {
        private readonly FlightsAPIDBContext _context;

        public PassengerController(FlightsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Passengers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Passenger>>> GetPassengers()
        {
            var response = new Response();
            try
            {
                var passengers = await _context.Passengers.ToListAsync();
                if (passengers.Count == 0)
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "Unsuccessful, no passengers data found";
                    return NotFound(response);
                }
                response.StatusCode = 200;
                response.StatusDescription = "Success, passengers data found";
                response.Data = passengers;
                return Ok(response);
            }
            catch (Exception)
            {
                response.StatusCode = 500;
                response.StatusDescription = "Internal server error";
                return StatusCode(500, response);
            }
        }

        // GET: api/Passengers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Passenger>> GetPassenger(int id)
        {
          if (_context.Passengers == null)
          {
              return NotFound();
          }
            var passenger = await _context.Passengers.FindAsync(id);
            var response = new Response();

            if (passenger == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Unsuccessful, no passenger data found with that id";
                return NotFound(response);
            }

            response.StatusCode = 200;
            response.StatusDescription = "Success, passenger data found with that id";
            response.Data = passenger;
            return Ok(response);
        }

        // PUT: api/Passengers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPassenger(int id, Passenger passenger)
        {
            var response = new Response();
            if (id != passenger.PassengerId)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request, invalid passenger ID";
                return BadRequest(response);
            }

            _context.Entry(passenger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerExists(id))
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "Unsuccessful, no passenger data found with that ID";
                    return NotFound(response);
                }
                else
                {
                    throw;
                }
            }

            response.StatusCode = 204;
            response.StatusDescription = "Success, passenger updated";
            return Ok(response);
        }

        // POST: api/Passengers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Passenger>> PostPassenger(Passenger passenger)
        {
            var response = new Response();
            if (_context.Passengers == null)
          {
              return Problem("Entity set 'FlightsAPIDBContext.Passengers'  is null.");
          }
            _context.Passengers.Add(passenger);
            await _context.SaveChangesAsync();

            response.StatusCode = 201;
            response.StatusDescription = "Success, passenger created";
            return CreatedAtAction("GetPassenger", new { id = passenger.PassengerId }, response);
        }

        // DELETE: api/Passengers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePassenger(int id)
        {
            var response = new Response();
            if (_context.Passengers == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Unsuccessful, no passenger data found";
                return NotFound(response);
            }
            var passenger = await _context.Passengers.FindAsync(id);
            if (passenger == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Unsuccessful, no passenger data found with that id";
                return NotFound(response);
            }

            _context.Passengers.Remove(passenger);
            await _context.SaveChangesAsync();

            response.StatusCode = 204;
            response.StatusDescription = "Success, passenger data deleted";
            return Ok(response);
        }

        private bool PassengerExists(int id)
        {
            return (_context.Passengers?.Any(e => e.PassengerId == id)).GetValueOrDefault();
        }
    }
}
