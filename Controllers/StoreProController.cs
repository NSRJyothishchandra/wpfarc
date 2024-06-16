using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ActiveOutageApi.Models;
using ActiveOutageApi.Data;
using ActiveOutageApi.DTOs;

namespace ActiveOutageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreProController : ControllerBase
    {
        private readonly ActiveOutageDbContext _context;

        public StoreProController(ActiveOutageDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Storepro>>> GetSummaryData()
        {
            try
            {
                var storePro = await _context.Database.SqlQueryRaw<Storepro>("EXEC [dbo].[usp_pom_summary]").ToListAsync();
                return Ok(storePro);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message + Environment.NewLine + "Inner Exception: " + ex.InnerException.Message);
            }
        }
    }
}