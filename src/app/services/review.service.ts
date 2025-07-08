import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ReviewService {

  private apiUrl = 'https://localhost:44391/api/CarReview';
  constructor(private http: HttpClient) { }
  getReviewsByCar(carId: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/Car/${carId}`);
  }

  // 2. Get average rating of a car
  getAverageRating(carId: number): Observable<any> {
    return this.http.get(`${this.apiUrl}/AverageRating/${carId}`);
  }

  // 3. Add a new review
  submitReview(review: any): Observable<any> {
    return this.http.post(this.apiUrl, review);
  }

  // 4. Edit a review
  editReview(id: number, review: any): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, review);
  }

  // 5. Delete a review
  deleteReview(id: number, review: any): Observable<any> {
    return this.http.request('delete', `${this.apiUrl}/${id}`, { body: review });
  }
  getUserReviews(userId: number): Observable<{ carId: number; rating: number; reviewText: string }[]> {
    return this.http.get<{ carId: number; rating: number; reviewText: string }[]>(`${this.apiUrl}/user/${userId}`);
  }
  getCarReviews(carId: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/Car/${carId}`);
  }
  getAvgRating(carId:number): Observable<any>{
    return this.http.get<any>(`${this.apiUrl}/AverageRating/${carId}`);
  }
  
}
