import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { LoaderService } from 'src/app/services/loader.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginData = {
    username: '',
    password: '',
  };

  errorMessage: string = '';
  successMessage: string = '';
  showForgotPassword: boolean = false;
  resetUsername: string = '';
  isLoading = false;

  constructor(private authService: AuthService, private router: Router,private loaderService: LoaderService) {}

  onLogin() {
    this.loginData.username = this.loginData.username.trim();
    this.loginData.password = this.loginData.password.trim();

    if (!this.loginData.username || !this.loginData.password) {
      this.errorMessage = 'Username and password are required!';
      return;
    }

    this.authService.login(this.loginData).subscribe(
      (response) => {
        this.authService.saveToken(response.token); // Store JWT token
    
        this.successMessage = 'Login successful! Redirecting...';
        this.errorMessage = '';
    
        setTimeout(() => {
          this.router.navigate(['/cars']).then(() => {
            setTimeout(() => {
              this.loaderService.hide(); // Hide loader after transition
            }, 500); // Small delay for a smoother transition
          });
        }, 2000); // 2-second delay before navigating to the profile
      },
      (error) => {
        this.errorMessage = error.error.message || 'Invalid login credentials!';
        this.successMessage = '';
        this.router.navigate(['/login']).then(() => {
          this.loaderService.hide(); // Hide after navigation
        });
      }
    );
    
  }

  toggleForgotPassword() {
    this.showForgotPassword = !this.showForgotPassword;
    this.errorMessage = '';
    this.successMessage = '';
  }

  
}
