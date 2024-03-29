using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{


    [ApiController]
    // Colocar en los parentesis [] hacen referencia al nombre incial de la clase controladora Users + Controller
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {

        private readonly DataContext context;
        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
           return await this.context.Users.ToListAsync();

            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await this.context.Users.FindAsync(id);

        }
    }
}