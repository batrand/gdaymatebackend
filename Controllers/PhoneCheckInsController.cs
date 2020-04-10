using System;
using System.Collections.Generic;
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
            await _context.SaveChangesAsync();

            // TODO: parse check in and RedirectToAction to checkin and add new checkin here
            // Parse the result
            var responses = checkin.Responses.Split("|").ToList();
            responses.RemoveRange(0, 3); // remove the first 3 questions
            
            var answers = new List<int>();
            foreach (var r in responses)
            {
                // each response's format is T10~menu~Frequency~2~Weekly
                var parts = r.Split("~");
                var answer = parts[3];
                var result = int.TryParse(answer, out var intAnswer);
                if (result) answers.Add(int.Parse(answer));
            }

            // find appropriate user
            var user = await _context.Users.FirstAsync(u => u.PhoneNumber == checkin.PhoneNumber);
            return RedirectToAction("PostCheckIn", "CheckIns", new
            {
                checkIn = new CheckIn
                {
                    UserId = user.Id,
                    User = user,
                    Responses = answers
                }
            });
        }
    }
}