import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { BookingService } from 'src/app/services/booking.service';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss']
})
export class DashboardComponent implements OnInit {
  bookings: any[] = [];
  filteredBookings: any[] = [];
  isAdmin: boolean = false;
  isAuthenticated: boolean = false;
  username1: string = '';
  displayname: string = '';
  userId: number = 0;
  userReview: [] | any;
  // Dashboard Metrics
  totalBookings: number = 0;
  activeRentals: number = 0;
  totalPending: number = 0;
  cancelledbooking: number = 0;
  totalEarnings: number = 0;
  totalUserBooking: number = 0;
  bookuserId: number = 0;
  idx:number = 0;

  currentPage: number = 1; // Current page number
  itemsPerPage: number = 6; // Users per page

  // Filters
  filterStatus: string = '';
  
  // Manual Messages
  message: string = '';
  messageType: 'success' | 'error' | 'warning' | 'info' = 'success';

  // Review Form
  showReviewForm: boolean = false;
  editingReview: boolean = false;
  rating: number = 0;
  review: string = '';
  selectedBookingId: number | null = null;

  constructor(
    private authService: AuthService,
    private bookingService: BookingService,
    private reviewService: ReviewService
  ) {}

  ngOnInit(): void {
    
    this.isAuthenticated = this.authService.isAuthenticated();
    const user = this.authService.decodeToken();
    if(user)
    {
      this.username1 = user.username;
    }
    // Check if user exists and role is 'Admin'
    if (user && user.role === 'Admin') {
      this.isAdmin = true;
      this.loadBookings();
      this.loadDashboardData();
      
    }
    if(user && user.role === 'User')
    {
      this.loadBookingsbyUser();
      this.loadDashboardDataUser();
    }
    this.authService.getUserProfile().subscribe(
      (response) => {
        
        this.authService.getUserByUsername(response.username).subscribe(
          (data) => {this.userId = data.userId;
            
            if (!this.isAdmin) {
              this.reviewService.getUserReviews(this.userId).subscribe((reviews) => {
                this.userReview = reviews;
                this.bookings.forEach((booking) => {
                  const matchingReview = this.userReview.find((rating: { carId: any; }) => rating.carId === booking.carId);
                  if (matchingReview) {
                    booking.review = matchingReview;
                  }
                });
              });
            }
          }
        )
      },
      (error) => {
        console.error("❌ Error loading profile:", error);
      }
      
    );
    
      
  }

  /** Fetch Bookings from API */
  loadBookings(): void {
    if (this.isAdmin) {
      this.bookingService.getAllBookings().subscribe(
        (data) => {
          this.bookings = data;
          this.bookings = this.bookings.sort((a,b)=> b.id-a.id)
          this.updateDashboardMetrics();
          this.applyFilters();
          this.bookings.forEach(booking => {
            this.authService.getUserByUserId(booking.userId).subscribe(
              (userData) => {
                booking.displayname = userData.username;
              },
              (error) => {
                console.error("Error fetching user data:", error);
              }
            );
          });
          
        },
        (error) => this.showMessage('Error fetching bookings.', 'error')
        
      );
      this.bookingService.getPendingBookingsCount().subscribe(
        (data) =>{
          this.totalPending = data;
          console.log(data)
        },
        (error) => this.showMessage('Error fetching all pending','error')
      )
      
    }
  }
  loadBookingsbyUser(): void {
    {
      this.bookingService.getUserBookings().subscribe(
        (data) => {
          this.bookings = data;
          this.bookings = this.bookings.sort((a,b)=> b.id-a.id)
          this.applyFilters();
        },
        (error) => this.showMessage('Error fetching user bookings.', 'error')
      );
    }
  }

  /** Apply Filters */
  applyFilters(): void {
    this.filteredBookings = this.bookings.filter(booking => 
      this.filterStatus ? booking.status === this.filterStatus : true
    );
  }

  /** Show Manual Message */
  showMessage(msg: string, type: 'success' | 'error' | 'warning'): void {
    this.message = msg;
    this.messageType = type;
    setTimeout(() => this.message = '', 3000); // Clear message after 3 seconds
  }
  loadDashboardData(): void {
    // Fetch Total Bookings Count
    this.bookingService.getTotalBookings().subscribe(
      (count: number) => {
        this.totalBookings = count;
      },
      (error) => {
        console.error('Error fetching total bookings:', error);
      }
    );
  }
  loadDashboardDataUser(): void {
    if (this.username1) {
      this.bookingService.getUserCountBookings(this.username1).subscribe(
        (count: number) => {
          this.totalUserBooking = count;
          
        },
        (error) => {
          console.error('Error fetching user booking count:', error);
        }
      );

      this.bookingService.getUserCancelledBookings(this.username1).subscribe(
        (count: number) => {
          this.cancelledbooking = count; //  Store canceled booking count
          
        },
        (error) => {
          console.error('Error fetching canceled bookings count:', error);
        }
      );
    }
  }

