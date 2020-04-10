using System;
using System.Linq;
using System.Threading.Tasks;
using GDayMateBackend.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GDayMateBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneCheckInsController: ControllerBase
    {
        private readonly AppDbContext _context;

        public PhoneCheckInsController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/PhoneCheckIns
        [HttpPost]
        public async Task<ActionResult<User>> AddPhoneCheckIn([FromBody] RawPhoneCheckIn rawCheckIn)
        {
            var checkin = new PhoneCheckIn
            {
                PhoneNumber = rawCheckIn.Detail.Destination,
                Responses = rawCheckIn.Detail.ResponsesString,
                Timestamp = DateTimeOffset.ParseExact(rawCheckIn.Timestamp, @"yyyy-MM-dd HH:mm:ss.ffffff", null)
            };
            await _context.PhoneCheckIns.AddAsync(checkin);

            // TODO: parse check in and RedirectToAction to checkin and add new checkin here
            
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}