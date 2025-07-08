import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CarService {

  private apiUrl = 'https://localhost:44391/api/car'; // Backend URL

  constructor(private http: HttpClient) {}

  getCars(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  getCarById(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/getcars/${id}`);
  }
  getCarByIdstring(id: string): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  addCar(carData: FormData): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}`, carData);
}

updateCar(id: number, carData: FormData): Observable<any> {
  return this.http.put<any>(`${this.apiUrl}/${id}`, carData);
}

  deleteCar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
  getCarCount(): Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/count`);
  }
  getCarAvalCount(): Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/avalcount`);
  }
}
