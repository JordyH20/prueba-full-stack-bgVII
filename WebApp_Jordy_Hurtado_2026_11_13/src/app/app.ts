import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EventosRegister } from './components/eventos/eventos-register/eventos-register';

@Component({
  imports: [EventosRegister],
  selector: 'app-root',
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App {
  protected readonly title = signal('WebApp_Jordy_Hurtado_2026_11_13');
}
