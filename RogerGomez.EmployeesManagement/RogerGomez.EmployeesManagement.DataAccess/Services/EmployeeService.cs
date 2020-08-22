using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RogerGomez.EmployeesManagement.DataAccess.Services
{
    public class EmployeeService
    {
        private readonly HttpClient _httpClient;
        private const string APIENDPOINT = "Employees";
        public EmployeeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<string> GetEmployees()
        {
            var response = await _httpClient.GetAsync(APIENDPOINT);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
