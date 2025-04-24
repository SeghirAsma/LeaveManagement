using AutoMapper;
using Leave_Management_System.Data;
using Leave_Management_System.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Leave_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DBContextLeaveManagement _dbContext;
        private readonly IMapper _mapper;

        public EmployeeController(DBContextLeaveManagement dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            var employees = await _dbContext.Employees.Include(e => e.LeaveRequests).ToListAsync();
            var employeeDtos = _mapper.Map<List<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> Get(int id)
        {
            var employee = await _dbContext.Employees.Include(e => e.LeaveRequests).FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return NotFound();

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return Ok(employeeDto);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Employee employee)
        {
            if (id != employee.Id)
                return BadRequest();

            _dbContext.Entry(employee).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var employee = await _dbContext.Employees.FindAsync(id);
            if (employee == null)
                return NotFound();

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
