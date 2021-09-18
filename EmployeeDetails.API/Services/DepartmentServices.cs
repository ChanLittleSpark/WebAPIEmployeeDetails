using EmployeeDetails.API.Repository;
using EmployeeDetails.API.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeDetails.API.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;

        /// <summary>
        /// Constructor For Department Services.
        /// </summary>
        /// <param name="departmentServices"></param>
        public DepartmentServices(IDepartmentRepository departmentRepository)
        {    
            _departmentRepository = departmentRepository;
        }

        public async Task<ActionResult<Departments>> DeleteDepartments(long id)
        {
            return await _departmentRepository.DeleteDepartments(id);
        }

        public async Task<ActionResult<IEnumerable<Departments>>> GetDepartments()
        {
            return await _departmentRepository.GetDepartments();
        }

        public async Task<ActionResult<Departments>> GetDepartments(long id)
        {
            return await _departmentRepository.GetDepartments(id);
        }

        public async Task<ActionResult<Departments>> PostDepartments(Departments departments)
        {
            return await _departmentRepository.PostDepartments(departments);
        }

        public async Task PutDepartments(long id, Departments departments)
        {
            await _departmentRepository.PutDepartments(id, departments);
        }
    }
}
