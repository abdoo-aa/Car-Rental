import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  user: any = null;
  alldata: any = [];

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.loadUserProfile();
  }

  loadUserProfile(): void {
    this.authService.getUserProfile().subscribe(
      (response) => {
        this.user = response;
        this.authService.getusername(this.user.username).subscribe(
          (data) => this.alldata = data,
        )
      },
      (error) => {
        console.error("❌ Error loading profile:", error);
      }
      
    );
  }
  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }
  
}
