import { Component, Input, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-car-reviews',
  templateUrl: './car-reviews.component.html',
  styleUrls: ['./car-reviews.component.scss']
})
export class CarReviewsComponent implements OnInit {
  @Input() carId!: number;
  reviews: any[] = [];
  loading: boolean = true;
    // Pagination Variables
    currentPage: number = 1;
    pageSize: number = 5; // 5 reviews per page
    totalPages: number = 0;
  

  constructor(private carService: CarService, private reviewSerivce: ReviewService) {}

  ngOnInit(): void {
    if (this.carId) {
      this.fetchReviews();
    }
  }

  fetchReviews(): void {
    this.reviewSerivce.getCarReviews(this.carId).subscribe(
      (data) => {
        this.reviews = data;
         // Sort reviews by date (latest first)
         this.reviews = data.sort((a: any, b: any) => new Date(b.reviewDate).getTime() - new Date(a.reviewDate).getTime());
        
         this.totalPages = Math.ceil(this.reviews.length / this.pageSize);
        this.loading = false;
      },
      (error) => {
        console.error('Error fetching reviews:', error);
        this.loading = false;
      }
    );
  }

  // Pagination Logic
  get paginatedReviews() {
    const startIndex = (this.currentPage - 1) * this.pageSize;
    const endIndex = startIndex + this.pageSize;
    return this.reviews.slice(startIndex, endIndex);
  }

  goToPage(page: number): void {
    this.currentPage = page;
  }
}
