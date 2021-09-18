using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeDetails.API.Repository.Models;
using EmployeeDetails.API.Services;
using Microsoft.AspNetCore.JsonPatch;

namespace EmployeeDetails.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeDatabaseContext _context;
        private readonly IEmployeeServices _employeeServices;

        public EmployeesController(EmployeeDatabaseContext context, IEmployeeServices employeeServices)
        {
            _context = context;
            _employeeServices = employeeServices;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _employeeServices.GetEmployee();
            //return await _context.Employee.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var employee = await _employeeServices.GetEmployee(id);
            //var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound("Employee with id : " + id + " not found");
            }
            return employee;
        }

        // PUT: api/Employees/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(long id, Employee employee)
        {
            await _employeeServices.PutEmployee(id, employee);
            return Ok(employee);
        } /*if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }*/

        // POST: api/Employees
        [HttpPost] //To Add new Employee to the DataBase
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            await _employeeServices.PostEmployee(employee);
            /*_context.Employee.Add(employee);
            await _context.SaveChangesAsync();
*/
            //return "Added Successfully";
            return CreatedAtAction("GetEmployee", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(long id)
        {
            var employee = await _employeeServices.DeleteEmployee(id);
            //var employee = await _context.Employee.FindAsync(id);
            if (employee != null)
            {
                return employee;
            }
            return NotFound();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateEmployeePatch([FromRoute] long id, [FromBody] JsonPatchDocument booksModel)
        {
            await _employeeServices.UpdateEmployeePatch(id, booksModel);
            return Ok();
        }
    }
}

            //"op":"replace","remove"
            //"path":"Attribute of the Table"
            //"value":"Value to be updated"
 
        /*private bool EmployeeExists(long id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }*/
 