import { Component } from '@angular/core';
import { FormBuilder, FormGroup  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-form',
  templateUrl: './car-form.component.html',
  styleUrls: ['./car-form.component.scss']
})
export class CarFormComponent {
  /*carForm!: FormGroup;
  selectedFile!: File;
  previewImage!: string | ArrayBuffer | null;
  isEditMode = false;
  carId: string | any;
  message: string = '';
  messageType: 'success' | 'error' | '' = ''; // To style messages
  constructor(
    private fb: FormBuilder,
    private carService: CarService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.carId = this.route.snapshot.paramMap.get('id');
    this.isEditMode = !!this.carId;

    this.carForm = this.fb.group({
      make: [''],
      model: [''],
      year: [''],
      color: [''],
      rentalPricePerDay: [''],
      isAvailable: [true]
    });

    if (this.isEditMode) {
      this.carService.getCarById(this.carId).subscribe(car => {
        this.carForm.patchValue(car);
        this.previewImage = car.picture;
      });
    }
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];

    const reader = new FileReader();
    reader.readAsDataURL(this.selectedFile);
    reader.onload = () => {
      this.previewImage = reader.result;
    };
  }
  showMessage(msg: string, type: 'success' | 'error') {
    this.message = msg;
    this.messageType = type;
    setTimeout(() => {
      this.message = '';
      this.messageType = '';
    }, 3000); // Message disappears after 3 seconds
  }

  saveCar(): void {
    const formData = new FormData();
    Object.entries(this.carForm.value).forEach(([key, value]) => {
      console.log(`${key}: ${value}`);
      formData.append(key, value as string);
    });

    // Append image file
    if (this.selectedFile) {
      formData.append('imageFile', this.selectedFile);
    } else {
      console.error("No image file selected!");
    }

    // Log FormData entries
    console.log("Final FormData before sending:");
    formData.forEach((value, key) => console.log(`${key}:`, value));
    if (this.isEditMode) {
      this.carService.updateCar(this.carId, formData).subscribe(() => {
        this.showMessage("Car updated successfully!", "success");
        setTimeout(() => this.router.navigate(['/cars']), 2000);
      },
    );
    } else {
      this.carService.addCar(formData).subscribe({
        next: (response) => {
          this.showMessage("Car added successfully!", "success");
          setTimeout(() => this.router.navigate(['/cars']), 2000);
        },
        error: (error) => {
          this.showMessage("Error updating car!", "error");
          console.error("Update Error:", error);
        }
      });
    }
  }*/
    carForm!: FormGroup;
    selectedFile!: File;
    previewImage!: string | ArrayBuffer | null;
    isEditMode = false;
    carId: string | null = null;
    message = '';
    messageType: 'success' | 'error' | '' = '';
  
    constructor(
      private fb: FormBuilder,
      private carService: CarService,
      private route: ActivatedRoute,
      private router: Router
    ) {}
  
    ngOnInit(): void {
      this.carId = this.route.snapshot.paramMap.get('id');
      this.isEditMode = !!this.carId;
  
      this.carForm = this.fb.group({
        make: [''],
        model: [''],
        year: [''],
        color: [''],
        rentalPricePerDay: [''],
        isAvailable: [true],
       
          category: [''],
          mileage: [''],
          transmission: [''],
          fuelType: [''],
          seatingCapacity: [''],
          discountPercentage: ['']
      });
  
      if (this.isEditMode) {
        this.carService.getCarByIdstring(this.carId!).subscribe(car => {
          this.carForm.patchValue({
            make: car.make,
            model: car.model,
            year: car.year,
            color: car.color,
            rentalPricePerDay: car.rentalPricePerDay,
            category: car.carDetails.category,
            mileage: car.carDetails.mileage,
            transmission: car.carDetails.transmission,
            fuelType: car.carDetails.fuelType,
            seatingCapacity: car.carDetails.seatingCapacity,
            discountPercentage: car.carDetails.discountPercentage
          });
          this.previewImage = car.picture;
        });
      }
    }
  
    onFileSelected(event: any): void {
      this.selectedFile = event.target.files[0];
      const reader = new FileReader();
      reader.onload = () => (this.previewImage = reader.result);
      reader.readAsDataURL(this.selectedFile);
    }
  
    showMessage(msg: string, type: 'success' | 'error'): void {
      this.message = msg;
      this.messageType = type;
      setTimeout(() => {
        this.message = '';
        this.messageType = '';
      }, 3000);
    }
  
    saveCar(): void {
      const formData = new FormData();
      const carData = this.carForm.value;
  
      // Main car properties
      formData.append('make', carData.make);
      formData.append('model', carData.model);
      formData.append('year', carData.year);
      formData.append('color', carData.color);
      formData.append('rentalPricePerDay', carData.rentalPricePerDay);
      formData.append('isAvailable', carData.isAvailable);
  
         // Car details properties (No dot notation)
    formData.append('Category', carData.category);
    formData.append('Mileage', carData.mileage);
    formData.append('Transmission', carData.transmission);
    formData.append('FuelType', carData.fuelType);
    formData.append('SeatingCapacity', carData.seatingCapacity);
    formData.append('DiscountPercentage', carData.discountPercentage);
  
      // Image file
      if (this.selectedFile) formData.append('imageFile', this.selectedFile);
  
      if (this.isEditMode) {
        this.carService.updateCar(Number(this.carId), formData).subscribe({
          next: () => {
            this.showMessage('Car updated successfully!', 'success');
            setTimeout(() => this.router.navigate(['/cars']), 2000);
          },
          error: (err) => {
            this.showMessage('Error updating car!', 'error');
            console.error(err);
          }
        });
      } else {
        this.carService.addCar(formData).subscribe({
          next: () => {
            this.showMessage('Car added successfully!', 'success');
            setTimeout(() => this.router.navigate(['/cars']), 2000);
          },
          error: (err) => {
            this.showMessage('Error adding car!', 'error');
            console.error(err);
          }
        });
      }
    }
}
