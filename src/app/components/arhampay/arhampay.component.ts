import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { BookingService } from 'src/app/services/booking.service';
import { CarService } from 'src/app/services/car.service';
import { LoaderService } from 'src/app/services/loader.service';

@Component({
  selector: 'app-arhampay',
  templateUrl: './arhampay.component.html',
  styleUrls: ['./arhampay.component.scss']
})
export class ArhampayComponent implements OnInit {
  amount: number = 0;
  isLoading$ = this.loaderService.isLoading$;
  paymentSuccess: boolean = false;
  count: number = 5;
  carId: string = '';
  startDate: number = 0;
  endDate: number = 0;

  constructor(private route: ActivatedRoute, private loaderService: LoaderService, private router: Router,private bookingService: BookingService,private carService: CarService,private authService: AuthService) {}

  ngOnInit(): void {
    /*this.route.queryParams.subscribe(params => {
      this.amount = params['amount'] || 0;
      this.carId = params['carId'];
    });*/
    // Get navigation state
    const storedBooking = localStorage.getItem('pendingBooking');
  if (!storedBooking) {
    this.router.navigate(['/cars']); // Redirect if no booking data
    return;
  }

  const booking = JSON.parse(storedBooking);
  this.amount = booking.amount;
  this.carId = booking.carId;
  this.startDate = booking.startDate;
  this.endDate = booking.endDate;
  // Clear storage after retrieving to prevent reuse
  localStorage.removeItem('pendingBooking');
  }

  processPayment(): void {
    this.loaderService.show();
  
    this.authService.getUserId().subscribe(userData => {
      const userId = userData.userId; //  Get UserId from backend
      
      setTimeout(() => {
        this.loaderService.hide();
        this.paymentSuccess = true;
  
        if (this.carId && userId) {
          this.bookingService.confirmBooking(userId, Number(this.carId), this.amount, this.startDate, this.endDate).subscribe(
            response => console.log("✅ Booking stored successfully:", response),
            error => console.error("❌ Booking Error:", error)
          );
        } else {
          console.error("❌ Car ID or User ID is missing");
        }
  
        // Redirect countdown
        const countdownInterval = setInterval(() => {
          this.count--;
          if (this.count === 0) {
            clearInterval(countdownInterval);
            this.router.navigate(['/dashboard']);
          }
        }, 1000);
      }, 3000);
    }, error => {
      this.loaderService.hide();
      console.error("❌ Error fetching UserId:", error);
    });
  }
  
  
}
