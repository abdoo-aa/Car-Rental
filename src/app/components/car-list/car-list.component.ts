import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-list',
  templateUrl: './car-list.component.html',
  styleUrls: ['./car-list.component.scss']
})
export class CarListComponent implements OnInit {
  cars: any[] = [];
  filteredCars: any[] = [];
  searchQuery: string = '';
  selectedYear: string = '';
  selectedAvailability: string = '';
  selectedCategory: string = '';
  selectedBrand: string = '';
  selectedType: string = ''; // New property for Car/Bike filter
  selectedSort: string = ''; // Sorting option
  minPrice: number | null = null;  // Added
  maxPrice: number | null = null;  // Added
  uniqueYears: number[] = [];
  showFilters: boolean = false; // Toggle filter visibility
    // Pagination properties
    currentPage: number = 1;
    itemsPerPage: number = 9; // Maximum 9 cars per page

  constructor(private carService: CarService) {}

  ngOnInit(): void {
    this.carService.getCars().subscribe(
      (data) => {
        this.cars = data;
        this.filteredCars = data;
        
        // Get unique years for filter dropdown
        this.uniqueYears = [...new Set(this.cars.map(car => car.year))].sort((a, b) => b - a);
      },
      (error) => {
        console.error('Error fetching cars:', error);
      }
    );
    window.scrollTo(0, 0);
  }

  applyFilters(): void {
    this.filteredCars = this.cars.filter(car => {
      const matchesSearch = car.make.toLowerCase().includes(this.searchQuery.toLowerCase()) || 
                            car.model.toLowerCase().includes(this.searchQuery.toLowerCase()) ||
                            car.carDetails.category.toLowerCase().includes(this.searchQuery.toLowerCase());
  
      const matchesPrice = 
        (!this.minPrice || car.rentalPricePerDay >= this.minPrice) &&
        (!this.maxPrice || car.rentalPricePerDay <= this.maxPrice);
  
      const matchesAvailability = this.selectedAvailability ? 
          (this.selectedAvailability === 'true' ? car.isAvailable : !car.isAvailable) : true;
      const matchesCategory = this.selectedCategory ? 
          car.carDetails.category === this.selectedCategory : true;
      const matchesBrand = this.selectedBrand ? 
          car.make === this.selectedBrand : true;
          const matchesType = this.selectedType ? 
          (this.selectedType === 'Bike' ? car.carDetails.category.toLowerCase().includes('bike') 
                                        : !car.carDetails.category.toLowerCase().includes('bike')) 
          : true;
    return matchesSearch && matchesPrice && matchesAvailability && matchesCategory && matchesBrand && matchesType;
    });
    // Sorting
    if (this.selectedSort === 'lowToHigh') {
      this.filteredCars.sort((a, b) => a.rentalPricePerDay - b.rentalPricePerDay);
    } else if (this.selectedSort === 'highToLowDiscount') {
      this.filteredCars.sort((a, b) => b.rentalPricePerDay - a.rentalPricePerDay);
    }

  
    // Reset pagination to the first page after filtering
    this.currentPage = 1;
  }
  toggleFilters(): void {
    this.showFilters = !this.showFilters;
  }
  
}
