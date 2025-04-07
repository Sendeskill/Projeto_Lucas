import { ApplicationConfig } from '@angular/core';
import { provideRouter, RouterModule, RouterOutlet } from '@angular/router';
import { routes } from './app.routes';
import { provideHttpClient } from '@angular/common/http';
import { Component } from '@angular/core';


export const appConfig: ApplicationConfig = {
  providers: [
    provideHttpClient(),
    provideRouter(routes),
  ]
};

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: true,
  imports: [
    RouterModule,
    RouterOutlet
    ]
})
export class AppComponent {
  title = 'Projeto_Lucas_frontend';
}