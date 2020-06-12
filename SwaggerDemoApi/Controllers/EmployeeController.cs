using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Web.Http;
using System.Web.Http.Description;
using SwaggerDemoApi.Models;
using SwaggerDemoApi.Services;

namespace SwaggerDemoApi.Controllers
{
    public class EmployeeController : ApiController
    {
        private EmployeeService _service = EmployeeService.Instance;

        /// <summary>
        /// Get all employees 
        /// </summary>
        /// <remarks>
        /// Get a list of employees
        /// </remarks>
        /// <returns></returns>
        /// <response code="200"></response>
        [ResponseType(typeof(IEnumerable<Employee>))]
        public IEnumerable<Employee> Get()
            {
                return _service.GetAllEmployees();
            }


        /// <summary>
        /// Get all employees 
        /// </summary>
        /// <remarks>
        /// Get Employees for a particular employer
        /// </remarks>
        /// <param name="name">Enter employer Name</param>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpGet]
        [Route("GetEmployeeByEmployerName")]
        [ResponseType(typeof(IEnumerable<Employee>))]
        public IEnumerable<Employee> Get(string name)
        {
            return _service.GetEmployeesByEmployeeName(name);
        }


        // GET api/values/5
        /* public string Get(int id)
         {
             return "value";
         }*/

        /// <summary>
        /// Add/Update employees to Employee Table
        /// </summary>
        /// <remarks>
        /// Add/Update employees to Employee Table
        /// </remarks>
        /// <param name="employee">Enter employer Name</param>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpPost]
        [Route("AddEmployee")]
        public string Post([FromBody]Employee employee)
        {
            return _service.AddEmployee(employee);
        }


        /// <summary>
        /// Delete employee from employee table
        /// </summary>
        /// <remarks>
        /// Delete employee from employee table
        /// </remarks>
        /// <param name="id">Enter employee id to delete</param>
        /// <returns></returns>
        /// <response code="200"></response>
        [HttpDelete]
        [Route("DeleteEmployee")]
        public string Delete(string empId)
        {
            return _service.DeleteEmployee(empId);
        }
    }
}
