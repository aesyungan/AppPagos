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
  constructor(private _http: HttpClient) { }
  insert(formData: PaymentDetail):Observable<any> {
    formData.UsuarioId=3;
    console.log(formData);
  return  this._http.post<any>(this.url+"/PaymentDetails", formData);
  }
}
