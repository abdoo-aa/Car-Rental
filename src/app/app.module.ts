import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ProfileComponent } from './components/profile/profile.component';
import { CarListComponent } from './components/car-list/car-list.component';
import { CarCardComponent } from './components/car-card/car-card.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { CarDetailComponent } from './components/car-detail/car-detail.component';
import { ArhampayComponent } from './components/arhampay/arhampay.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ManageuserComponent } from './components/manageuser/manageuser.component';
import { HomeComponent } from './components/home/home.component';
import { ManagecarComponent } from './components/managecar/managecar.component';
import { CarFormComponent } from './components/car-form/car-form.component';
import { CarReviewsComponent } from './components/car-reviews/car-reviews.component';
import { ChatbotComponent } from './components/chatbot/chatbot.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    SidebarComponent,
    ProfileComponent,
    CarListComponent,
    CarCardComponent,
    CarDetailComponent,
    ArhampayComponent,
    DashboardComponent,
    ManageuserComponent,
    HomeComponent,
    ManagecarComponent,
    CarFormComponent,
    CarReviewsComponent,
    ChatbotComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgxPaginationModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
