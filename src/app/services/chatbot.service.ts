import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ChatbotService {

  constructor() { }

  getBotResponse(userInput: string): Observable<string> {
    userInput = userInput.toLowerCase();

    if (userInput.includes('book')) {
      return of("To book a car, click 'Book Now' on the car card and select your rental dates. 🗓️");
    } else if (userInput.includes('cancel')) {
      return of("To cancel a booking, visit 'Dashbord' and select the 'Cancel' button. ❌");
    } else if (userInput.includes('help')) {
      return of("I can help you with booking cars, checking rentals, and account info. What do you need?");
    }else if (userInput.includes('hello') || userInput.includes('hi')) {
      return of("Hello, How can I help you");}
     else {
      return of("I'm not sure about that. Try asking about booking, rentals, or account information. 😊");
    }
  }
}
