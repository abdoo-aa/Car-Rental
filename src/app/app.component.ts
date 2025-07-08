import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart, Router } from '@angular/router';
import { LoaderService } from './services/loader.service';
declare var bootstrap: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'frontend';
  isLoading = false;
  showLayout: boolean = true;
  constructor(private router: Router, private loaderService: LoaderService, private cdr: ChangeDetectorRef) {
    // Listen for navigation events
    this.router.events.subscribe(event => {
      if (event instanceof NavigationStart) {
        this.loaderService.show();
      } else if (event instanceof NavigationEnd || event instanceof NavigationCancel || event instanceof NavigationError) {
        this.loaderService.hide();
      }
    });
    
    router.events.subscribe(() => {
      this.showLayout = !router.url.includes('/arhampay'); 
    });

    // Subscribe to loader service
    this.loaderService.isLoading$.subscribe(isLoading => {
      this.isLoading = isLoading;
      this.cdr.detectChanges();
    });
  }
  ngOnInit(): void {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.smoothScrollToTop();
      }
    });
  }


  smoothScrollToTop(): void {
    window.scrollTo({ top: 0, behavior: 'smooth' });
  }
  openModal(type: string, event: Event): void {
    event.preventDefault(); // ✅ Prevent unwanted page navigation

    let modalId = type === 'privacy' ? 'privacyPolicyModal' : 'termsModal';
    let modalElement = document.getElementById(modalId);
    
    if (modalElement) {
      let modalInstance = new bootstrap.Modal(modalElement);
      modalInstance.show();
    }
  }
}
