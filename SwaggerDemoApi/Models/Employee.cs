namespace SwaggerDemoApi.Models
{
    /// <summary>
    /// Employee Class
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Name : String
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// EmpID : Unique alphanumeric value 
        /// </summary>
        public string EmpId { get; set; }
        /// <summary>
        /// Age : employee's age
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Address : Employee's address
        /// </summary>
        public string Address { get; set; }
    }
}