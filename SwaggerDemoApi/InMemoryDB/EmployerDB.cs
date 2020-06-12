using System;
using System.Collections.Generic;
using SwaggerDemoApi.Models;

namespace SwaggerDemoApi.InMemoryDB
{
    /// <summary>
    ///  EmployeeDb in-memory  implementation
    /// </summary>
    public class EmployerDb
    {
        /// <summary>
        /// List of employers.
        /// </summary>
        public List<Employer> Employers { get; set; }

        private static readonly Lazy<EmployerDb> lazy = new Lazy<EmployerDb>(() => new EmployerDb());

        /// <summary>
        /// GIves a singleton instance 
        /// </summary>
        public static EmployerDb Instance = lazy.Value;


        public EmployerDb()
        {
            Employers = LoadEmployers();
        }

        private List<Employer> LoadEmployers()
        {
            var list = new List<Employer>();
            list.Add(new Employer() { Name = "CSG", NetWorth = "10000", Address = "ABC", Employees = new List<string>{"vitvij01", "putsre01", "shefir01","negpal01" } });
            list.Add(new Employer() { Name = "CSGI", NetWorth = "10000", Address = "ABC", Employees = new List<string> { "jaishr01", "sinhar01", "nagshi01"} });
            return list;
        }
    }
}