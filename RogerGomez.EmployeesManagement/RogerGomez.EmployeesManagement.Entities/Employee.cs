using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RogerGomez.EmployeesManagement.Entities
{
    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("contractTypeName", ItemConverterType = typeof(StringEnumConverter))]
        public TypeOfContract TypeOfContract { get; set; }

        [JsonProperty("roleId")]
        public int RoleId { get; set; }

        [JsonProperty("roleName")]
        public string RoleName { get; set; }

        [JsonProperty("roleDescription")]
        public string RoleDescription { get; set; }

        [JsonProperty("hourlySalary")]
        public decimal HourlySalary { get; set; }

        [JsonProperty("monthlySalary")]
        public decimal MonthlySalary { get; set; }

        public decimal Salary { get; set; }
    }

    public enum TypeOfContract
    {
        MonthlySalaryEmployee,
        HourlySalaryEmployee
    }
}
