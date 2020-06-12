using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SwaggerDemoApi.InMemoryDB;
using SwaggerDemoApi.Models;
using WebGrease.Css.Extensions;

namespace SwaggerDemoApi.Services
{
    public class EmployeeService
    {
        private EmployeeDb _employee;
        private EmployerDb _employer;

        private static readonly Lazy<EmployeeService> lazy = new Lazy<EmployeeService>(() => new EmployeeService());

        /// <summary>
        /// GIves a singleton instance 
        /// </summary>
        public static EmployeeService Instance = lazy.Value;

        public EmployeeService()
        {
            _employee = EmployeeDb.Instance;
            _employer = EmployerDb.Instance;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employee.Employees;
        }

        public IEnumerable<Employee> GetEmployeesByEmployeeName(string name)
        {
            return _employer.Employers
                .Where(employer => employer.Name.Equals(name))
                .SelectMany(employer =>
                {
                    var list = employer.Employees;
                    return _employee.Employees.Where(emp => list.Contains(emp.EmpId)).ToList();
                });
        }

        public string AddEmployee(Employee employee)
        {
            if(!_employee.Employees.Select(e => e.EmpId).Contains(employee.EmpId))
            {
                if (!Validate(employee)) return $"Idiot please use your brain while adding data";
                _employee.Employees.Add(employee);
                return $"New Entry : Employee was added successfully {employee.EmpId}";
            }
            else
            {
                var existingEmployee = _employee.Employees.FirstOrDefault(e => e.EmpId.Equals(employee.EmpId));
                _employee.Employees.Remove(existingEmployee);
                existingEmployee.Age = employee.Age;
                existingEmployee.Name = employee.Name;
                existingEmployee.Address = employee.Address;
                existingEmployee.EmpId = employee.EmpId;
                _employee.Employees.Add(employee);

                return $"Existing Entry : Employee was updated successfully {employee.EmpId}";
            }
        }

        private bool Validate(Employee employee)
        {
            return !string.IsNullOrWhiteSpace(employee.EmpId);
        }

        public string DeleteEmployee(string empId)
        {
            if (!_employee.Employees.Select(e => e.EmpId).Contains(empId))
            {
                return $"{empId} doesn't exist to delete";
            }
            else
            {
                var existingEmployee = _employee.Employees.FirstOrDefault(e => e.EmpId.Equals(empId));
                _employee.Employees.Remove(existingEmployee);
                _employer.Employers.Where(e => e.Employees.Contains(empId)).ForEach(emp => emp.Employees.Remove(empId));
                return $"Employee ({empId}) has been deleted successfully";
            }
        }
    }
}


