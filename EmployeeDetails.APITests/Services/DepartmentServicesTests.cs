using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeDetails.API.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using EmployeeDetails.API.Repository;
using EmployeeDetails.API.Repository.Models;
using EmployeeDetails.API.Controllers;

namespace EmployeeDetails.API.Services.Tests
{
    [TestClass]
    public class DepartmentServicesTests
    {
        //Mocking the Interfaces
        private readonly Mock<IDepartmentRepository> _departmentRepositoryMock 
            = new Mock<IDepartmentRepository>();

        private readonly DepartmentServices _departmentServices;
        public DepartmentServicesTests()
        {
            _departmentServices = new DepartmentServices(_departmentRepositoryMock.Object);
           //_departmentServices = departmentServices(_departmentRepository.Object); 
        }

        [TestMethod]
        public async Task GetDepartmentTest()
        {
            //Arrange
            long id = 2;
            string name = "Tester";
            var departments = new Departments
            {
                DepartmentId = id,
                DepartmentName = name
            };
            
            _departmentRepositoryMock.Setup(x => x.GetDepartments(id))
                .ReturnsAsync(departments);//This is Repository Call
            //Act
            //DepartmentsController departmentsController = new DepartmentsController(_departmentServices);
            
            var department = await _departmentServices.GetDepartments(id); //This is the Service Call

            Assert.IsTrue(department.Equals(departments));
        }
    }
}