using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelloLogging.Data;
using HelloLogging.Models;

namespace HelloLogging.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly HelloLoggingContext _context;

        public EmployeesController(HelloLoggingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await _context.Employee.Where(e=>e.Name == "Ibrahim Radi").ToListAsync();
        }
    }
}
