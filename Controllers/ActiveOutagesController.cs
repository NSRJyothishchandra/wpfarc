using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActiveOutageApi.Models;
using ActiveOutageApi.Data;

namespace ActiveOutageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OutagesController : ControllerBase
    {
        private readonly ActiveOutageDbContext _context;

        public OutagesController(ActiveOutageDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ActiveOutage>>> GetActiveOutages()
        {
            try
            {
                return await _context.ActiveOutages.ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
