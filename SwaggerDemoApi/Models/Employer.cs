using System.Collections.Generic;

namespace SwaggerDemoApi.Models
{
    /// <summary>
    /// Employer class 
    /// </summary>
    public class Employer
    {
        /// <summary>
        /// Name : Employer Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// NetWorth : Employer's Net cost 
        /// </summary>
        public string NetWorth { get; set; }
        /// <summary>
        /// Address : Employer address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Employees : All the employee's id under the employer 
        /// </summary>
        public List<string> Employees { get; set; }
    }
}