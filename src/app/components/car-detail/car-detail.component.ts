import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { CarService } from 'src/app/services/car.service';
declare var bootstrap: any;

@Component({
  selector: 'app-car-detail',
  templateUrl: './car-detail.component.html',
  styleUrls: ['./car-detail.component.scss']
})
export class CarDetailComponent implements OnInit {
  car: any;
  startDate: string = '';
  endDate: string = '';
  totalPrice: number = 0;
  isAuthenticated = false;
  discountedPrice: number = 0;
  constructor(
    private authService: AuthService,
    private route: ActivatedRoute,
    private carService: CarService,
    private router: Router
  ) {}

  ngOnInit(): void {
    
    this.startAutoSlide();
    this.authService.authStatus$.subscribe(status => {
      this.isAuthenticated = status;
    });
    const carId = this.route.snapshot.paramMap.get('id');
    if (carId) {
      this.carService.getCarById(Number(carId)).subscribe(
        (data) => {
          this.car = data;
          this.calculateDiscountedPrice();
          // Ensure there's at least 2 images
        if (!this.car.pictures || this.car.pictures.length < 2) {
          this.car.pictures = [
            this.car.picture, // Main Image
            this.car.picture,
          ];
        }
        },
        (error) => {
          console.error('Error fetching car details:', error);
        }
      );
    }
    
  }
  calculateDiscountedPrice(): void {
    if (this.car && this.car.rentalPricePerDay && this.car.carDetails.discountPercentage > 0) {
      const discount = (this.car.rentalPricePerDay * this.car.carDetails.discountPercentage) / 100;
      this.discountedPrice = this.car.rentalPricePerDay - discount;
    }
  }
  calculateTotalPrice(): void {
    if (this.startDate && this.endDate && this.discountedPrice > 0) {
      const start = new Date(this.startDate);
      const end = new Date(this.endDate);
      const days = Math.ceil((end.getTime() - start.getTime()) / (1000 * 3600 * 24));
      this.totalPrice = days > 0 ? days * this.discountedPrice : 0;
    } else {
      const start = new Date(this.startDate);
      const end = new Date(this.endDate);
      const days = Math.ceil((end.getTime() - start.getTime()) / (1000 * 60 * 60 * 24));
      this.totalPrice = days > 0 ? days * this.car.rentalPricePerDay : 0;
    }
  }
  
  
  startAutoSlide(): void {
    const carouselElement = document.getElementById('carImageCarousel');
    if (carouselElement) {
      const carousel = new bootstrap.Carousel(carouselElement, {
        interval: 5000, 
        wrap: true
      });
      carousel.cycle(); // Start auto-sliding
    }
  }

  // Redirect to dummy payment page
  bookNow(): void {
   
       const bookingDetails = {
        carId: this.car.id,
        amount: this.totalPrice,
        startDate: new Date(this.startDate),
        endDate: new Date(this.endDate)
      };
      localStorage.setItem('pendingBooking', JSON.stringify(bookingDetails));
      
      //console.log(localStorage.getItem('pendingbooks'));
      // Navigate using state (instead of query params)
      this.router.navigate(['/arhampay']);
  }
}
