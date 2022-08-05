import { Component, OnInit } from '@angular/core';
import { Usuarios } from '../../shared/models/usuarios';
import { UsuariosService } from '../../shared/services/usuarios.service';
import { CommonModule } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { Observable } from "rxjs/Observable";
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-tabela',
  templateUrl: './tabela.component.html',
  styleUrls: ['./tabela.component.css']
})
export class TabelaComponent implements OnInit {
  public usuarios: Usuarios[];

  constructor(public service: UsuariosService, private router: Router) { }

  ngOnInit() {
    this.service.getUsuarios().subscribe(res => {
      this.usuarios = res as Usuarios[];
    })
  }

  atualizarUsuario($element): void { this.router.navigate(['/editar-usuario'], { state: { carta: $element as Usuarios } }); }

  deletarUsuario($element: Usuarios): void {
    Swal.fire({
      title: `Realmente deseja deletar? `,
      showDenyButton: true,
      showCancelButton: true,
      showConfirmButton: false,
      denyButtonText: `Deletar`,
    }).then((result) => {

      if (result.isDenied) {
        this.service.deleteUsuario($element.id).subscribe(
          res => {
            Swal.fire('Usuario deletado!', '', 'success');
            this.service.getUsuarios().subscribe(res => {
              this.usuarios = res as Usuarios[];
            })
          },
          err => {
            Swal.fire({ icon: 'error', title: 'Ocorreu um erro!' })
          }
        );
      }
    })
  }

  obterEscolaridade($elemento): string {
    console.log($elemento.id == '2')
    console.log($elemento.id)
    if ($elemento.escolaridade == 0) return "Infantil";
    if ($elemento.escolaridade == 1) return "Fundamental";
    if ($elemento.escolaridade == 2) return "Médio ";
    if ($elemento.escolaridade == 3) return "Superior";
}

}
