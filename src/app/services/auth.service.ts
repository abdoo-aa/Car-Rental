import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { jwtDecode } from 'jwt-decode';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'https://localhost:44391/api';
  private authStatus = new BehaviorSubject<boolean>(this.hasToken());
  private isLoadingSubject = new BehaviorSubject<boolean>(false); // ✅ Initialize loading state
  isLoading$ = this.isLoadingSubject.asObservable(); 
  constructor(private http: HttpClient) {}

  register(user: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/auth/register`, {
      username: user.username,
      PasswordHash: user.password, //  Send only `password`, backend will hash
      email: user.email
    });
  }

  login(credentials: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/auth/login`, {
      username: credentials.username,
      PasswordHash: credentials.password
    });
  }

  logout(): void {
    localStorage.removeItem('token');
    this.authStatus.next(false); //  Notify subscribers that user is logged out
  }

  saveToken(token: string): void {
    localStorage.setItem('token', token);
    this.authStatus.next(true); //  Notify subscribers that user is logged in
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  isAuthenticated(): boolean {
    return !!this.getToken();
  }

  authStatus$ = this.authStatus.asObservable(); // Observable to listen for login/logout changes

  private hasToken(): boolean {
    return !!localStorage.getItem('token');
  }
  
  decodeToken(): { userId: number; username: string; role: string } | null {
    const token = this.getToken();
    if (!token) return null;

    try {
      const decoded: any = jwtDecode(token);
      return {
        userId: decoded.id,
        username: decoded.unique_name || decoded.name,
        role: decoded.role
      };
    } catch (error) {
      console.error("❌ Invalid Token:", error);
      return null;
    }
  }

  getUserProfile(): Observable<any> {
    const decodedUser = this.decodeToken();
    if (!decodedUser) {
      return new Observable(observer => {
        observer.error("No token available");
        observer.complete();
      });
    }

    return this.http.post(`${this.baseUrl}/user/profile`, {
      username: decodedUser.username,
      role: decodedUser.role,
    });
  }
  getUserId(): Observable<any> {
    const decodedUser = this.decodeToken();
    if (!decodedUser) {
      return new Observable(observer => {
        observer.error("No token available");
        observer.complete();
      });
    }
    
    return this.http.get(`${this.baseUrl}/user/getUserByUsername?request=${decodedUser.username}`
    );
  }
  getUserByUsername(username: string):Observable<any>{
    return this.http.get(`${this.baseUrl}/user/getUserByUsername?request=${username}`);
  }
  getusername(username: string):Observable<any>{
    return this.http.post<any>(`${this.baseUrl}/user/getusername`,{username});
  }
  getUserByUserId(userId: number):Observable<any>{
    return this.http.get(`${this.baseUrl}/user/getUserByUserId?userId=${userId}`);
  }
  getAllUsers(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/user`);
  }
  getUserCount(): Observable<{ count: number }> {
    return this.http.get<{ count: number }>(`${this.baseUrl}/user/count`);
  }
  getUserUnblockCount(): Observable<{count: number}>{
    return this.http.get<{count: number}>(`${this.baseUrl}/user/unblockcount`);
  }
  
  setLoading(isLoading: boolean) {
    this.isLoadingSubject.next(isLoading);
  }
  blockUnblockUser(userId: number): Observable<any> {
    return this.http.post(`${this.baseUrl}/user/block-unblock/${userId}`, {});
  }
  
}
