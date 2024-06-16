using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActiveOutageApi.Data;
using ActiveOutageApi.VmOms;

namespace ActiveOutageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionOmsController : ControllerBase
    {
        private readonly ActiveOutageDbContext _context;

        public RegionOmsController(ActiveOutageDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionOms>>> GetRegionOms()
        {
            try
            {
                var RegionOms = await _context.RegionOms.FromSqlRaw("SELECT * FROM [dbo].[vm_oms_pom_region]").ToListAsync();
                return Ok(RegionOms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
