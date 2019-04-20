import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-payment-details-list',
  templateUrl: './payment-details-list.component.html',
  styleUrls: ['./payment-details-list.component.css']
})
export class PaymentDetailsListComponent implements OnInit {

  constructor(private _PaymentDetailService: PaymentDetailService, private _toastr: ToastrService) { }

  ngOnInit() {
  }
  selectItem(item: PaymentDetail) {
    console.log("Hola");
    this._PaymentDetailService.formData = item;
  }
  eliminar(id:number){
    this._PaymentDetailService.eliminar(id).subscribe(res => {
      this._toastr.warning('Eliminación', 'Correctament');
      this._PaymentDetailService.mostrar();
    }, err => {
      console.log(err);
    });
  }
}
