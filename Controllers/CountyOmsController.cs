//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using ActiveOutageApi.Data;
//using ActiveOutageApi.VmOms;

//namespace ActiveOutageApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class CountyOmsController : ControllerBase
//    {
//        private readonly ActiveOutageDbContext _context;

//        public CountyOmsController(ActiveOutageDbContext context)
//        {
//            _context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<CountyOms>>> GetCountyOms()
//        {
//            try
//            {
//                var CountyOms = await _context.CountyOms.FromSqlRaw("SELECT * FROM [dbo].[vm_oms_pom_county]").ToListAsync();
//                return Ok(CountyOms);
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(500, ex.Message);
//            }
//        }
//    }
//}
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
    public class CountyOmsController : ControllerBase
    {
        private readonly ActiveOutageDbContext _context;

        public CountyOmsController(ActiveOutageDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountyOms>>> GetCountyOms()
        {
            try
            {
                IEnumerable<CountyOms> countyOms = await _context.CountyOms.FromSqlRaw("SELECT * FROM [dbo].[vm_oms_pom_county]").ToListAsync();
                return Ok(countyOms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
