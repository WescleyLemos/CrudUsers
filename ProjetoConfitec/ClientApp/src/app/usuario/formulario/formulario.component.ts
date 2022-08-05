import { Component, OnInit } from '@angular/core';
import { FormControl, NgForm, ValidationErrors } from '@angular/forms';
import { Usuarios } from '../../shared/models/usuarios';
import { UsuariosService } from '../../shared/services/usuarios.service';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import Swal from "sweetalert2";
import { Router } from '@angular/router';

@Component({
  selector: 'app-formulario',
  templateUrl: './formulario.component.html',
  styleUrls: ['./formulario.component.css']
})
export class FormularioComponent implements OnInit {
  grupoValidacoes: FormGroup;
  usuario: Usuarios;
  hasValue = false;

  constructor(public service: UsuariosService, private formBuilder: FormBuilder, private router: Router) {
    if (this.router.getCurrentNavigation().extras.state != null) {
      this.service.formData = this.router.getCurrentNavigation().extras.state.carta as Usuarios;
      console.log(this.service.formData)
      this.hasValue = true;
    }

    this.grupoValidacoes = this.formBuilder.group({
      dataNascimento: [Validators.required,],
      nome: [Validators.required],
      sobrenome: [Validators.required],
      escolaridade: [Validators.required],
      email: [Validators.required, Validators.email]
    });
  }

  ngOnInit() { }

  submeterFormulario(form: NgForm) {
    if (!this.grupoValidacoes.valid) {
      Swal.fire({ icon: "error", title: "Preencha todo o formulário corretamente!" });
      return;
    }
    this.service.postUsuario().subscribe(
      (res) => {
        Swal.fire("Cadastro Realizado com sucesso!", "", "success")
          .then(okay => { if (okay) { this.router.navigate(['/']); } });
      },
      (err) => {
        console.log(err)
        Swal.fire({ icon: "error", title: "Ocorreu um erro, verifique se a data de nascimento está correta!" });
      }
    );
  }

  atualizarUsuario(form: NgForm) {
    this.service.putUsuario().subscribe(
      (res) => {
        Swal.fire("Edição Realizada com sucesso!", "", "success");
        this.router.navigate(['/']);
      },
      (err) => {
        if (err.error.text != null) {
          Swal.fire({ icon: "warning", title: err.error.text });
        } else {
          Swal.fire({ icon: "error", title: "Ocorreu um erro!" });
        }
      }
    );
  }
}
