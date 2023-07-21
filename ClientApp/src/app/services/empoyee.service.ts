import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EmpoyeeService {
  constructor(private httpClient: HttpClient) {}

  getEmployees(): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(
      'https://localhost:44380/api/employees'
    );
  }

  getEmployeeById(id: number): Observable<Employee> {
    return this.httpClient.get<Employee>(
      `https://localhost:44380/api/employees/${id}`
    );
  }
}
