import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  slides = [
    { image: 'assets/images/Saias.jpg', title: 'Saias' },
    { image: 'assets/images/Calças.jpg', title: 'Calças' },
    { image: 'assets/images/Blazers.jpg', title: 'Blazers' },
    { image: 'assets/images/Sobretudos.jpg', title: 'Sobretudos' },
    { image: 'assets/images/Vestidos.jpg', title: 'Vestidos' },
    { image: 'assets/images/Blusas.jpg', title: 'Blusas' }
  ];

  darkeridinhos = [
    { title: 'Coturnos', image: 'assets/images/Coturnos.jpg' },
    { title: 'Saltos', image: 'assets/images/Saltos.jpg' },
    { title: 'Colares', image: 'assets/images/Colares.jpg' },
    { title: 'Anéis', image: 'assets/images/Aneis.jpg' }
  ];

  currentSlide = 0;

  prevSlide() {
    this.currentSlide = (this.currentSlide - 1 + this.slides.length) % this.slides.length;
  }

  nextSlide() {
    this.currentSlide = (this.currentSlide + 1) % this.slides.length;
  }
}
