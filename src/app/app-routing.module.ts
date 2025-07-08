import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { ProfileComponent } from './components/profile/profile.component';
import { AuthGuard } from './services/auth.guard';
import { NoAuthGuard } from './guards/no-auth.guard';
import { AdminGuard} from './services/admin.guard';
import { CarListComponent } from './components/car-list/car-list.component';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { ArhampayComponent } from './components/arhampay/arhampay.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ManageuserComponent } from './components/manageuser/manageuser.component';
import { HomeComponent } from './components/home/home.component';
import { ManagecarComponent } from './components/managecar/managecar.component';
import { CarFormComponent } from './components/car-form/car-form.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' }, // Default route
  { path: 'home', component: HomeComponent },
  { path: 'cars', component: CarListComponent },
  { path: 'car/:id', component: CarDetailComponent },
  { path: 'dashboard', component: DashboardComponent,canActivate: [AuthGuard] },
  { path: 'arhampay', component: ArhampayComponent,canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent, canActivate: [NoAuthGuard] },
  { path: 'register', component: RegisterComponent, canActivate: [NoAuthGuard] },
  { path: 'profile', component: ProfileComponent, canActivate: [AuthGuard] },  // Protect the profile route
  { path: 'manageuser', component: ManageuserComponent, canActivate: [AdminGuard] },
  { path: 'managecar', component: ManagecarComponent, canActivate: [AdminGuard] },
  { path: 'car-form', component: CarFormComponent, canActivate: [AdminGuard] },
  { path: 'car-form/:id', component: CarFormComponent, canActivate: [AdminGuard] },
  { path: '**', redirectTo: '/login' }, // Optional: Redirect to login for any unknown routes
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
