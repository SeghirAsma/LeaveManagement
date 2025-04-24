using AutoMapper;
using Leave_Management_System.Data;
using Leave_Management_System.Entities;
using Leave_Management_System.Strategy_Pattern;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;


namespace Leave_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly DBContextLeaveManagement _dbContext;
        private readonly IMapper _mapper;
        public LeaveRequestsController(DBContextLeaveManagement dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> GetAll()
        {
            var leaveRequests = await _dbContext.LeaveRequests.Include(lr => lr.Employee).ToListAsync();
            var leaveRequestDtos = _mapper.Map<List<LeaveRequestDto>>(leaveRequests);
            return Ok(leaveRequestDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LeaveRequestDto>> Get(int id)
        {
            var request = await _dbContext.LeaveRequests.Include(lr => lr.Employee).FirstOrDefaultAsync(lr => lr.Id == id);
            if (request == null)
                return NotFound();

            var leaveRequestDto = _mapper.Map<LeaveRequestDto>(request);
            return Ok(leaveRequestDto);
        }

        [HttpPost]
        public async Task<ActionResult<LeaveRequests>> CreateLeaveRequest([FromBody] LeaveRequests request)
        {
            var strategy = LeaveValidationStrategyFactory.GetStrategy(request.LeaveType);

            if (!strategy.IsValid(request, out string errorMessage))
            {
                return BadRequest(new { message = errorMessage }); 
            }

            request.Status = LeaveStatus.Pending;
            request.CreatedAt = DateTime.Now;

            _dbContext.LeaveRequests.Add(request);
            await _dbContext.SaveChangesAsync();
            return Ok(request);
        }

        /* public async Task<ActionResult<LeaveRequests>> Create(LeaveRequests lr)
         {

             lr.CreatedAt = DateTime.Now;
             _dbContext.LeaveRequests.Add(lr);
             await _dbContext.SaveChangesAsync();
             return CreatedAtAction(nameof(Get), new { id = lr.Id }, lr);
         } */

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, LeaveRequests lr)
        {
            if (id != lr.Id)
                return BadRequest();
            _dbContext.Entry(lr).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var lr = await _dbContext.LeaveRequests.FindAsync(id);
            if (lr == null)
                return NotFound();
            _dbContext.LeaveRequests.Remove(lr);
            await _dbContext.SaveChangesAsync();
            return NoContent();
        }


        [HttpGet("filter")]
        public async Task<ActionResult<IEnumerable<LeaveRequestDto>>> Filter(
         int? employeeId,
         LeaveType? leaveType,
         LeaveStatus? status,
         DateTime? startDate,
         DateTime? endDate,
         string? keyword,
         string? sortBy = "startDate",
         string? sortOrder = "asc",
         int page = 1,
         int pageSize = 10)
        {
            // Initialisation de la requête de base
            var query = _dbContext.LeaveRequests
                .Include(l => l.Employee).AsQueryable();

            if (employeeId.HasValue)
                query = query.Where(l => l.EmployeeId == employeeId);

            if (leaveType.HasValue)
                query = query.Where(l => l.LeaveType == leaveType);

            if (status.HasValue)
                query = query.Where(l => l.Status == status);

            if (startDate.HasValue)
                query = query.Where(l => l.StartDate >= startDate);

            if (endDate.HasValue)
                query = query.Where(l => l.EndDate <= endDate);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(l => l.Reason!.Contains(keyword));

            //No overlapping leave dates per employee
            if (employeeId.HasValue && startDate.HasValue && endDate.HasValue)
            {
                var overlappingLeaves = await _dbContext.LeaveRequests
                    .Where(l => l.EmployeeId == employeeId &&
                                ((l.StartDate <= endDate && l.EndDate >= startDate) ||
                                 (l.StartDate >= startDate && l.StartDate <= endDate)))
                    .AnyAsync();

                if (overlappingLeaves)
                {
                    return BadRequest("There are overlapping leave dates for this employee.");
                }
            }

            // Tri dynamique basé sur sortBy
            if (sortBy?.ToLower() == "startdate")
            {
                query = sortOrder!.ToLower() == "desc"
                    ? query.OrderByDescending(l => l.StartDate)
                    : query.OrderBy(l => l.StartDate);
            }
            else if (sortBy?.ToLower() == "enddate")
            {
                query = sortOrder!.ToLower() == "desc"
                    ? query.OrderByDescending(l => l.EndDate)
                    : query.OrderBy(l => l.EndDate);
            }
            else if (sortBy?.ToLower() == "employeeid")
            {
                query = sortOrder!.ToLower() == "desc"
                    ? query.OrderByDescending(l => l.EmployeeId)
                    : query.OrderBy(l => l.EmployeeId);
            }

            // Vérification du nombre de jours de congé annuels
            if (leaveType == LeaveType.Annual && employeeId.HasValue && startDate.HasValue && endDate.HasValue)
            {
                var takenLeaves = await _dbContext.LeaveRequests
                    .Where(l => l.EmployeeId == employeeId.Value && 
                                l.LeaveType == LeaveType.Annual && 
                                l.StartDate.Year == startDate.Value.Year) 
                    .ToListAsync(); 

                int takenDays = takenLeaves.Sum(l => (l.EndDate - l.StartDate).Days + 1); 

                int requestedDays = (endDate.Value - startDate.Value).Days + 1;

                if (takenDays + requestedDays > 20)
                {
                    return BadRequest("You cannot take more than 20 days of annual leave per year.");
                }

            }

            // Vérifier si le type de congé est Sick et si la raison est vide
            if (leaveType == LeaveType.Sick && string.IsNullOrEmpty(keyword))
            {
                return BadRequest("Sick leave requires a non-empty reason.");
            }

            // Pagination
            var skip = (page - 1) * pageSize;
            var pagedResult = await query
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();

            var result = _mapper.Map<List<LeaveRequestDto>>(pagedResult);
            return Ok(result);
        }

        [HttpGet("report")]
        public async Task<ActionResult<IEnumerable<object>>> GetLeaveReport(
        int year,
        string? department = null,
        DateTime? startDate = null,
        DateTime? endDate = null)
        {
            var query = _dbContext.LeaveRequests
                .Where(l => l.StartDate.Year == year) 
                .Include(l => l.Employee)  
                .AsQueryable();
            
            if (!string.IsNullOrEmpty(department))
            {
                query = query.Where(l => l.Employee!.Department == department);
            }
            if (startDate.HasValue)
            {
                query = query.Where(l => l.StartDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(l => l.EndDate <= endDate.Value);
            }

            var leaveRequests = await query.ToListAsync();

            var result = leaveRequests
                .Where(l => (l.StartDate.Year == year) &&
                (string.IsNullOrEmpty(department) || l.Employee!.Department == department) &&
                (l.Status == LeaveStatus.Approved))
                .GroupBy(l => l.EmployeeId) 
                .Select(g => new
                {
                    EmployeeName = g.FirstOrDefault()!.Employee!.FullName,  
                    TotalLeaves = g.Sum(l => (l.EndDate - l.StartDate).Days + 1),
                    AnnualLeaves = g.Where(l => l.LeaveType == LeaveType.Annual).Sum(l => (l.EndDate - l.StartDate).Days + 1),
                    SickLeaves = g.Where(l => l.LeaveType == LeaveType.Sick).Sum(l => (l.EndDate - l.StartDate).Days + 1)
                })
                .ToList();

            return Ok(result);  
        }
        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveLeaveRequest(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests.FindAsync(id);

            if (leaveRequest == null)
            {
                return NotFound(new { message = "Leave request not found." });
            }

            if (leaveRequest.Status != LeaveStatus.Pending)
            {
                return BadRequest(new { message = "Only pending leave requests can be approved." });
            }

            leaveRequest.Status = LeaveStatus.Approved;
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Leave request approved successfully." });
        }



    }
}
