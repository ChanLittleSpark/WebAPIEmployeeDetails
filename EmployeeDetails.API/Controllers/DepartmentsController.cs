using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EmployeeDetails.API.Repository.Models;
using EmployeeDetails.API.Services;

namespace EmployeeDetails.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        //private readonly EmployeeDatabaseContext _context;
        private readonly IDepartmentServices _departmentServices;

        public DepartmentsController(IDepartmentServices departmentServices)
        {
            //_context = context;
            _departmentServices = departmentServices;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departments>>> GetDepartments()
        {
            return await _departmentServices.GetDepartments();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departments>> GetDepartments(long id)
        {
            var departments = await _departmentServices.GetDepartments(id);
            if (departments == null)
            {
                return NotFound();
            }
            return departments;

        }


        // PUT: api/Departments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartments([FromRoute]long id, [FromBody] Departments departments)
        {

            await _departmentServices.PutDepartments(id, departments);
            return Ok(departments);
            /*if (id != departments.DepartmentId)
            {
                return BadRequest();
            }
            _context.Entry(departments).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
*/
 
        }

        // POST: api/Departments
        [HttpPost]
        public async Task<ActionResult<Departments>> PostDepartments(Departments departments)
        {
            await _departmentServices.PostDepartments(departments);
            return CreatedAtAction("GetDepartments", new { id = departments.DepartmentId }, departments);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Departments>> DeleteDepartments(long id)
        {
            var departments = await _departmentServices.DeleteDepartments(id);
            if (departments == null)
            {
                return NotFound("Employee was Not Found with ID " + id);
            }
            return departments;
        }

        
    }
}
