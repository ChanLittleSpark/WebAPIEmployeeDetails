using EmployeeDetails.API.Repository;
using EmployeeDetails.API.Repository.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository;
        /// <summary>
        /// Service Constructor For Employee Model.
        /// </summary>
        /// <param name="employeeRepository"></param>
        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public async Task<ActionResult<Employee>> DeleteEmployee(long id)
        {
            return await _employeeRepository.DeleteEmployee(id);
        }

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployee()
        {
            var result=await _employeeRepository.GetEmployee();
            return result;
        }

        public async Task<ActionResult<Employee>> GetEmployee(long id)
        {
            return await _employeeRepository.GetEmployee(id);
        }

        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            return await _employeeRepository.PostEmployee(employee);
        }

        public async Task PutEmployee(long id, Employee employee)
        {
            await _employeeRepository.PutEmployee(id, employee);
        }

        public async Task UpdateEmployeePatch([FromRoute] long id, [FromBody] JsonPatchDocument booksModel)
        {
            await _employeeRepository.UpdateEmployeePatch(id, booksModel);
        }
    }
}
