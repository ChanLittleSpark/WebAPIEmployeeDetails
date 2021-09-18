using EmployeeDetails.API.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Repository
{
    public interface IDepartmentRepository
    {
        Task<ActionResult<IEnumerable<Departments>>> GetDepartments();
        Task<ActionResult<Departments>> GetDepartments(long id);
        Task PutDepartments(long id, Departments departments);
        Task<ActionResult<Departments>> PostDepartments(Departments departments);
        Task<ActionResult<Departments>> DeleteDepartments(long id);


    }
}
