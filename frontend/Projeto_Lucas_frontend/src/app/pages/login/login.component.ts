import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: false,
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: FormGroup;
  mensagem: string = '';

  constructor(private fb: FormBuilder, private http: HttpClient) {
    this.loginForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
      senha: ['', Validators.required],
    });
  }

  get email() {
    return this.loginForm.get('email');
  }

  get senha() {
    return this.loginForm.get('senha');
  }

  onSubmit() {
    if (this.loginForm.valid) {
      this.http
        .post<any>(
          'http://localhost:5055/api/Usuario/login',
          this.loginForm.value
        )
        .subscribe({
          next: (res) => {
            alert(res.mensagem); // Exibe "O login deu certo!"
          },
          error: () => {
            alert('Email ou senha inválidos!');
          },
        });
    } else {
      this.loginForm.markAllAsTouched();
    }
  }
}
