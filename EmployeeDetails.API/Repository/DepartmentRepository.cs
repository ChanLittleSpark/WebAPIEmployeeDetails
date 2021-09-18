using EmployeeDetails.API.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeDatabaseContext _context;

        public DepartmentRepository(EmployeeDatabaseContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Departments>> DeleteDepartments(long id)
        {
            var departments = await _context.Departments.FindAsync(id);
            if(departments==null)
            {
                return departments;
            }
            _context.Departments.Remove(departments);
            await _context.SaveChangesAsync();
            return departments;

        }

        public async Task<ActionResult<IEnumerable<Departments>>> GetDepartments()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<ActionResult<Departments>> GetDepartments(long id)
        {
            var employeedetails = await _context.Departments.FindAsync(id);
            return employeedetails;
        }

        public async Task<ActionResult<Departments>> PostDepartments(Departments departments)
        {
            _context.Departments.Add(departments);
            await _context.SaveChangesAsync();
            return departments;
        }

        public async Task PutDepartments(long id, Departments departments)
        {
            var find = await _context.Departments.FindAsync(id);

            if (find != null)
            {
                find.DepartmentName= departments.DepartmentName;
                await _context.SaveChangesAsync();
            }
        }
    }
}

