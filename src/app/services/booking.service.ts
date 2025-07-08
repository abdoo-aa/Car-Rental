import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root'
})
export class BookingService {
  private baseUrl = 'https://localhost:44391/api/booking';

  constructor(private http: HttpClient, private authService: AuthService) {}

  /** Fetch bookings for logged-in user */
  getUserBookings(): Observable<any> {
    const user = this.authService.decodeToken();
    if (!user) return new Observable(observer => observer.error("No user token found!"));

    return this.http.post(`${this.baseUrl}/user`, { username: user.username });
  }
  getTotalBookings(): Observable<number> {
    return this.http.get<number>(`${this.baseUrl}/total`);
  }

  getUserCountBookings(username: string): Observable<number> {
    return this.http.get<number>(`${this.baseUrl}/totaluserbooking/${username}`);
  }

  /** Fetch all bookings (Admin only) */
  getAllBookings(): Observable<any> {
    return this.http.get(`${this.baseUrl}/all`);
  }

  /** Approve booking (Admin) */
  approveBooking(bookingId: number): Observable<any> {
    return this.http.put(`${this.baseUrl}/approve/${bookingId}`, {});
  }

  /** Reject booking (Admin) */
  rejectBooking(bookingId: number): Observable<any> {
    return this.http.put(`${this.baseUrl}/reject/${bookingId}`, {});
  }

  /** Cancel booking (User) */
  cancelBooking(bookingId: number): Observable<any> {
    return this.http.put(`${this.baseUrl}/cancel/${bookingId}`, {});
  }

  confirmBooking(userId: number,carId: number, price: number, startDate: number, endDate: number): Observable<any> {
    const user = this.authService.decodeToken();
    if (!user) {
      return new Observable(observer => {
        observer.error("User not authenticated");
        observer.complete();
      });
    }

    return this.http.post(`${this.baseUrl}/confirmbooking`, {
      userId, // Extract UserId from JWT
      carId,
      price,
      startDate,
      endDate
    });
  }
  /** Fetch count of canceled bookings for a user */
  getUserCancelledBookings(username: string): Observable<number> {
    return this.http.get<number>(`${this.baseUrl}/cancelledBookings/${username}`);
  }
  getPendingBookingsCount():Observable<any>{
    return this.http.get<number>(`${this.baseUrl}/pendingBookings`);
  }
  returnCar(bookingId: number): Observable<any> {
    return this.http.put(`${this.baseUrl}/return/${bookingId}`, {});
  }
}
