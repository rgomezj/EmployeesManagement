import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html'
})
export class EmployeesComponent {
  public employees: Employee[];
  loadingEmployees: boolean;
  _httpClient: HttpClient;
  _baseURL: string;
  

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._httpClient = http;
    this._baseURL = baseUrl;
    
  }

  public getEmployees(formValue) {
    this.employees = [];
    this.loadingEmployees = true;
    this._httpClient.get<Employee[]>(this._baseURL + 'employee' + (formValue.employeeId ? "/" + formValue.employeeId : "")).subscribe(result => {
      this.loadingEmployees = false;
      if (!Array.isArray(result)) {
        this.employees = [result];
      }
      else {
        this.employees = result;
      }
    }, error => { this.loadingEmployees = false; console.error(error) });
  }
}

interface Employee {
  id: number;
  name: string;
  typeOfContract: string;
  roleName: string;
  roleDescription: string;
  hourlySalary: number;
  monthlySalary: number;
  salary: number;
}
