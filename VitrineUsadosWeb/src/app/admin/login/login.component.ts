import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
    private usuarioService: UsuarioService
  ) {}

  login() {
    if(!this.loginForm.valid)
      return;

    this.usuarioService.login(this.loginForm.value.email, this.loginForm.value.senha);
  }

}
