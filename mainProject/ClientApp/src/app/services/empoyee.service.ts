import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Employee } from '../models/employee';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class EmpoyeeService {
  constructor(private httpClient: HttpClient) {}

  getEmployees(baseUrl: string): Observable<Employee[]> {
    return this.httpClient.get<Employee[]>(
      baseUrl+'api/employees'
    );
  }

  getEmployeeById(baseUrl: string, id: string): Observable<Employee> {
    return this.httpClient.get<Employee>(
      baseUrl+`api/employees/${id}`
    );
  }
}
