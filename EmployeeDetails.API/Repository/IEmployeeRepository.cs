using EmployeeDetails.API.Repository.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Repository
{
    public interface IEmployeeRepository
    {
        Task<ActionResult<IEnumerable<Employee>>> GetEmployee();
        Task<ActionResult<Employee>> GetEmployee(long id);
        Task PutEmployee(long id, Employee employee);
        Task<ActionResult<Employee>> PostEmployee(Employee employee);
        Task<ActionResult<Employee>> DeleteEmployee(long id);
        Task UpdateEmployeePatch([FromRoute] long id, [FromBody] JsonPatchDocument booksModel);
    }
}
