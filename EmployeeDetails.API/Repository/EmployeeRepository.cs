using EmployeeDetails.API.Repository.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Repository
{
    /// <summary>
    /// Repository Constructor for Employee Model
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDatabaseContext _context;

        public EmployeeRepository(EmployeeDatabaseContext context)
        {
            _context = context;
        }
        private bool EmployeeExists(long id)
        {
            return _context.Employee.Any(e => e.EmployeeId == id);
        }
        public async Task<ActionResult<Employee>> DeleteEmployee(long id)
        {
            var result = await _context.Employee.FindAsync(id);
            if (result == null)
            {
                return result;
            }
            _context.Employee.Remove(result);
            await _context.SaveChangesAsync();
            return result;

        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            return await _context.Employee.ToListAsync();
        }

        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            var result = await _context.Employee.FindAsync(id);
            return result;
        }

        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task PutEmployee(long id, Employee employee)
        {
            var find = await _context.Employee.FindAsync(id);

            if (find != null)
            {
                find.EmployeeName = employee.EmployeeName;
                find.Department = employee.Department;
                find.MailId = employee.MailId;
                find.Doj = employee.Doj;
                await _context.SaveChangesAsync();
            }


            /*_context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return "Not Found";
                }
                else
                {
                    throw;
                }
            }*/


        }

        public async Task UpdateEmployeePatch([FromRoute]long id, [FromBody] JsonPatchDocument employee)
        {
            var book = await _context.Employee.FindAsync(id);
            if (book != null)
            {
                employee.ApplyTo(book);
                await _context.SaveChangesAsync();
            }
        }
    }
}

        /*var result = await _context.Employee.FindAsync(id);
        if(result!=null)
        {
            result.Department = employee.Department;
            await _context.SaveChangesAsync();
        }*/
        /*_context.Entry(employee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if(!EmployeeExists(id))
            {
                return "NotFound";
            }
        }*/

    
    

