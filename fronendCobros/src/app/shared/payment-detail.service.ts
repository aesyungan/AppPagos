import { Injectable } from '@angular/core';
import { PaymentDetail } from './payment-detail.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class PaymentDetailService {
  formData: PaymentDetail= new PaymentDetail();
  readonly url = "http://localhost:26389/api"
  lst:Array<PaymentDetail>=[];
  constructor(private _http: HttpClient) { }
  insert():Observable<any> {
  return  this._http.post<any>(this.url+"/PaymentDetails", this.formData);
  }

  modificar():Observable<any> {
   
  return  this._http.put<any>(this.url+"/PaymentDetails/"+this.formData.PMId, this.formData);
  }


  listar():Observable<PaymentDetail[]> {
  return  this._http.get<PaymentDetail[]>(this.url+"/PaymentDetails/show/all");
  }
  
  eliminar(id:number):Observable<any> {;
  return  this._http.delete<any>(this.url+"/PaymentDetails/"+id);
  }
  mostrar(){
    this.listar().subscribe(res=>{
      this.lst=res;
    }, err=>{console.log(err);});
  }
}
