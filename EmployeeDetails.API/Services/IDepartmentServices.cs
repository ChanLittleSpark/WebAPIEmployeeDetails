using EmployeeDetails.API.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Services
{
    public interface IDepartmentServices
    {
        Task<ActionResult<IEnumerable<Departments>>> GetDepartments();
        Task<ActionResult<Departments>> GetDepartments(long id);
        Task<ActionResult<Departments>> DeleteDepartments(long id);
        Task<ActionResult<Departments>> PostDepartments(Departments departments);
        Task PutDepartments(long id, Departments departments);
    }
}
