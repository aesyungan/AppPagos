import { User } from "./user.model";

export class PaymentDetail {
    PMId:number;
    CardOwnerName:string;
    CardNumber:string;
    ExpirationDate:string;
    cvv:string;
    UsuarioId:number;
    Usuario:User;
}
