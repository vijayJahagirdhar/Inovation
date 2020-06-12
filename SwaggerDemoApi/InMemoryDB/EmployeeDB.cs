using System;
using System.Collections.Generic;
using System.Security.Permissions;
using SwaggerDemoApi.Models;

namespace SwaggerDemoApi.InMemoryDB
{
    /// <summary>
    ///  EmployeeDb inmemory  
    /// </summary>
    public class EmployeeDb
    {
        /// <summary>
        ///Stores all the employee details
        /// </summary>
        public List<Employee> Employees { get; set; }

        private static  readonly Lazy<EmployeeDb> lazy = new Lazy<EmployeeDb>(() => new EmployeeDb());

        /// <summary>
        /// GIves a singleton instance 
        /// </summary>
        public static EmployeeDb Instance = lazy.Value;

        /// <summary>
        /// Default constructor to initialize employees
        /// </summary>
        public EmployeeDb()
        {
            Employees = LoadEmployees();
        }

        private List<Employee> LoadEmployees()
        {
            var list = new List<Employee>();
            list.Add(new Employee() { Name= "vijay", EmpId = "vitvij01",Age=100,Address="ABC"});
            list.Add(new Employee() { Name = "pallavi", EmpId = "negpal01", Age = 100, Address = "ABC" });
            list.Add(new Employee() { Name = "srejith", EmpId = "putsre01", Age = 100, Address = "ABC1" });
            list.Add(new Employee() { Name = "firoj", EmpId = "shefir01", Age = 100, Address = "ABC2" });
            list.Add(new Employee() { Name = "sruthi", EmpId = "jaishr01", Age = 100, Address = "ABC3" });
            list.Add(new Employee() { Name = "harshita", EmpId = "sinhar01", Age = 100, Address = "ABC4" });
            list.Add(new Employee() { Name = "shivraj", EmpId = "nagshi01", Age = 100, Address = "ABC4" });
            return list;
        }
    }
}