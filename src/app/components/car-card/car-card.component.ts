import { ViewportScroller } from '@angular/common';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-car-card',
  templateUrl: './car-card.component.html',
  styleUrls: ['./car-card.component.scss']
})
export class CarCardComponent implements OnInit {
  @Input() car: any;
  rating: number = 0;
  constructor(private viewportScroller: ViewportScroller, private reviewService: ReviewService) {}
  ngOnInit(): void {
    if(this.car && this.car.id)
    {
      this.getAvg(this.car.id);
    }
  }
  scrollToTop() {
    this.viewportScroller.scrollToPosition([0, 0]);
  }
  getDiscountedPrice(price: number, discount: number): number {
    return Math.round(price - (price * discount / 100)); // Rounded for clean UI
  }
  getAvg(carId: number): void{
    this.reviewService.getAverageRating(carId).subscribe(
      (data) => {
          this.rating = data.averageRating;
          console.log(data)
      }
    )
  }
}
