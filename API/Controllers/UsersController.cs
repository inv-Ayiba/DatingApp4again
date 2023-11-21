using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers;
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context )
        {
            _context = context;
            
        }
        //Synchronous
        // [HttpGet]
        // public ActionResult<IEnumerable<AppUser>> GetUsers()
        // {
        //     var users = _context.Users.ToList();
        //     return users;
        // }
        // [HttpGet("{id}")]
        // public ActionResult<AppUser> GetUser(int id)
        // {
        //     return _context.Users.Find(id);
        // }

//ASynchronous
 [AllowAnonymous]
         [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return  users;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return  await _context.Users.FindAsync(id);
        }
    }
