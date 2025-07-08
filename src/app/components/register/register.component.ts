import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
  registerData = {
    username: '',
    password: '',
    email: '',
  };

  successMessage: string = '';
  errorMessage: string = '';

  constructor(private authService: AuthService, private router: Router) {}

  onRegister() {
    this.authService.register(this.registerData).subscribe(
      (response) => {
        this.successMessage = '🎉 Registration successful! Redirecting to login...';
        setTimeout(() => {
          this.router.navigate(['/login']); // Redirect to login page after registration
        }, 2000);
      },
      (error) => {
        this.errorMessage = error.error?.message || '❌ Username already exists or invalid data!';
      }
    );
  }
}
