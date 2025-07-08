import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-manageuser',
  templateUrl: './manageuser.component.html',
  styleUrls: ['./manageuser.component.scss']
})
export class ManageuserComponent {
  users: any[] = [];
  userCount: number = 0;
  currentPage: number = 1; // Current page number
  itemsPerPage: number = 8; // Users per page
  userUnlbockCount: number = 0;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.loadUsers();
    this.loadUserCount();
    this.loadunBlockCount();
  }

  // ✅ Load all users
  loadUsers(): void {
    this.authService.getAllUsers().subscribe(
      (data) => (this.users = data),
      (error) => console.error('❌ Error fetching users:', error)
    );
  }

  // ✅ Load user count
  loadUserCount(): void {
    this.authService.getUserCount().subscribe(
      (data) => (this.userCount = data.count),
      (error) => console.error('❌ Error fetching user count:', error)
    );
  }
  loadunBlockCount(): void {
    this.authService.getUserUnblockCount().subscribe(
      (data) => (this.userUnlbockCount = data.count),
      (error) => console.error('❌ Error fetching user count:', error)
    );
  }
  block(userId: number):void{
    this.authService.blockUnblockUser(userId).subscribe(
      (data) => window.location.reload(),
      (error) => console.log(error)
    )
  }
}
