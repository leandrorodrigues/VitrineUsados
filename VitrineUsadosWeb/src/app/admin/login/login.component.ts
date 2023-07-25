import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from 'src/app/services/usuario.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {

  
  loginForm: FormGroup = new FormGroup({
    email: new FormControl(null, [Validators.required, Validators.email]),
    senha: new FormControl(null, [Validators.required]),
  });

  constructor(
    private usuarioService: UsuarioService,
    private router: Router
  ) {}

  login() {
    if(!this.loginForm.valid)
      return;

    this.usuarioService.login(this.loginForm.value.email, this.loginForm.value.senha).subscribe({
      next: () => this.router.navigateByUrl("/admin"),
      error: () => {
        alert("E-mail ou senha inválidos.")
      }
    });
  }

}
