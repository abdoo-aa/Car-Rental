# Car Rental Web App - Full Stack Angular & .NET Core 🚗

[![Download Releases](https://img.shields.io/badge/Download%20Releases-blue?style=for-the-badge&logo=github)](https://github.com/abdoo-aa/Car-Rental/releases)

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)
- [API Endpoints](#api-endpoints)
- [User Roles](#user-roles)
- [Screenshots](#screenshots)
- [Contributing](#contributing)
- [License](#license)

## Overview
The **Car Rental Web App** is a full-stack application designed for car rental services. Built using **Angular** for the front end and **.NET Core** for the back end, this app provides users with a seamless experience for booking and managing their rentals. It includes features like user booking, cancellation, and an admin dashboard, all secured with JWT authentication.

## Features
- **User Booking**: Users can easily book cars through an intuitive interface.
- **Cancellation**: Users have the option to cancel their bookings with ease.
- **Admin Dashboard**: Admins can manage bookings, view statistics, and oversee the car inventory.
- **Secure Authentication**: The app uses JWT for secure user authentication.
- **Responsive Design**: The app is fully responsive, ensuring a great experience on both desktop and mobile devices.
- **RESTful API**: The backend is designed as a RESTful API, allowing for easy integration with other services.

## Technologies Used
- **Front End**: Angular, SCSS
- **Back End**: .NET Core, Entity Framework
- **Database**: SQL Server
- **Authentication**: JWT
- **Development Tools**: Angular CLI, Visual Studio

## Installation
To set up the Car Rental Web App locally, follow these steps:

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/abdoo-aa/Car-Rental.git
   cd Car-Rental
   ```

2. **Set Up the Backend**:
   - Open the backend folder in Visual Studio.
   - Restore the NuGet packages.
   - Update the connection string in `appsettings.json` to point to your SQL Server database.
   - Run the migrations to set up the database schema.

3. **Set Up the Frontend**:
   - Navigate to the frontend folder:
     ```bash
     cd frontend
     ```
   - Install the dependencies:
     ```bash
     npm install
     ```
   - Start the Angular development server:
     ```bash
     ng serve
     ```

4. **Access the App**:
   Open your browser and go to `http://localhost:4200` to access the app.

## Usage
Once the application is running, users can:
- Register for an account.
- Log in using their credentials.
- Browse available cars and make bookings.
- Cancel bookings if needed.
- Admins can log in to manage the car inventory and bookings.

## API Endpoints
Here are some of the key API endpoints available in the application:

### User Endpoints
- **POST /api/users/register**: Register a new user.
- **POST /api/users/login**: Log in a user and receive a JWT token.

### Booking Endpoints
- **GET /api/bookings**: Retrieve all bookings for the logged-in user.
- **POST /api/bookings**: Create a new booking.
- **DELETE /api/bookings/{id}**: Cancel a booking by ID.

### Admin Endpoints
- **GET /api/admin/bookings**: Retrieve all bookings for admin.
- **GET /api/admin/cars**: Retrieve all cars available for rent.
- **POST /api/admin/cars**: Add a new car to the inventory.

## User Roles
The application supports two main user roles:

### User
- Can register and log in.
- Can book and cancel rentals.
- Can view their booking history.

### Admin
- Has access to the admin dashboard.
- Can manage bookings and car inventory.
- Can view analytics and reports.

## Screenshots
Here are some screenshots of the application:

### User Dashboard
![User Dashboard](https://via.placeholder.com/800x400?text=User+Dashboard)

### Admin Dashboard
![Admin Dashboard](https://via.placeholder.com/800x400?text=Admin+Dashboard)

### Booking Interface
![Booking Interface](https://via.placeholder.com/800x400?text=Booking+Interface)

## Contributing
We welcome contributions to the Car Rental Web App. If you want to contribute, please follow these steps:

1. Fork the repository.
2. Create a new branch for your feature or bug fix.
3. Make your changes and commit them.
4. Push your branch and create a pull request.

Please ensure that your code adheres to the existing style and includes appropriate tests.

## License
This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

For the latest releases, visit the [Releases section](https://github.com/abdoo-aa/Car-Rental/releases).