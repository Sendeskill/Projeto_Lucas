import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  standalone: false,
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css'],
})
export class CadastroComponent {
  cadastroForm: FormGroup;
  sucesso: boolean = false;

  constructor(private fb: FormBuilder) {
    this.cadastroForm = this.fb.group(
      {
        nome: ['', Validators.required],
        email: ['', [Validators.required, Validators.email]],
        senha: ['', [Validators.required, Validators.minLength(4)]],
        confirmarSenha: ['', Validators.required],
      },
      {
        validators: this.senhasIguais,
      }
    );
  }

  senhasIguais(form: FormGroup) {
    const senha = form.get('senha')?.value;
    const confirmar = form.get('confirmarSenha')?.value;
    return senha === confirmar ? null : { senhasDiferentes: true };
  }

  onSubmit() {
    if (this.cadastroForm.valid) {
      this.sucesso = true;
      console.log('Cadastro:', this.cadastroForm.value);
    } else {
      this.sucesso = false;
      this.cadastroForm.markAllAsTouched();
    }
  }

  get nome() {
    return this.cadastroForm.get('nome');
  }
  get email() {
    return this.cadastroForm.get('email');
  }
  get senha() {
    return this.cadastroForm.get('senha');
  }
  get confirmarSenha() {
    return this.cadastroForm.get('confirmarSenha');
  }
}
