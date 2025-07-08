import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ChatbotService } from 'src/app/services/chatbot.service';

@Component({
  selector: 'app-chatbot',
  templateUrl: './chatbot.component.html',
  styleUrls: ['./chatbot.component.scss']
})
export class ChatbotComponent implements OnInit {
  isOpen = false;
  messages: { sender: string, text: string }[] = [];
  userInput: string = '';

  @ViewChild('chatBody') chatBody!: ElementRef;

  constructor(private chatbotService: ChatbotService) {}

  ngOnInit(): void {
    this.addBotMessage("Hello! I'm ArkaBot 🤖 How can I assist you?");
  }

  toggleChat() {
    this.isOpen = !this.isOpen;
    if (this.isOpen) this.scrollToBottom();
  }

  sendMessage() {
    if (this.userInput.trim() !== '') {
      this.addUserMessage(this.userInput);
      this.chatbotService.getBotResponse(this.userInput).subscribe((response) => {
        this.addBotMessage(response);
      });
      this.userInput = '';
    }
  }

  addUserMessage(text: string) {
    this.messages.push({ sender: 'user', text });
    this.scrollToBottom();
  }

  addBotMessage(text: string) {
    this.messages.push({ sender: 'bot', text });
    this.scrollToBottom();
  }

  scrollToBottom() {
    setTimeout(() => {
      if (this.chatBody) {
        this.chatBody.nativeElement.scrollTop = this.chatBody.nativeElement.scrollHeight;
      }
    }, 10);
  }
}