  /** Approve Booking (Admin Only) */
  approveBooking(bookingId: number): void {
    this.bookingService.approveBooking(bookingId).subscribe(
      () => {
        this.showMessage('✅ Booking Approved!', 'success');
        this.loadBookings();
      },
      () => this.showMessage('❌ Error approving booking!', 'error')
    );
  }

  /** Reject Booking (Admin Only) */
  rejectBooking(bookingId: number): void {
    this.bookingService.rejectBooking(bookingId).subscribe(
      () => {
        this.showMessage('⚠️ Booking Rejected & Amount Refunded!', 'warning');
        this.loadBookings();
      },
      () => this.showMessage('❌ Error rejecting booking!', 'error')
    );
  }

  /** Cancel Booking (User Only) */
  cancelBooking(bookingId: number): void {
    this.bookingService.cancelBooking(bookingId).subscribe(
      () => {
        this.showMessage('🚫 Booking Canceled & Amount Refunded!', 'error');
        this.isAdmin ? this.loadBookings() : this.loadBookingsbyUser();
      },
      () => this.showMessage('❌ Error canceling booking!', 'error')
    );
  }

  /** Update Dashboard Metrics */
  updateDashboardMetrics(): void {
    this.totalBookings = this.bookings.length;
    this.activeRentals = this.bookings.filter(b => b.status === 'Approved').length;
    this.totalEarnings = this.bookings
      .filter(b => b.status === 'Approved' || b.status === 'Completed')
      .reduce((sum, booking) => sum + booking.price, 0);
  }
  returnCar(bookingId: number): void {
    this.bookingService.returnCar(bookingId).subscribe(
      () => {
        this.showMessage('✅ Returned Successfully!', 'success');
        this.loadBookingsbyUser(); // Reload the bookings list after the update
        
      },
      error => {
        console.error('Error returning car:', error);
        () => this.showMessage('❌ Error rejecting booking!', 'error')
      }
    );
  }

  /** ✅ Review Actions */
  selectBookingForReview(bookingId: number): void {
    this.selectedBookingId = bookingId;
    this.rating = 0;
    this.review = '';
    this.editingReview = false;
    this.showReviewForm = true;
  }

  editReview(bookingId: number): void {
    const booking = this.bookings.find((b) => b.id === bookingId);
    if (booking?.review) {
      this.selectedBookingId = bookingId;
      this.rating = booking.review.rating;
      this.review = booking.review.review;
      this.editingReview = true;
      this.showReviewForm = true;
    }
  }

  deleteReview(reviewId: number): void {
    this.reviewService.deleteReview(reviewId, {}).subscribe(() => {
      this.showMessage('Review deleted successfully!', 'success');
      this.loadBookings();
    });
  }

  submitReview(): void {
    if (this.selectedBookingId && this.rating > 0) {
      const booking = this.bookings.find((b) => b.id === this.selectedBookingId);
      if (!booking) return;
      const reviewData = {
        id: this.selectedBookingId,
        rating: this.rating,
        review: this.review
      };
      if (this.editingReview) {
        this.reviewService.editReview(this.selectedBookingId, reviewData).subscribe(() => {
          setTimeout(() => (this.showMessage('Review updated successfully!', 'success'), 3000))
          
          this.loadBookings();
          this.closeReviewForm();
        });
      } else {
        this.reviewService.submitReview(reviewData).subscribe(() => {
          setTimeout(() => (this.showMessage('Thanks for Rating!', 'success'), 3000))
          this.loadBookings();
          this.closeReviewForm();
        });
      }
    } else {
      this.showMessage('Please provide a rating and review text.', 'warning');
    }
  }

  closeReviewForm(): void {
    this.showReviewForm = false;
    this.selectedBookingId = null;
    this.rating = 0;
    this.review = '';
  }

  /** ✅ Helpers */
  canReview(status: string): boolean {
    return status === 'Completed';
  }

  calculateAverageRating(reviews: any[]): number {
    if (!reviews || reviews.length === 0) return 0;
    const total = reviews.reduce((sum, review) => sum + review.rating, 0);
    return Math.round(total / reviews.length);
  }
  

  getStatusClass(status: string): string {
    switch (status) {
      case 'Pending':
        return 'badge bg-warning text-dark'; // Yellow color
      case 'Approved':
        return 'badge bg-success'; // Green color
      case 'Rejected':
        return 'badge bg-danger'; // Red color
      case 'Completed':
        return 'badge bg-primary'; // Blue color
      default:
        return 'badge bg-secondary'; // Gray color
    }
  }
}
