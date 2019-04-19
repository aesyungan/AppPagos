import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styleUrls: ['./payment-detail.component.css']
})
export class PaymentDetailComponent implements OnInit {

  constructor(private _PaymentDetailService: PaymentDetailService) { }

  ngOnInit() {
  this.resetForm();
  }
  resetForm(frm?: NgForm) {
   
    if(frm!=null){
      frm.resetForm();
    this._PaymentDetailService.formData={
      PMId:0,
      CardNumber:'',
      CardOwnerName:'',
      ExpirationDate:'',
      cvv:'',
      UsuarioId:3,
      Usuario:null
    }
  }
  }
  onSubmit(frm:NgForm){
    console.log(frm);
    this._PaymentDetailService.insert(frm.value).subscribe(res=>{
      console.log(res);
        this.resetForm(frm);
            },err=>{
              console.log(err);
            }
            );
        }
}