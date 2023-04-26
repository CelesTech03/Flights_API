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
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly FlightsAPIDBContext _context;

        public BookingController(FlightsAPIDBContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var response = new Response();
            try
            {
                var bookings = await _context.Bookings.ToListAsync();
                if (bookings.Count == 0)
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "Unsuccessful, no bookings data found";
                    return NotFound(response);
                }
                response.StatusCode = 200;
                response.StatusDescription = "Success, bookings data found";
                response.Data = bookings;
                return Ok(response);
            }
            catch (Exception)
            {
                response.StatusCode = 500;
                response.StatusDescription = "Internal server error";
                return StatusCode(500, response);
            }
        }

        // GET: api/Bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
          if (_context.Bookings == null)
          {
              return NotFound();
          }
            var booking = await _context.Bookings.FindAsync(id);
            var response = new Response();

            if (booking == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Unsuccessful, no booking data found with that id";
                return NotFound(response);
            }
            response.StatusCode = 200;
            response.StatusDescription = "Success, booking data found with that id";
            response.Data = booking;
            return Ok(response);
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            var response = new Response();
            if (id != booking.BookingId)
            {
                response.StatusCode = 400;
                response.StatusDescription = "Bad Request, invalid booking ID";
                return BadRequest(response);
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    response.StatusCode = 404;
                    response.StatusDescription = "Unsuccessful, no bookings data found with that ID";
                    return NotFound(response);
                }
                else
                {
                    throw;
                }
            }

            response.StatusCode = 204;
            response.StatusDescription = "Success, booking updated";
            return Ok(response);
        }

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            var response = new Response();
            if (_context.Bookings == null)
          {
              return Problem("Entity set 'FlightsAPIDBContext.Bookings'  is null.");
          }
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            response.StatusCode = 201;
            response.StatusDescription = "Success, booking created";
            return CreatedAtAction("GetBooking", new { id = booking.BookingId }, response);
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var response = new Response();
            if (_context.Bookings == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Unsuccessful, no booking data found";
                return NotFound(response);
            }
            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                response.StatusCode = 404;
                response.StatusDescription = "Unsuccessful, no booking data found with that id";
                return NotFound(response);
            }

            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();

            response.StatusCode = 204;
            response.StatusDescription = "Success, booking data deleted";
            return Ok(response);
        }

        private bool BookingExists(int id)
        {
            return (_context.Bookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
