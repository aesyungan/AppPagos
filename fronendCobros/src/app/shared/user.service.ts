import { Injectable } from '@angular/core';
import { User } from './user.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly url = "http://localhost:26389/api"
  lst:Array<User>=[];
  constructor(private _http: HttpClient) { }
  
  listar():Observable<User[]> {
    return  this._http.get<User[]>(this.url+"/Users");
  }
  mostrar(){
    this.listar().subscribe(res=>{
      this.lst=res;
    },err=>{console.log(err);});
  }  
}
