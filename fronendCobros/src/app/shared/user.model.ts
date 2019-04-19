import { PaymentDetail } from "./payment-detail.model";

export class User {
    UsuarioId:number;
    Nombre:string;
    genero:string;
    edad:number;
    paymentDetails:Array<PaymentDetail>=[];
}
