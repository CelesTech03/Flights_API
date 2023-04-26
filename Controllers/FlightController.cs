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
    [Route("api/flights")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly FlightsAPIDBContext _context;

        public FlightController(FlightsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Flights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFlights()
        {
            var response = new Response();
            try
            {
                var flights = await _context.Flights.ToListAsync();
                if (flights.Count == 0)
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "Unsuccessful, no flights data found";
                    return NotFound(response);
                }
                response.StatusCode = 200;
                response.StatusDescription = "Success, flights data found";
                response.Data = flights;
                return Ok(response);
            }
            catch (Exception)
            {
                response.StatusCode = 500;
                response.StatusDescription = "Internal server error";
                return StatusCode(500, response);
            }
        }

        // GET: api/Flights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flight>> GetFlight(int id)
        {
            if (_context.Flights == null)
            {
                return NotFound();
            }
            var flight = await _context.Flights.FindAsync(id);
            var response = new Response();

            if (flight == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Unsuccessful, no flight data found with that id";
                return NotFound(response);
            }
            response.StatusCode = 200;
            response.StatusDescription = "Success, flight data found with that id";
            response.Data = flight;
            return Ok(response);
        }

        // PUT: api/Flights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlight(int id, Flight flight)
        {
            var response = new Response();
            if (id != flight.FlightId)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request, invalid flight ID";
                return BadRequest(response);
            }

            _context.Entry(flight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightExists(id))
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "Unsuccessful, no flight data found with that ID";
                    return NotFound(response);
                }
                else
                {
                    throw;
                }
            }

            response.StatusCode = 204;
            response.StatusDescription = "Success, flight updated";
            return Ok(response);
        }

        // POST: api/Flights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Flight>> PostFlight(Flight flight)
        {
            var response = new Response();
            if (_context.Flights == null)
            {
                return Problem("Entity set 'FlightsAPIDBContext.Flights'  is null.");
            }
            _context.Flights.Add(flight);
            await _context.SaveChangesAsync();

            response.StatusCode = 201;
            response.StatusDescription = "Success, flight created";
            return CreatedAtAction("GetFlight", new { id = flight.FlightId }, response);
        }

        // DELETE: api/Flights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var response = new Response();
            if (_context.Flights == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Unsuccessful, no flight data found";
                return NotFound(response);
            }
            var flight = await _context.Flights.FindAsync(id);
            if (flight == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Unsuccessful, no flight data found with that id";
                return NotFound(response);
            }

            _context.Flights.Remove(flight);
            await _context.SaveChangesAsync();

            response.StatusCode = 204;
            response.StatusDescription = "Success, flight data deleted";
            return Ok(response);
        }

        private bool FlightExists(int id)
        {
            return (_context.Flights?.Any(e => e.FlightId == id)).GetValueOrDefault();
        }
    }
}