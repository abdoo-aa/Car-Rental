import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent {
  isSidebarOpen = false;
  isAuthenticated = false;
  isAdmin = false;

  constructor(private authService: AuthService, private router: Router) {}

  ngOnInit() {
    // Listen for login/logout updates
    this.authService.authStatus$.subscribe(status => {
      this.isAuthenticated = status;
      this.updateUserRole();
    });

    this.updateUserRole();
  }

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  logout() {
    this.authService.logout();
    this.router.navigate(['/login']);
  }

  private updateUserRole() {
    const token = this.authService.getToken();
    if (token) {
      const decodedToken = this.decodeToken(token);
      this.isAdmin = decodedToken?.role === 'Admin';
    } else {
      this.isAdmin = false;
    }
  }

  private decodeToken(token: string): any {
    try {
      return JSON.parse(atob(token.split('.')[1]));
    } catch (e) {
      return null;
    }
  }
}
