import { Component, OnInit } from '@angular/core';
import { PaymentDetailService } from 'src/app/shared/payment-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { PaymentDetail } from 'src/app/shared/payment-detail.model';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-payment-detail',
  templateUrl: './payment-detail.component.html',
  styleUrls: ['./payment-detail.component.css']
})
export class PaymentDetailComponent implements OnInit {

  constructor(private _PaymentDetailService: PaymentDetailService,
    private _UserService: UserService
    , private _toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
    this._PaymentDetailService.mostrar();
    this._UserService.mostrar();
  }
  resetForm(frm?: NgForm) {

    if (frm != null) {
      frm.resetForm();
      this._PaymentDetailService.formData = {
        PMId: null,
        CardNumber: '',
        CardOwnerName: '',
        ExpirationDate: '',
        cvv: '',
        UsuarioId: 3,
        Usuario: null
      }
    }
  }
 
  onSubmit(frm: NgForm) {
    console.log(frm.value);
    if (this._PaymentDetailService.formData.PMId == null) {
     this.insertar(frm);
    } else {
      this.actuarlizar(frm);
    }
  }

  insertar(frm: NgForm) {
    console.log("insert");
    this._PaymentDetailService.insert().subscribe(res => {
      console.log(res);
      this.resetForm(frm);
      this._toastr.success('Ingreso', 'Correctament');
      this._PaymentDetailService.mostrar();
    }, err => {
      console.log(err);
    }
    );
  }
  actuarlizar(frm: NgForm) {
    
    console.log("actualizar");
    this._PaymentDetailService.modificar().subscribe(res => {
      console.log(res);
      this.resetForm(frm);
      this._toastr.info('Actualizacion', 'Correctament');
      this._PaymentDetailService.mostrar();
    }, err => {
      console.log(err);
    });
  }

}