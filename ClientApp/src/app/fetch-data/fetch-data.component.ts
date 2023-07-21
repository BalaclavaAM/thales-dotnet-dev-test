import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { EmpoyeeService } from '../services/empoyee.service';
import { Employee } from '../models/employee';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public employees: Employee[] = [];

  public formEmployee = new FormGroup({
    id: new FormControl('')
  })

  constructor(private employeeService: EmpoyeeService) {
  }

  getEmployees() {
    const id = this.formEmployee.get('id')?.value;
    if (id) {
      this.employeeService.getEmployeeById('https://localhost:7134/', id).forEach(employee => {
        this.employees = [];
        this.employees.push(employee);
      });
    }
    else {
      this.employeeService.getEmployees('https://localhost:7134/').forEach(employees => {
        this.employees = employees;
      });
    }
  }
}