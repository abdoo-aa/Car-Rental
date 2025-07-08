import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/services/car.service';
declare var bootstrap: any;

@Component({
  selector: 'app-managecar',
  templateUrl: './managecar.component.html',
  styleUrls: ['./managecar.component.scss']
})
export class ManagecarComponent implements OnInit {
  cars: any[] = [];
  currentPage: number = 1; // Current page number
  itemsPerPage: number = 7; // Users per page
  selectedCarId: number | null = null; // Store the car ID to delete
  deleteModal: any; // Bootstrap modal instance
  displayCount: number = 0;
  displayCountAval: number = 0;

  constructor(private carService: CarService) {}

  ngOnInit(): void {
    this.loadCars();

    const modalElement = document.getElementById('deleteModal');
    if (modalElement) {
      this.deleteModal = new bootstrap.Modal(modalElement);
    }
    this.carService.getCarCount().subscribe(
      (data) =>{
        this.displayCount = data.count
        
      },
      (error)=> console.log(this.displayCount,error)
    )

    this.carService.getCarAvalCount().subscribe(
      (data) =>{
        this.displayCountAval = data.count
        
      },
      (error)=> console.log(this.displayCount,error)
    )
  }

  loadCars(): void {
    this.carService.getCars().subscribe(
      (data) => this.cars = data,
      (error) => console.error('Error fetching cars:', error)
    );
  }
  openDeleteModal(id: number): void {
    this.selectedCarId = id; // Store car ID
    this.deleteModal.show(); // Show the modal
  }

  deleteCar(id: number): void {
    if (confirm('Are you sure you want to delete this car?')) {
      this.carService.deleteCar(id).subscribe(() => {
        this.cars = this.cars.filter(car => car.id !== id);
      });
    }
  }
  confirmDelete(): void {
    if (this.selectedCarId !== null) {
      this.carService.deleteCar(this.selectedCarId).subscribe(() => {
        this.cars = this.cars.filter((car) => car.id !== this.selectedCarId);
        this.selectedCarId = null; // Reset after deletion
      });
    }
  }
}
