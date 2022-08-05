import { Injectable } from "@angular/core";
import { Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Usuarios } from "../models/usuarios";
import { Observable, throwError, of } from 'rxjs';


@Injectable({
  providedIn: "root",
})
export class UsuariosService {
  public http;
  public baseUrl;
  formData: Usuarios = new Usuarios();

  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.http = http;
    this.baseUrl = baseUrl + "api/Usuarios";
  }

  getUsuarios(): Observable<any[]> {
    return this.http.get(this.baseUrl).pipe(res => { return res })
  }

  postUsuario() {
    return this.http.post(this.baseUrl, this.formData)
  }

  putUsuario() {
    return this.http.put(`${this.baseUrl}/${this.formData.id}`, this.formData)
  }

  deleteUsuario(id) {
    return this.http.delete(`${this.baseUrl}/${id}`)
  }

}
